using System;
using System.Collections;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Forms;

public class KeyboardEventTracker : IObservable<KeyboardEvent>, IEnumerable<KeyboardEvent>
{
    private readonly Subject<KeyboardEvent> _subject = new Subject<KeyboardEvent>();
    private readonly List<KeyboardEvent> _eventLog = new List<KeyboardEvent>();

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
                Application.Run(new KeyboardListenerForm(_subject, _eventLog));
            });
        }
        catch (Exception ex)
        {
            _subject.OnError(ex);
        }
    }

    public IEnumerator<KeyboardEvent> GetEnumerator()
    {
        return _eventLog.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


}
