using Services.DTOs.DataTransferObjects.MessageDTOs.Template;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template.Request;
using Services.DTOs.DataTransferObjects.MessageDTOs.Template.Result;

namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;

public interface IGrupoBoticarioTemplateApplication
{
    Task<TemplateWhatsAppListReturnDTO> ListTemplatesAsync(MessageTemplateListRequest messageTemplateListRequest, string token);
    Task<string> NewTemplateRawAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppRawDTO templateWhatsAppRaw, string token);
    Task<string> NewTemplateTextAsync(string apiKey, string tokenBroker, string url, TemplateWhatsAppTextDTO templateWhatsAppText, string token);
}
