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

    private List<ScrapFood> ScrapFood()
    {
        var foods = new List<ScrapFood>();
        var page = 1;
        var maxPage = 57;
        var countPage = 0;
        var id = 1;
        var maxId = 6;

        string xpath = "//tbody/tr";

        while (page <= maxPage && id <= maxId)
        {
            var url = $"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina={page}&atuald={id}#";
            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);
            var currentPageRows = htmlDoc.DocumentNode.SelectNodes(xpath);

            if (currentPageRows == null)
            {
                break; // Sai do loop se não houver mais linhas na página atual
            }

            foreach (var row in currentPageRows)
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
            Console.WriteLine(url);
            page++;
            countPage++;
            if (countPage == 10)
            {
                id++;
                countPage = 0;
            }
        }

        if (foods.Count == 0)
        {
            throw new Exception("Nenhuma informação encontrada.");
        }

        return foods;
    }
}