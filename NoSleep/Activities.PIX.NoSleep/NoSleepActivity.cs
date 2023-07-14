using System;
using BR.Core;
using BR.Core.Attributes;
using NoSleep.Core;

namespace Activities.PIX.NoSleep
{
    [ScreenName("NoSleep Launcher")]
    [Representation("Launch NoSleep activity")]
    [Path("NoSleep")]
    public class NoSleepActivityLauncher : Activity
    {
        public override void Execute(int? optionID)
        {
            AwakeUtilities.SetThreadExecutionState(AwakeUtilities.EXECUTION_STATE.ES_CONTINUOUS |
                                        AwakeUtilities.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                                        AwakeUtilities.EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                                        AwakeUtilities.EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
        }
    }

    [ScreenName("NoSleep Stopper")]
    [Representation("Stop NoSleep activity")]
    [Path("NoSleep")]
    public class NoSleepActivityStopper : Activity
    {
        public override void Execute(int? optionID)
        {
            AwakeUtilities.SetThreadExecutionState(AwakeUtilities.EXECUTION_STATE.ES_CONTINUOUS);
        }
    }
}