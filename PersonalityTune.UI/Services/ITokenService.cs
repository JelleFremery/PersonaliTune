namespace PersonaliTune.UI.Services;

public interface ITokenService
{
    Task SetToken(string token);
    Task<string> GetToken();
    Task DeleteToken();
}
