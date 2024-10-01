using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using CkmWhatsAppMiddleware.APIs.Models;
using Helpers.Core;
using Helpers.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.DTOs.DataTransferObjects.MessageDTOs.Request.Base;
using System.Text.Json;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Repositories;

public class GupShupRepository : IGupShupRepository
{
    private readonly IHttpClientFactory _httpClient;
    private readonly IConfiguration _configuration;
    private readonly WhatsAppMiddlewareApi _whatsAppMiddlewareApi;
    private readonly string _apiVersion;
    private readonly Uri _baseAddress;
    public GupShupRepository(IHttpClientFactory httpClient, IConfiguration configuration, IOptions<WhatsAppMiddlewareApi> whatsAppMiddlewareApi)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _whatsAppMiddlewareApi = whatsAppMiddlewareApi.Value;
        _apiVersion = _whatsAppMiddlewareApi.Versions.GupShup;
        _baseAddress = new Uri(_configuration.GetValue<string>("Uris:WhatsAppMiddlewareApi")!.ToString()!);
        
    }

    public async Task<HttpResponseMessage> GetAllTemplatesByApiKey(string apiKey, string sourceName, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/ListTemplatesAsync";
        var client = new EvaHttpClient(_httpClient.CreateClient());

        client.Client.BaseAddress = _baseAddress;
        client.AddOrUpdateUri(uri);
        client.AddBearerToken(token);
        client.AddApiVersion(_apiVersion);
        client.AddOrUpdateHeader("apiKey", apiKey.ToString());
        client.AddOrUpdateHeader("sourceName", sourceName.ToString());

        return await client.GetAsync();
    }

    public async Task<HttpResponseMessage> GetWalletBalanceAsync(string apiKey, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/GetWalletBalance";
        var client = new EvaHttpClient(_httpClient.CreateClient());

        client.Client.BaseAddress = _baseAddress;
        client.AddOrUpdateUri(uri);
        client.AddBearerToken(token);
        client.AddApiVersion(_apiVersion);
        client.AddOrUpdateHeader("apiKey", apiKey.ToString());

        return await client.GetAsync();
    }

    //public async Task<HttpResponseMessage> SendVideoMessage(string apiKey, BaseMessageRequestDTO<VideoMessageRequestDTO> messageRequest, string token)
    //{
    //    string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/SendVideoMessage";

    //    _httpClient.AddOrUpdateUri(uri);
    //    _httpClient.AddBearerToken(token);
    //    _httpClient.AddApiVersion(_apiVersion);
    //    _httpClient.AddOrUpdateHeader("apiKey", apiKey.ToString());

    //    _httpClient.AddBody(messageRequest);

    //    return await _httpClient.PostAsync();


    //    //StringContent content = new StringContent(JsonConvert.SerializeObject(messageRequest));

    //    //HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

    //    //response.EnsureSuccessStatusCode();

    //    //if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
    //    //{
    //    //    return null;
    //    //}

    //    //return response;
    //}
    //public async Task<HttpResponseMessage> SendAudioMessage(string apiKey, BaseMessageRequestDTO<AudioMessageRequestDTO> messageRequest, string token)
    //{
    //    string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/SendAudioMessage";

    //    _httpClient.AddOrUpdateUri(uri);
    //    _httpClient.AddBearerToken(token);
    //    _httpClient.AddApiVersion(_apiVersion);
    //    _httpClient.AddOrUpdateHeader("apiKey", apiKey.ToString());

    //    _httpClient.AddBody(messageRequest);

    //    return await _httpClient.PostAsync();



    //    //StringContent content = new StringContent(JsonConvert.SerializeObject(messageRequest));

    //    //HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

    //    //response.EnsureSuccessStatusCode();

    //    //if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
    //    //{
    //    //    return null;
    //    //}

    //    //return response;
    //}

    //public async Task<HttpResponseMessage> SendFileMessage(string apiKey, BaseMessageRequestDTO<FileMessageRequestDTO> messageRequest, string token)
    //{
    //    string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/SendFileMessage";

    //    _httpClient.AddOrUpdateUri(uri);
    //    _httpClient.AddBearerToken(token);
    //    _httpClient.AddApiVersion(_apiVersion);
    //    _httpClient.AddOrUpdateHeader("apiKey", apiKey.ToString());

    //    _httpClient.AddBody(messageRequest);

    //    return await _httpClient.PostAsync();


    //    //StringContent content = new StringContent(JsonConvert.SerializeObject(messageRequest));

    //    //HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

    //    //response.EnsureSuccessStatusCode();

    //    //if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
    //    //{
    //    //    return null;
    //    //}

    //    //return response;
    //}

    //public async Task<HttpResponseMessage> SendImageMessage(string apiKey, BaseMessageRequestDTO<ImageMessageRequestDTO> messageRequest, string token)
    //{
    //    string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/SendImageMessage";

    //    _httpClient.AddOrUpdateUri(uri);
    //    _httpClient.AddBearerToken(token);
    //    _httpClient.AddApiVersion(_apiVersion);
    //    _httpClient.AddOrUpdateHeader("apiKey", apiKey.ToString());

    //    _httpClient.AddBody(messageRequest);

    //    return await _httpClient.PostAsync();



    //    //StringContent content = new StringContent(JsonConvert.SerializeObject(messageRequest));

    //    //HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

    //    //response.EnsureSuccessStatusCode();

    //    //if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
    //    //{
    //    //    return null;
    //    //}

    //    //return response;
    //}

    //public async Task<HttpResponseMessage> SendStickerMessage(string apiKey, BaseMessageRequestDTO<StickerMessageRequestDTO> messageRequest, string token)
    //{
    //    string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/SendStickerMessage";

    //    _httpClient.AddOrUpdateUri(uri);
    //    _httpClient.AddBearerToken(token);
    //    _httpClient.AddApiVersion(_apiVersion);
    //    _httpClient.AddOrUpdateHeader("apiKey", apiKey.ToString());


    //    _httpClient.AddBody(messageRequest);

    //    return await _httpClient.PostAsync();


    //    //StringContent content = new StringContent(JsonConvert.SerializeObject(messageRequest));

    //    //HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

    //    //response.EnsureSuccessStatusCode();

    //    //if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
    //    //{
    //    //    return null;
    //    //}

    //    //return response;
    //}

    //public async Task<HttpResponseMessage> SendTemplateToCustomers(BaseMessageRequestDTO<MessageTemplateRequestView> messageTemplate, string apiKey, string token)
    //{
    //    string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/SendTemplateToCustomers";

    //    _httpClient.AddOrUpdateUri(uri);
    //    _httpClient.AddBearerToken(token);
    //    _httpClient.AddApiVersion(_apiVersion);
    //    _httpClient.AddOrUpdateHeader("apiKey", apiKey.ToString());

    //    _httpClient.AddBody(messageTemplate);

    //    return await _httpClient.PostAsync();


    //    //StringContent content = new StringContent(JsonConvert.SerializeObject(messageTemplate));

    //    //HttpResponseMessage response = await _httpClient.PostAsync(uri, content);

    //    //response.EnsureSuccessStatusCode();

    //    //return response.StatusCode == System.Net.HttpStatusCode.Accepted;
    //}

    public async Task<HttpResponseMessage> SendWhatsAppMessage(string apiKey, BaseMessageRequestDTO messageRequest, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/SendWhatsAppMessage";
        var client = new EvaHttpClient(_httpClient.CreateClient());

        client.Client.BaseAddress = _baseAddress;
        client.AddOrUpdateUri(uri);
        client.AddBearerToken(token);
        client.AddApiVersion(_apiVersion);

        client.AddBody(JsonSerializer.Serialize(messageRequest));

        return await client.PostAsync();

    }

}
