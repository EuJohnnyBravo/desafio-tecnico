namespace WebScrapping.Exception.ExceptionsBase;

public abstract class WebScrappingException : SystemException
{
    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();

    protected WebScrappingException(string message) : base(message) { }
}
