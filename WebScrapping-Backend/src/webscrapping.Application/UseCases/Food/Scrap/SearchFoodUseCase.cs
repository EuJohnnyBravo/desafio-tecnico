using AutoMapper;
using HtmlAgilityPack;
using WebScrapping.Communication.DataScrap;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.Repositories;
using WebScrapping.Domain.Repositories.Foods;

namespace WebScrapping.Application.UseCases.Food.Scrap;

public class SearchFoodUseCase : ISearchFoodUseCase
{
    private readonly IFoodWriteOnlyRepository _respository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private const string BaseUrl = "https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina={0}&atuald={1}#";
    private const string XPath = "//tbody/tr";
    private const int MaxPagesPerId = 10;

    public SearchFoodUseCase(
        IFoodWriteOnlyRepository respository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _mapper = mapper;
        _respository = respository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseShortFoodJson> Execute()
    {
        var foods = ScrapFood();
        var entities = _mapper.Map<List<Domain.Entities.Food>>(foods);
        Console.WriteLine("Entities: " + entities.Count);
        foreach (var entity in entities)
        {
            await _respository.Add(entity);
        }
        await _unitOfWork.Commit();

        return new ResponseShortFoodJson
        {
            Foods = _mapper.Map<List<ResponseFoodsJson>>(entities)
        };
    }

    public List<ScrapFood> ScrapFood()
    {
        var foods = new List<ScrapFood>();
        int page = 1, countPage = 0, id = 1;

        while (true)
        {
            string url = GenerateUrl(page, id);
            var rows = FetchHtmlRows(url);

            if (rows == null)
                break;

            ExtractFoodsFromRows(rows, foods);

            Console.WriteLine(url);
            page++;
            countPage++;

            if (countPage == MaxPagesPerId)
            {
                id++;
                countPage = 0;
            }

            if (!HasNextPage(rows))
                break;
        }

        if (foods.Count == 0)
            throw new Exception("Nenhuma informação encontrada.");

        return foods;
    }

    private string GenerateUrl(int page, int id) => string.Format(BaseUrl, page, id);

    private HtmlNodeCollection? FetchHtmlRows(string url)
    {
        var web = new HtmlWeb();
        var htmlDoc = web.Load(url);
        Console.WriteLine(url);
        return htmlDoc.DocumentNode.SelectNodes(XPath);
    }

    private void ExtractFoodsFromRows(HtmlNodeCollection rows, List<ScrapFood> foods)
    {
        foreach (var row in rows)
        {
            var cells = row.SelectNodes("./td");
            if (cells != null && cells.Count >= 4)
            {
                foods.Add(new ScrapFood
                {
                    Code = cells[0].InnerText.Trim(),
                    Name = cells[1].InnerText.Trim(),
                    ScientificName = cells[2].InnerText.Trim(),
                    Group = cells[3].InnerText.Trim()
                });
            }
        }
    }

    private bool HasNextPage(HtmlNodeCollection? rows)
    {
        return rows != null && rows.Count > 0;
    }
}