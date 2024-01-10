using Blazored.SessionStorage;

namespace PersonaliTune.UI.Services;

public class SessionTokenService : ITokenService
{
    private const string Key = "Token";

    private readonly ISessionStorageService _service;

    public SessionTokenService(ISessionStorageService service)
    {
        _service = service;
    }

    public async Task SetToken(string token)
    {
        await _service.SetItemAsync(Key, token);
    }

    public async Task<string> GetToken()
    {
        return await _service.GetItemAsync<string>(Key);
    }

    public async Task DeleteToken()
    {
        if (await _service.ContainKeyAsync(Key))
        {
            await _service.RemoveItemAsync(Key);
        }
    }
}
