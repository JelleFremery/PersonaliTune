using System.Text.Json.Serialization;

namespace PersonaliTune.Models.Prompts;

public class Prompt
{
    private static readonly string[] _validRoles = new string[3] { PromptRole.User, PromptRole.System, PromptRole.Assistant };

    public string Role { get; init; }

    public string Content { get; init; }

    [JsonConstructor]
    public Prompt(string role, string content)
    {
        Role = role;
        Content = content;
    }

    public static Prompt Create(string role, string content)
    {
        if (!_validRoles.Contains(role))
        {
            throw new ArgumentException("Role must be one of the following $" + string.Join(",", _validRoles), "role");
        }

        return new Prompt(role, content);
    }
}
