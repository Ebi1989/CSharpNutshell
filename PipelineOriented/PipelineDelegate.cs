namespace MainApp;

public static class PipelineDelegate
{
    public static TOut Pipe<TIn, TOut>(this TIn input, Func<TIn, TOut> fn)
    {
        return fn(input);
    }
}