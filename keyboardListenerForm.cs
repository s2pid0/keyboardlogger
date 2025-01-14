// File: KeyboardListenerForm.cs
using System;
using System.Reactive.Subjects;
using System.Windows.Forms;

public class KeyboardListenerForm : Form
{
    private readonly Subject<KeyboardEvent> _subject;

    public KeyboardListenerForm(Subject<KeyboardEvent> subject)
    {
        _subject = subject;
        this.KeyPreview = true;
        this.KeyDown += OnKeyDown;
        this.KeyUp += OnKeyUp;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        var keyboardEvent = new KeyboardEvent(e.KeyCode, KeyEventType.KeyDown);
        _subject.OnNext(keyboardEvent);

        // Завершение работы по комбинации Ctrl+Shift+Q
        if (e.KeyCode == Keys.Q && e.Control && e.Shift)
        {
            _subject.OnCompleted();
            this.Close();
        }
    }

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        var keyboardEvent = new KeyboardEvent(e.KeyCode, KeyEventType.KeyUp);
        _subject.OnNext(keyboardEvent);
    }
}   