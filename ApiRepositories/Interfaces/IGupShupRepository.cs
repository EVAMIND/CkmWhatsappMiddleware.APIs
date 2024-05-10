using Services.DTOs.DataTransferObjects.MessageDTOs.Request.Base;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;

public interface IGupShupRepository
{
    Task<HttpResponseMessage> GetAllTemplatesByApiKey(string apiKey, string sourceName, string token);
    Task<HttpResponseMessage> GetWalletBalanceAsync(string apiKey, string token);
    //Task<HttpResponseMessage> SendTemplateToCustomers(BaseMessageRequestDTO messageTemplateRequest, string apiKey, string token);
    Task<HttpResponseMessage> SendWhatsAppMessage(string apiKey, BaseMessageRequestDTO messageRequest, string token);
    //Task<HttpResponseMessage> SendAudioMessage(string apiKey, BaseMessageRequestDTO messageRequest, string token);
    //Task<HttpResponseMessage> SendImageMessage(string apiKey, BaseMessageRequestDTO messageRequest, string token);
    //Task<HttpResponseMessage> SendFileMessage(string apiKey, BaseMessageRequestDTO  messageRequest, string token);
    //Task<HttpResponseMessage> SendVideoMessage(string apiKey, BaseMessageRequestDTO  messageRequest, string token);
    //Task<HttpResponseMessage> SendStickerMessage(string apiKey, BaseMessageRequestDTO  messageRequest, string token);
}
