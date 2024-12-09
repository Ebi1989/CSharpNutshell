namespace Events;

public class EventMain
{
    public event EventHandler<MessageEventArgs>? EventChanged;
    protected virtual void OnEventChanged(MessageEventArgs e)
    {
        EventChanged?.Invoke(this, e);
    }

    public class MessageEventArgs(string text) : EventArgs
    {
        public readonly string Text = text;
    }
}
