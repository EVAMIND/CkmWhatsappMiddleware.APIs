using CkmICDServices.DTOs.TransferObjects.Message.Request.Base;
using CkmICDServices.DTOs.TransferObjects.Message.Request;
using CkmICDServices.DTOs.TransferObjects.Message;
using CkmICDServices.DTOs.TransferObjects.Template;
using CkmICDServices.DTOs.TransferObjects.Template.Request;

namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;

public interface IGupShupApplication
{
    Task<bool> GetWalletBalanceAsync(string apiKey, string token);
    Task<MessageTemplateResultView> GetAllTemplatesByApiKey(string apiKey, string sourceName, string token);
    Task<bool> SendTemplateToCustomers(BaseMessageRequestDTO<MessageTemplateRequestView> messageTemplateRequest, string apiKey, string token);
    Task<MessageInboundView> SendTextMessage(string apiKey, BaseMessageRequestDTO<TextMessageRequestDTO> messageRequest, string token);
    Task<MessageInboundView> SendAudioMessage(string apiKey, BaseMessageRequestDTO<AudioMessageRequestDTO> messageRequest, string token);
    Task<MessageInboundView> SendImageMessage(string apiKey, BaseMessageRequestDTO<ImageMessageRequestDTO> messageRequest, string token);
    Task<MessageInboundView> SendFileMessage(string apiKey, BaseMessageRequestDTO<FileMessageRequestDTO> messageRequest, string token);
    Task<MessageInboundView> SendVideoMessage(string apiKey, BaseMessageRequestDTO<VideoMessageRequestDTO> messageRequest, string token);
    Task<MessageInboundView> SendStickerMessage(string apiKey, BaseMessageRequestDTO<StickerMessageRequestDTO> messageRequest, string token);
}
