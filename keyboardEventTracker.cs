using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Forms;

public class KeyboardEventTracker : IObservable<KeyboardEvent>
{
    private readonly Subject<KeyboardEvent> _subject = new Subject<KeyboardEvent>();

    public IDisposable Subscribe(IObserver<KeyboardEvent> observer)
    {
        return _subject.Subscribe(observer);
    }

    public async Task StartTrackingAsync()
    {
        try
        {
            await Task.Run(() =>
            {
                Application.Run(new KeyboardListenerForm(_subject));
            });
        }
        catch (Exception ex)
        {
            _subject.OnError(ex);
        }
    }
}
