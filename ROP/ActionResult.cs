namespace ROP;

/// <summary>
/// Functions Composite ترکیب توابع به یکدیگر یا
/// ترکیب توابع به معنای استفاده از خروجی یک تابع به عنوان ورودی برای تابع دیگری است.
/// این کار به شما این امکان را می‌دهد که توابع کوچک و مستقل را با هم ترکیب کنید تا توابع پیچیده‌تری بسازید
/// یک الگوی برنامه‌نویسی است که بر اساس نتایج حاصل از توابع بنا شده است ROP
/// </summary>
public class ActionResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public static ActionResult<T> CreateValidator<T>(T param) => new(param);
    public static ActionResult<T> Failure<T>(string message) => new(message);
    public static ActionResult<T> Success<T>(T data) => new(data);
}

public class ActionResult<T> : ActionResult
{
    public T? Data { get; set; }
    public ActionResult(string message)
    {
        Message = message;
        IsSuccess = false;
    }
    public ActionResult(T data)
    {
        Data = data;
        IsSuccess = true;
    }
}

public static class ActionResultExtension
{
    public static ActionResult<T> Validator<T>(this ActionResult<T> actionResult, Func<T, bool> predict, string message)
    {
        if (!actionResult.IsSuccess)
        {
            return actionResult;
        }

        var predictResult = predict(actionResult.Data!);
        if (predictResult)
        {
            return ActionResult.Failure<T>(message);
        }

        return actionResult;
    }
}
