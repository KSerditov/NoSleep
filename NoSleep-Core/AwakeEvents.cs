#pragma warning disable CA1416

using System;
using Microsoft.Win32;

public static class AwakeEvents
{
    public static void StartListening()
    {
        SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
    }

    public static void StopListening()
    {
        SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
        SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
    }

    private static void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
        switch (e.Mode)
        {
            case PowerModes.Resume:
                Console.WriteLine($"{DateTimeOffset.Now}: System is resuming from a low power state.");
                break;
            case PowerModes.Suspend:
                Console.WriteLine($"{DateTimeOffset.Now}: System is suspending operation.");
                break;
            case PowerModes.StatusChange:
                Console.WriteLine($"{DateTimeOffset.Now}: System has StatusChange event.");
                break;
        }
    }

    private static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    {
        switch (e.Reason)
        {
            case SessionSwitchReason.SessionLock:
                Console.WriteLine($"{DateTimeOffset.Now}: User has locked the screen.");
                break;
            case SessionSwitchReason.SessionUnlock:
                Console.WriteLine($"{DateTimeOffset.Now}: User has unlocked the screen.");
                break;
        }
    }
}

#pragma warning restore CA1416