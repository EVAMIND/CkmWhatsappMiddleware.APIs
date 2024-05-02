namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;

public interface IGupShupApplication
{
    Task<bool> DeleteAsync(string apiKey, string token);
}
