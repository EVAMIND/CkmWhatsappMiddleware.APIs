using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using CkmWhatsAppMiddleware.APIs.Models;
using Helpers.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Repositories;

public class GupShupRepository: IGupShupRepository
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly WhatsAppMiddlewareApi _whatsAppMiddlewareApi;
    private readonly string _apiVersion;

    public GupShupRepository(HttpClient httpClient, IConfiguration configuration, IOptions<WhatsAppMiddlewareApi> whatsAppMiddlewareApi)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _whatsAppMiddlewareApi = whatsAppMiddlewareApi.Value;
        _apiVersion = _whatsAppMiddlewareApi.Versions.GupShup;
        _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("Uris:WhatsAppMiddlewareApi")!.ToString()!);
    }

    public async Task<HttpResponseMessage> GetWalletBalanceAsync(string apiKey, string token)
    {
        string uri = $"{_whatsAppMiddlewareApi.Controllers.GupShup}/GetWalletBalance";

        _httpClient.AddBearerToken(token);
        _httpClient.AddApiVersion(_apiVersion);                
        _httpClient.AddOrUpdateHeader("apiKey", apiKey.ToString());

        return await _httpClient.GetAsync();
    }
}
