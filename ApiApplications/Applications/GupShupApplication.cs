using CkmWhatsAppMiddleware.APIs.ApiApplications.Interfaces;
using CkmWhatsAppMiddleware.APIs.ApiRepositories.Interfaces;
using System.Net;

namespace CkmWhatsAppMiddleware.APIs.ApiApplications.Applications;

public  class GupShupApplication : IGupShupApplication
{
    private readonly IGupShupRepository _repository;

    public GupShupApplication(IGupShupRepository repository)
    {
        _repository = repository;
    }
    public virtual async Task<bool> GetWalletBalanceAsync(string apiKey, string token)
    {
        try
        {
            var response = await _repository.GetWalletBalanceAsync(apiKey, token);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return false;
                else
                    throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
                throw new Exception($"Não foi possível executar a api com apiKey: {apiKey} E Token: {token} E Response: {response}");

            return bool.Parse(content);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
