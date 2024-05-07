
using CkmICDServices.DTOs.TransferObjects.Message.Request;
using CkmICDServices.DTOs.TransferObjects.Message.Request.Base;
using CkmICDServices.DTOs.TransferObjects.Template.Request;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;

public interface IGupShupRepository
{
    Task<HttpResponseMessage> GetAllTemplatesByApiKey(string apiKey, string sourceName, string token);
    Task<HttpResponseMessage> GetWalletBalanceAsync(string apiKey, string token);
    Task<HttpResponseMessage> SendTemplateToCustomers(BaseMessageRequestDTO<MessageTemplateRequestView> messageTemplateRequest, string apiKey, string token);
    Task<HttpResponseMessage> SendTextMessage(string apiKey, BaseMessageRequestDTO<TextMessageRequestDTO> messageRequest, string token);
    Task<HttpResponseMessage> SendAudioMessage(string apiKey, BaseMessageRequestDTO<AudioMessageRequestDTO> messageRequest, string token);
    Task<HttpResponseMessage> SendImageMessage(string apiKey, BaseMessageRequestDTO<ImageMessageRequestDTO> messageRequest, string token);
    Task<HttpResponseMessage> SendFileMessage(string apiKey, BaseMessageRequestDTO<FileMessageRequestDTO> messageRequest, string token);
    Task<HttpResponseMessage> SendVideoMessage(string apiKey, BaseMessageRequestDTO<VideoMessageRequestDTO> messageRequest, string token);
    Task<HttpResponseMessage> SendStickerMessage(string apiKey, BaseMessageRequestDTO<StickerMessageRequestDTO> messageRequest, string token);
}
