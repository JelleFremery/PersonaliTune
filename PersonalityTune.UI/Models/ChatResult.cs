namespace PersonaliTune.UI.Models;

public class ChatResult
{
    public bool IsSuccess { get; private set; }
    public string? Content { get; private set; }
    public string? Error { get; private set; }

    protected ChatResult(bool isSuccess, string? content, string? error)
    {
        IsSuccess = isSuccess;
        Content = content;
        Error = error;
    }

    public static ChatResult CreateSuccessResult(string content)
    {
        return new ChatResult(true, content, null);
    }

    public static ChatResult CreateFailureResult(string error)
    {
        return new ChatResult(false, default, error);
    }
}
