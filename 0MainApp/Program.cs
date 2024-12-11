using MainApp;
using ErrorOr;
using Events;
using ROP;

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

#region Railway/Result-Oriented Programming (ROP) || Function Composition
var result1 = UpdateProfile(new User
{
    Email = "amini.ebrahim.it@gmail.com"
});

Console.WriteLine(result1.Message);

static ActionResult<int> UpdateProfile(User user)
{
    var result = ActionResult.CreateValidator(user)
                             .Validator(x => string.IsNullOrEmpty(x.Name), "Name is Required")
                             .Validator(x => x.Name.Length > 50, "Name must be less than 50")
                             .Validator(x => string.IsNullOrEmpty(x.Email), "Email is Required");
    if (!result.IsSuccess)
    {
        return ActionResult.Failure<int>(result.Message);
    }

    return ActionResult.Success<int>(5);
}
#endregion

Console.ReadKey();





