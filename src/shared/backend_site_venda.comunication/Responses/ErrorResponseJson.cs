﻿namespace BackendSiteVendas.Comunication.Responses;

public class ErrorResponseJson
{
    public List<string> Messages { get; set; }

    public ErrorResponseJson(string messages)
    {
        Messages = new List<string> {
        messages
    };
    }

    public ErrorResponseJson(List<string> mensagens)
    {
        Messages = mensagens;
    }
}
