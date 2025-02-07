using HtmlAgilityPack;
using WebScrapping.Communication.Requests;
using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Food.Search;

public class SearchFoodUseCase : ISearchFoodUseCase
{
    public async Task<ResponseSearchFoodJson> Execute(RequestSearchFoodJson request)
    {
        SearchFood(request.Search);
        return await Task.FromResult(new ResponseSearchFoodJson());
    }

    private void SearchFood(string search)
    {
        var html = @"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(html);
        string xpath = "//table[@class='table table-striped']//tr";

        var node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
    }
}