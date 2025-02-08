namespace WebScrapping.Communication.Responses;

public class ResponseGetAllFoodCompositionByCodeJson
{
    public List<ResponseFoodCompositionJson> Compositions { get; set; } = new List<ResponseFoodCompositionJson>();
}
