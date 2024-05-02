namespace CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;

public interface IGupShupRepository
{
    Task<HttpResponseMessage> GetWalletBalanceAsync(string apiKey, string token);
}
