using System;

public class ConsoleKeyboardEventSubscriber : IObserver<KeyboardEvent>
{
    public void OnNext(KeyboardEvent value)
    {
        Console.WriteLine($"{DateTime.Now}: {value.Key} - {value.EventType}");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"{DateTime.Now}: Error - {error.Message}");
    }

    public void OnCompleted()
    {
        Console.WriteLine($"{DateTime.Now}: Tracking completed.");
    }
}
