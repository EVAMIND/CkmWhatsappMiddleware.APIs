using Services.DTOs.DataTransferObjects.MessageDTOs.Template;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template.Request;

namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;

public interface IGrupoBoticarioTemplateRepository
{
    Task<HttpResponseMessage> ListTemplatesAsync(MessageTemplateListRequest messageTemplateListRequest, string token);
    Task<HttpResponseMessage> NewTemplateRawAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppRawDTO templateWhatsAppRaw, string token);
    Task<HttpResponseMessage> NewTemplateTextAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppTextDTO templateWhatsAppText, string token);
}
