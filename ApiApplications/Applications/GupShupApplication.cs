using CkmICDServices.DTOs.TransferObjects.Message;
using CkmICDServices.DTOs.TransferObjects.Message.Request;
using CkmICDServices.DTOs.TransferObjects.Message.Request.Base;
using CkmICDServices.DTOs.TransferObjects.Template;
using CkmICDServices.DTOs.TransferObjects.Template.Request;
using CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;
using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using Newtonsoft.Json;
using System.Net;

namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Applications;

public class GupShupApplication : IGupShupApplication
{
    private readonly IGupShupRepository _repository;

    public GupShupApplication(IGupShupRepository repository)
    {
        _repository = repository;
    }
    public virtual async Task<bool> GetWalletBalanceAsync(string apiKey, string token)
    {
        try
        {
            var response = await _repository.GetWalletBalanceAsync(apiKey, token);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return false;
                else
                    throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");

            return bool.Parse(content);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual async Task<MessageTemplateResultView> GetAllTemplatesByApiKey(string apiKey, string sourceName, string token)
    {
        try
        {
            var response = await _repository.GetAllTemplatesByApiKey(apiKey, sourceName, token);

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

            return JsonConvert.DeserializeObject<MessageTemplateResultView>(content);
        }
        catch (Exception)
        {
            throw;
        }
    }  
    public virtual async Task<bool> SendTemplateToCustomers(BaseMessageRequestDTO<MessageTemplateRequestView> messageTemplateRequest, string apiKey,  string token)
    {
        try
        {
            var response = await _repository.SendTemplateToCustomers(messageTemplateRequest, apiKey, token);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return false;
                else
                    throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");

            return bool.Parse(content);

            
        }
        catch (Exception)
        {
            throw;
        }
    } 
    public virtual async Task<MessageInboundResponseView> SendTextMessage(string apiKey,  BaseMessageRequestDTO<TextMessageRequestDTO> messageRequest, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.SendTextMessage(apiKey, messageRequest, token);

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

            return JsonConvert.DeserializeObject<MessageInboundResponseView>(content);

        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<MessageInboundResponseView> SendAudioMessage(string apiKey, BaseMessageRequestDTO<AudioMessageRequestDTO> messageRequest, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.SendAudioMessage(apiKey, messageRequest, token);

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

            return JsonConvert.DeserializeObject<MessageInboundResponseView>(content);

        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<MessageInboundResponseView> SendImageMessage(string apiKey, BaseMessageRequestDTO<ImageMessageRequestDTO> messageRequest, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.SendImageMessage(apiKey, messageRequest, token);

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

            return JsonConvert.DeserializeObject<MessageInboundResponseView>(content);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<MessageInboundResponseView> SendFileMessage(string apiKey, BaseMessageRequestDTO<FileMessageRequestDTO> messageRequest, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.SendFileMessage(apiKey, messageRequest, token);

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

            return JsonConvert.DeserializeObject<MessageInboundResponseView>(content);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<MessageInboundResponseView> SendVideoMessage(string apiKey, BaseMessageRequestDTO<VideoMessageRequestDTO> messageRequest, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.SendVideoMessage(apiKey, messageRequest, token);

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

            return JsonConvert.DeserializeObject<MessageInboundResponseView>(content);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<MessageInboundResponseView> SendStickerMessage(string apiKey, BaseMessageRequestDTO<StickerMessageRequestDTO> messageRequest, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.SendStickerMessage(apiKey, messageRequest, token);

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

            return JsonConvert.DeserializeObject<MessageInboundResponseView>(content);

        }
        catch (Exception)
        {
            throw;
        }
    }
}
