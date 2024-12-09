using MainApp;
using ErrorOr;
using Events;

Console.WriteLine("Hello, Welcome...");

#region Pipeline Oriented
static int Add1(int x) => x + 1;
static int Add2(int x) => x + 2;

var res = 5.Pipe(Add1)
           .Pipe(Add2);
#endregion

#region Error Handler
static ErrorOr<float> Divide(int a, int b)
{
    if (b == 0)
    {
        return Error.Unexpected();
    }
    return a / b;
}

var result = Divide(4, 0);
if (result.IsError)
{
    Console.WriteLine("Error");
}
else
{
    Console.WriteLine(result.Value);
}
#endregion

Console.WriteLine(res);

Stock stock = new();

stock.EventChanged += Stock_EventChanged;

stock.Price = 100m;
stock.Price = 105m;
stock.Price = 110m;
stock.Price = 115m;

static void Stock_EventChanged(object? sender, EventMain.MessageEventArgs e)
{
    Console.WriteLine(e.Text);
}

Console.ReadKey();





