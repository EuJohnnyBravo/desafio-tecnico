using AutoMapper;
using HtmlAgilityPack;
using WebScrapping.Communication.DataScrap;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Domain.Repositories;
using WebScrapping.Domain.Repositories.Foods;
using WebScrapping.Domain.Entities;
using WebScrapping.Exception.ExceptionsBase;
using WebScrapping.Exception;

namespace WebScrapping.Application.UseCases.Foods.Scrap;

public class ScrapFoodsUseCase : IScrapFoodsUseCase
{
    private readonly IFoodWriteOnlyRepository _respositoryWrite;
    private readonly IFoodReadOnlyRepository _respositoryRead;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private const string BaseUrl = "https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina={0}&atuald={1}#";
    private const string XPath = "//tbody/tr";
    private const int MaxPagesPerId = 10;

    public ScrapFoodsUseCase(
        IFoodWriteOnlyRepository respositoryWrite,
        IFoodReadOnlyRepository respositoryRead,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _mapper = mapper;
        _respositoryWrite = respositoryWrite;
        _respositoryRead = respositoryRead;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisterFoodsJson> Execute()
    {
        var foods = ScrapFood();
        var entities = _mapper.Map<List<Food>>(foods);
        await _respositoryWrite.AddAll(entities);
        await _unitOfWork.Commit();

        return new ResponseRegisterFoodsJson
        {
            Foods = _mapper.Map<List<ResponseShortFoodJson>>(entities)
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
            throw new NotFoundException(ResourceErrorMessages.FOOD_NOT_FOUND);

        return foods;
    }

    private string GenerateUrl(int page, int id) => string.Format(BaseUrl, page, id);

    private HtmlNodeCollection? FetchHtmlRows(string url)
    {
        var web = new HtmlWeb();
        var htmlDoc = web.Load(url);
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