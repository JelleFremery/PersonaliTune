using Blazored.LocalStorage;

namespace PersonaliTune.UI.Services;

public class LocalTokenService : ITokenService
{
    private const string Key = "Token";

    private readonly ILocalStorageService _service;

    public LocalTokenService(ILocalStorageService service)
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
