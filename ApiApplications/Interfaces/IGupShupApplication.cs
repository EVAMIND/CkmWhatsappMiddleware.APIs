namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;

public interface IGupShupApplication
{
    Task<bool> GetWalletBalanceAsync(string apiKey, string token);
}
