namespace WebScrapping.Communication.Responses;

public class ResponseGetAllFoodJson
{
    public List<ResponseSingleFoodJson> Foods { get; set; } = new List<ResponseSingleFoodJson>();
}
