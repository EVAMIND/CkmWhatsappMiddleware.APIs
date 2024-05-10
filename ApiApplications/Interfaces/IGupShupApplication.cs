using Services.DTOs.DataTransferObjects.MessageDTOs;
using Services.DTOs.DataTransferObjects.MessageDTOs.Request.Base;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template;

namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;

public interface IGupShupApplication
{
    Task<bool> GetWalletBalanceAsync(string apiKey, string token);
    Task<MessageTemplateResultView> GetAllTemplatesByApiKey(string apiKey, string sourceName, string token);
    //Task<MessageInboundResponseView> SendTemplateToCustomers(BaseMessageRequestDTO<MessageTemplateRequestView> messageTemplateRequest, string apiKey, string token);
    Task<MessageInboundResponseView> SendWhatsAppMessage(string apiKey, BaseMessageRequestDTO messageRequest, string token);
    //Task<MessageInboundResponseView> SendAudioMessage(string apiKey, BaseMessageRequestDTO<AudioMessageRequestDTO> messageRequest, string token);
    //Task<MessageInboundResponseView> SendImageMessage(string apiKey, BaseMessageRequestDTO<ImageMessageRequestDTO> messageRequest, string token);
    //Task<MessageInboundResponseView> SendFileMessage(string apiKey, BaseMessageRequestDTO<FileMessageRequestDTO> messageRequest, string token);
    //Task<MessageInboundResponseView> SendVideoMessage(string apiKey, BaseMessageRequestDTO<VideoMessageRequestDTO> messageRequest, string token);
    //Task<MessageInboundResponseView> SendStickerMessage(string apiKey, BaseMessageRequestDTO<StickerMessageRequestDTO> messageRequest, string token);
}
