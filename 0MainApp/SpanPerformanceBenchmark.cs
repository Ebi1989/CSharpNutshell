using BenchmarkDotNet.Attributes;

namespace MainApp;


[MemoryDiagnoser]
public class SpanPerformanceBenchmark
{
    private readonly string _date = "1992-02-02";

    [Benchmark]
    public DateTime WithSubstring()
    {
        var year = _date.Substring(0, 4);
        var month = _date.Substring(5, 2);
        var day = _date.Substring(6, 3);
        Task.Delay(1000);
        return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
    }

    [Benchmark]
    public DateTime WithSplit()
    {
        var splitedDate = _date.Split('-');
        var year = splitedDate[0];
        var month = splitedDate[1];
        var day = splitedDate[2];
        return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
    }

    [Benchmark]
    public DateTime WithSpan()
    {
        ReadOnlySpan<char> dateSpan = _date;

        var year = dateSpan.Slice(0, 4);
        var month = dateSpan.Slice(5, 2);
        var day = dateSpan.Slice(6, 3);
        return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
    }

}