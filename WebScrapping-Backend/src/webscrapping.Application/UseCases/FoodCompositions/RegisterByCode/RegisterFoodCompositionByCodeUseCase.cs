using AutoMapper;
using HtmlAgilityPack;
using WebScrapping.Communication.DataScrap;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Domain.Entities;

namespace WebScrapping.Application.UseCases.FoodCompositions.RegisterByCode;

public class RegisterFoodCompositionByCodeUseCase : IRegisterFoodCompositionByCodeUseCase
{
    private readonly IFoodCompositionWriteOnlyRepository _repositoryWrite;
    private readonly IMapper _mapper;

    string baseUrl = "https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto=";
    private const string XPath = "//*[@id=\"tabela1\"]/tbody/tr";
    public RegisterFoodCompositionByCodeUseCase(
        IFoodCompositionWriteOnlyRepository repositoryWrite,
        IMapper mapper)
    {
        _repositoryWrite = repositoryWrite;
        _mapper = mapper;
    }

    public async Task<ResponseRegisterFoodCompositionJson> Execute(string code)
    {
        var foodCompositions = ScrapFoodComposition(code);
        var entities = _mapper.Map<List<FoodComposition>>(foodCompositions);
        await _repositoryWrite.AddAll(entities);
        return new ResponseRegisterFoodCompositionJson
        {
            Code = code
        };
    }

    private List<ScrapFoodComposition> ScrapFoodComposition(string code)
    {
        var foodCompositions = new List<ScrapFoodComposition>();
        string url = baseUrl + code;
        var web = new HtmlWeb();
        var htmlDoc = web.Load(url);
        var rows = htmlDoc.DocumentNode.SelectNodes(XPath);

        if (rows != null)
        {
            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");

                if (cells != null && cells.Count >= 8)
                {
                    var foodComposition = new ScrapFoodComposition
                    {
                        FoodCode = code,
                        Component = cells[0].InnerText.Trim(),
                        Unit = cells[1].InnerText.Trim(),
                        ValuePer100g = TryParseDecimal(cells[2].InnerText),
                        StandardDeviation = TryParseDecimal(cells[3].InnerText),
                        MinimumValue = TryParseDecimal(cells[4].InnerText),
                        MaximumValue = TryParseDecimal(cells[5].InnerText),
                        NumberOfDataUsed = TryParseInt(cells[6].InnerText),
                        Reference = cells[7].InnerText.Trim(),
                        DataType = cells.Count > 8 ? cells[8].InnerText.Trim() : ""
                    };
                    foodCompositions.Add(foodComposition);
                    Console.WriteLine($"Componente: {foodComposition.Component} FoodCode: {foodComposition.FoodCode}");
                }
            }
        }
        else
        {
            throw new Exception("Não foi possível encontrar os dados da composição do alimento");
        }
        return foodCompositions;
    }

    static decimal? TryParseDecimal(string value)
    {
        return decimal.TryParse(value, out decimal result) ? result : (decimal?)null;
    }

    static int? TryParseInt(string value)
    {
        return int.TryParse(value, out int result) ? result : (int?)null;
    }
}
