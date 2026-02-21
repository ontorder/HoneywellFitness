using Microsoft.Win32.SafeHandles;
using static HoneywellFitness.TextUi.LocalExt;

namespace HoneywellFitness.TextUi;

public sealed class ConsoleReader
{
    private SafeFileHandle _consoleHandle = new();

    public void Init()
    {
        _consoleHandle = Windows.Win32.PInvoke.GetStdHandle_SafeHandle(STD_HANDLE.STD_INPUT_HANDLE);

        Console.CursorVisible = false;
        var consoleHandle = Windows.Win32.PInvoke.GetStdHandle_SafeHandle(STD_HANDLE.STD_INPUT_HANDLE);
        var scmSucc = Windows.Win32.PInvoke.SetConsoleMode(consoleHandle, CONSOLE_MODE.ENABLE_INSERT_MODE |
            CONSOLE_MODE.ENABLE_PROCESSED_INPUT | CONSOLE_MODE.ENABLE_VIRTUAL_TERMINAL_INPUT | CONSOLE_MODE.ENABLE_WINDOW_INPUT);
        if (scmSucc == false) throw new Exception("setconsolemode failed");
    }

    public StdinValue ReadInput()
    {
        var state = ReadState.Initial;
        StdinValue? parsed = null;

        do
        {
            var kp = Console.ReadKey(intercept: true);
            switch (state)
            {
                case ReadState.Initial:
                    if (kp.KeyChar == '\x1b')
                    {
                        if (AnyOtherInput())
                        {
                            state = ReadState.VtEscape;
                            break;
                        }
                        return new(default, isMeta: true, ConsoleKey.Escape);
                    }

                    return kp.KeyChar switch
                    {
                        '\r' => new StdinValue(kp.KeyChar, isMeta: true, ConsoleKey.Enter),
                        ' ' => new StdinValue(kp.KeyChar, isMeta: true, ConsoleKey.Spacebar),
                        '\n' => new StdinValue(kp.KeyChar, isMeta: true, ConsoleKey.Enter),
                        _ => new StdinValue(kp.KeyChar, isMeta: false, default)
                    };

                case ReadState.VtEscape:
                    state = kp.KeyChar switch
                    {
                        '[' => ReadState.VtBracket,
                        _ => ReadState.VtNonBracket,
                    };
                    break;

                case ReadState.VtBracket:
                    (state, parsed) = kp.KeyChar switch
                    {
                        '5' => (ReadState._3CharSequence, new(default, isMeta: true, ConsoleKey.PageUp)),
                        '6' => (ReadState._3CharSequence, new(default, isMeta: true, ConsoleKey.PageDown)),
                        'A' => (ReadState.Initial, new StdinValue(default, isMeta: true, ConsoleKey.UpArrow)),
                        'B' => (ReadState.Initial, new StdinValue(default, isMeta: true, ConsoleKey.DownArrow)),
                        'C' => (ReadState.Initial, new StdinValue(default, isMeta: true, ConsoleKey.RightArrow)),
                        'D' => (ReadState.Initial, new StdinValue(default, isMeta: true, ConsoleKey.LeftArrow)),
                        'F' => (ReadState.Initial, new StdinValue(default, isMeta: true, ConsoleKey.End)),
                        'H' => (ReadState.Initial, new StdinValue(default, isMeta: true, ConsoleKey.Home)),
                        _ => ThrowHelper<(ReadState, StdinValue?)>(),
                    };
                    break;

                case ReadState._3CharSequence:
                    state = ReadState.Initial;
                    switch (kp.KeyChar)
                    {
                        case '~': break;
                        default: ThrowHelper<(ReadState, StdinValue?)>(); break;
                    }
                    break;
            }
        }
        while (parsed == null);
        return parsed.Value;
    }

    private bool AnyOtherInput()
    {
        var data = new INPUT_RECORD[9];
        var succ = Windows.Win32.PInvoke.PeekConsoleInput(_consoleHandle, data, out var nEvents);
        var keydata = data.Where(static _ => _.EventType == 1);
        return keydata.Any();
    }
}

file enum ReadState { Initial, VtEscape, VtBracket, VtNonBracket, _3CharSequence }

file static class LocalExt
{
    public static T ThrowHelper<T>() => throw new NotImplementedException();
}
