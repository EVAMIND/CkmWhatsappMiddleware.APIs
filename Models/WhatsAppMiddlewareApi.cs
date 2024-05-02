namespace CkmWhatsAppMiddleware.APIs.Models;

public class WhatsAppMiddlewareApi
{
    public ControllerEndPoints Controllers { get; set; } = new ControllerEndPoints();
    public ControllerEndPointVersions Versions { get; set; } = new ControllerEndPointVersions();
}
