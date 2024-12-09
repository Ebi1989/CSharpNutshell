using Events;

namespace MainApp;
public class Stock : EventMain
{
    private decimal _price;
    public decimal Price
    {
        get => _price; set
        {
            if (_price != value)
            {
                _price = value;
                OnEventChanged(new MessageEventArgs($"Price changed to: {_price}"));
            }
        }
    }
}





