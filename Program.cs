// File: Program.cs
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var tracker = new KeyboardEventTracker();

        // Подписчик 1: Логирует события в файл
        var subscriber1 = new KeyboardEventSubscriber("log1.txt");
        tracker.Subscribe(subscriber1);

        // Подписчик 2: Логирует события в другой файл
        var subscriber2 = new KeyboardEventSubscriber("log2.txt");
        tracker.Subscribe(subscriber2);

        // Запуск трекера в отдельном потоке
        var trackerTask = tracker.StartTrackingAsync();

        var consoleSubscriber = new ConsoleKeyboardEventSubscriber();
        tracker.Subscribe(consoleSubscriber);

        Console.WriteLine("Нажмите Ctrl+Q для завершения работы.");

        // Ожидание завершения трекера
        await trackerTask;
    }
}