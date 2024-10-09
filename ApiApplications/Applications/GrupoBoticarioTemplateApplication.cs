using CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;
using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template.Request;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template.Result;
using System.Net;
using System.Text.Json;

namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Applications;

public class GrupoBoticarioTemplateApplication : IGrupoBoticarioTemplateApplication
{
    private readonly IGrupoBoticarioTemplateRepository _repository;

    public GrupoBoticarioTemplateApplication(IGrupoBoticarioTemplateRepository repository)
    {
        _repository = repository;
    }
    public virtual async Task<TemplateWhatsAppListReturnDTO> ListTemplatesAsync(MessageTemplateListRequest messageTemplateListRequest, string token)
    {
        try
        {
            var response = await _repository.ListTemplatesAsync(messageTemplateListRequest, token);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw new Exception($"Não foi possível executar a api com apiKey: {messageTemplateListRequest.ApiKey} E Token: {token} E Response: {response}");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                throw new Exception($"Não foi possível executar a api com apiKey: {messageTemplateListRequest.ApiKey} E Token: {token} E Response: {response}");

            var objDeserializeObject = JsonSerializer.Deserialize<TemplateWhatsAppListReturnDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (objDeserializeObject == null)
                throw new Exception($"Não foi possível executar a api com apiKey: {messageTemplateListRequest.ApiKey}  E Token: {token} E Response: {response}");

            return objDeserializeObject;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual async Task<string> NewTemplateTextAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppTextDTO templateWhatsAppText, string token)
    {
        try
        {
            var response = await _repository.NewTemplateTextAsync(apiKey, tokenBroker, url, templateWhatsAppText, token);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");

            var objDeserializeObject = JsonSerializer.Deserialize<string>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (objDeserializeObject == null)
                throw new Exception($"Não foi possível executar a api com apiKey: {apiKey}  E Token: {token} E Response: {response}");

            return objDeserializeObject;
        }
        catch (Exception)
        {
            throw;
        }
    }  
    
    public virtual async Task<string> NewTemplateRawAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppRawDTO templateWhatsAppRaw, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.NewTemplateRawAsync(apiKey, tokenBroker, url, templateWhatsAppRaw, token);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                    return null;
                
                else
                    throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");

            var objDeserializeObject = JsonSerializer.Deserialize<string>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (objDeserializeObject == null)
                throw new Exception($"Não foi possível executar a api com apiKey: {apiKey}  E Token: {token} E Response: {response}");

            return objDeserializeObject;

        }
        catch (Exception)
        {
            throw;
        }
    }

}
