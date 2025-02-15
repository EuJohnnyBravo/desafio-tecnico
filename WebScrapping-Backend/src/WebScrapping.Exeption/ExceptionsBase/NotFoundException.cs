﻿using System.Net;

namespace WebScrapping.Exception.ExceptionsBase;

public class NotFoundException : WebScrappingException
{
    public NotFoundException(string message) : base(message){}

    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public override List<string> GetErrors()
    {
        return new List<string> { Message };
    }
}
