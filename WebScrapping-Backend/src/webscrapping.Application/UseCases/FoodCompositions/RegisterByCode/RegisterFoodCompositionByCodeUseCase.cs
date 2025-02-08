using AutoMapper;
using HtmlAgilityPack;
using WebScrapping.Communication.DataScrap;
using WebScrapping.Communication.Responses;
using WebScrapping.Domain.DataAccess.Repositories;
using WebScrapping.Domain.Entities;
using WebScrapping.Exception;
using WebScrapping.Exception.ExceptionsBase;

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

    public async Task Execute(string code)
    {
        var foodCompositions = ScrapFoodComposition(code);
        var entities = _mapper.Map<List<FoodComposition>>(foodCompositions);
        await _repositoryWrite.AddAll(entities);
    }
    private List<ScrapFoodComposition> ScrapFoodComposition(string code)
    {
        string url = baseUrl + code;
        var htmlDoc = LoadHtmlDocument(url);
        var rows = GetTableRows(htmlDoc, XPath);

        return rows != null ? ExtractFoodCompositions(rows, code) : throw new NotFoundException(ResourceErrorMessages.FOOD_COMPOSITION_NOT_FOUND);
    }

    private HtmlDocument LoadHtmlDocument(string url)
    {
        var web = new HtmlWeb();
        return web.Load(url);
    }

    private HtmlNodeCollection? GetTableRows(HtmlDocument htmlDoc, string xPath)
    {
        return htmlDoc.DocumentNode.SelectNodes(xPath);
    }

    private List<ScrapFoodComposition> ExtractFoodCompositions(HtmlNodeCollection rows, string code)
    {
        var foodCompositions = new List<ScrapFoodComposition>();

        foreach (var row in rows)
        {
            var cells = row.SelectNodes("td");
            if (cells != null && cells.Count >= 8)
            {
                foodCompositions.Add(ParseFoodComposition(cells, code));
            }
        }

        return foodCompositions;
    }

    private ScrapFoodComposition ParseFoodComposition(HtmlNodeCollection cells, string code)
    {
        return new ScrapFoodComposition
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
