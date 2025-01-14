using System;
using System.IO;

public class KeyboardEventSubscriber : IObserver<KeyboardEvent>
{
    private readonly string _filePath;

    public KeyboardEventSubscriber(string filePath)
    {
        _filePath = filePath;
    }

    public void OnNext(KeyboardEvent value)
    {
        File.AppendAllText(_filePath, $"{DateTime.Now}: {value.Key} - {value.EventType}\n");
    }

    public void OnError(Exception error)
    {
        File.AppendAllText(_filePath, $"{DateTime.Now}: Error - {error.Message}\n");
    }

    public void OnCompleted()
    {
        File.AppendAllText(_filePath, $"{DateTime.Now}: Tracking completed.\n");
    }
}