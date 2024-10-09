using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using CkmWhatsAppMiddleware.APIs.Models;
using Helpers.Core;
using Helpers.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.DTOs.DataTransferObjects.MessageDTOs.Request.Base;
using System.Text.Json;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Repositories;

public class MessagesRepository : IMessagesRepository
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IConfiguration _configuration;
    private readonly WhatsAppMiddlewareApi _whatsAppMiddlewareApi;
    private readonly string _apiVersion;
    private readonly Uri _baseAddress;
    public MessagesRepository(IHttpClientFactory httpClient, IConfiguration configuration, IOptions<WhatsAppMiddlewareApi> whatsAppMiddlewareApi)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _whatsAppMiddlewareApi = whatsAppMiddlewareApi.Value;
        _apiVersion = _whatsAppMiddlewareApi.Versions.Messages;
        _baseAddress = new Uri(_configuration.GetValue<string>("Uris:WhatsAppMiddlewareApi")!.ToString()!);
        
    }

    public async Task<HttpResponseMessage> SendWhatsAppMessage(BaseMessageRequestDTO messageRequest, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.Messages}/SendWhatsAppMessage";
        var client = new EvaHttpClient(_httpClient.CreateClient());

        client.Client.BaseAddress = _baseAddress;
        client.AddOrUpdateUri(uri);
        client.AddBearerToken(token);
        client.AddApiVersion(_apiVersion);

        client.AddBody(JsonSerializer.Serialize(messageRequest));

        return await client.PostAsync();

    }

}
