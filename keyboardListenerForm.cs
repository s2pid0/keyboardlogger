using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Windows.Forms;

public class KeyboardListenerForm : Form
{
    private readonly Subject<KeyboardEvent> _subject;
    private readonly List<KeyboardEvent> _eventLog;

    public KeyboardListenerForm(Subject<KeyboardEvent> subject, List<KeyboardEvent> eventLog)
    {
        _subject = subject;
        _eventLog = eventLog;
        this.KeyPreview = true;
        this.KeyDown += OnKeyDown;
        this.KeyUp += OnKeyUp;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        var keyboardEvent = new KeyboardEvent(e.KeyCode, KeyEventType.KeyDown);
        _subject.OnNext(keyboardEvent);
        _eventLog.Add(keyboardEvent);   

        // Завершение работы по комбинации Ctrl+Q
        if (e.KeyCode == Keys.Q && e.Control)
        {
            _subject.OnCompleted();
            this.Close();
        }
    }

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        var keyboardEvent = new KeyboardEvent(e.KeyCode, KeyEventType.KeyUp);
        _subject.OnNext(keyboardEvent);
        _eventLog.Add(keyboardEvent);
    }
}   

