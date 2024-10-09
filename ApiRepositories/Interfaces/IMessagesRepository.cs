using Services.DTOs.DataTransferObjects.MessageDTOs.Request.Base;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;

public interface IMessagesRepository
{
    Task<HttpResponseMessage> SendWhatsAppMessage(BaseMessageRequestDTO messageRequest, string token);
}
