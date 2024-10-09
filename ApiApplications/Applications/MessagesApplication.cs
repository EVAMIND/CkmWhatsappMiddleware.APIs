using CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;
using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using Services.DTOs.DataTransferObjects.MessageDTOs;
using Services.DTOs.DataTransferObjects.MessageDTOs.Request.Base;
using System.Net;
using System.Text.Json;

namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Applications;

public class MessagesApplication : IMessagesApplication
{
    private readonly IMessagesRepository _repository;

    public MessagesApplication(IMessagesRepository repository)
    {
        _repository = repository;
    }
   
    public virtual async Task<MessageInboundResponseView> SendWhatsAppMessage(BaseMessageRequestDTO messageRequest, string token)
    {
        try
        {
            HttpResponseMessage response = await _repository.SendWhatsAppMessage( messageRequest, token);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                    return null;
                
                else
                    throw new Exception($"Não foi possível executar a api com apiKey: {messageRequest.ApiKey} E Token: {token} E Response: {response}");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                throw new Exception($"Não foi possível executar a api com apiKey: {messageRequest.ApiKey} E Token: {token} E Response: {response}");

            return JsonSerializer.Deserialize<MessageInboundResponseView>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

        }
        catch (Exception)
        {
            throw;
        }
    }

}
