using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using CkmWhatsAppMiddleware.APIs.Models;
using Helpers.Core;
using Helpers.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template.Request;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Repositories;

public class GrupoBoticarioTemplateRepository : IGrupoBoticarioTemplateRepository
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IConfiguration _configuration;
    private readonly WhatsAppMiddlewareApi _whatsAppMiddlewareApi;
    private readonly string _apiVersion;
    private readonly Uri _baseAddress;
    public GrupoBoticarioTemplateRepository(IHttpClientFactory httpClient, IConfiguration configuration, IOptions<WhatsAppMiddlewareApi> whatsAppMiddlewareApi)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _whatsAppMiddlewareApi = whatsAppMiddlewareApi.Value;
        _apiVersion = _whatsAppMiddlewareApi.Versions.GrupoBoticarioTemplate;
        _baseAddress = new Uri(_configuration.GetValue<string>("Uris:WhatsAppMiddlewareApi")!.ToString()!);
        
    }

    public async Task<HttpResponseMessage> ListTemplatesAsync(MessageTemplateListRequest messageTemplateListRequest, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.GrupoBoticarioTemplate}/ListTemplatesAsync";
        var client = new EvaHttpClient(_httpClient.CreateClient());

        client.Client.BaseAddress = _baseAddress;
        client.AddOrUpdateUri(uri);
        client.AddBearerToken(token);
        client.AddApiVersion(_apiVersion);

        client.AddBody(messageTemplateListRequest);

        return await client.PostAsync();
    }

    public async Task<HttpResponseMessage> NewTemplateTextAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppTextDTO templateWhatsAppText, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.GrupoBoticarioTemplate}/NewTemplateTextAsync";
        var client = new EvaHttpClient(_httpClient.CreateClient());

        client.Client.BaseAddress = _baseAddress;
        client.AddOrUpdateUri(uri);
        client.AddBearerToken(token);
        client.AddApiVersion(_apiVersion);
        client.AddParameter("apiKey", apiKey);
        client.AddParameter("tokenBroker", tokenBroker);
        client.AddParameter("url", url);

        client.AddBody(templateWhatsAppText);

        return await client.PostAsync();
    }

    public async Task<HttpResponseMessage> NewTemplateRawAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppRawDTO templateWhatsAppRaw, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.GrupoBoticarioTemplate}/NewTemplateRawAsync";
        var client = new EvaHttpClient(_httpClient.CreateClient());

        client.Client.BaseAddress = _baseAddress;
        client.AddOrUpdateUri(uri);
        client.AddBearerToken(token);
        client.AddApiVersion(_apiVersion);
        client.AddParameter("apiKey", apiKey);
        client.AddParameter("tokenBroker", tokenBroker);
        client.AddParameter("url", url);

        client.AddBody(templateWhatsAppRaw);

        return await client.PostAsync();
    }
}
