namespace WebScrapping.Communication.Responses;

public class ResponseErrorsJson
{
    public List<string> ErrorMessages { get; set; }

    public ResponseErrorsJson(string errorMessage)
    {
        ErrorMessages = new List<string> { errorMessage };
    }

    public ResponseErrorsJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
