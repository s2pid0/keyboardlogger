using System.Windows.Forms;

public class KeyboardEvent
{
    public Keys Key { get; }
    public KeyEventType EventType { get; }

    public KeyboardEvent(Keys key, KeyEventType eventType)
    {
        Key = key;
        EventType = eventType;
    }
}

public enum KeyEventType
{
    KeyDown,
    KeyUp
}
