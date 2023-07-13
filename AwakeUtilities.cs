using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NoSleep
{
    public static class AwakeUtilities
    {
        /*
        private static object _lock = new object();

        private static CancellationTokenSource _cancellationTokenSource;

        public static (bool, string) PreventPowerSave()
        {
            if (Monitor.TryEnter(_lock))
            {
                try
                {
                    if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
                    {
                        return (false, @"Awake thread is already runnning");
                    }

                    _cancellationTokenSource = new CancellationTokenSource();
                    CancellationToken token = _cancellationTokenSource.Token;

                    (new TaskFactory()).StartNew(() =>
                        {
                            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS |
                                                    EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                                                    EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                                                    EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
                        },
                        token
                    );

                    return (true, "Awake thread has been started successfully at " + DateTimeOffset.Now.ToString());
                }
                catch (Exception e)
                {
                    return (false, "Exception occured while starting awake thread: " + e.Message);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
            else
            {
                return (false, "Another thread is currently executing PreventPowerSave.");
            }
        }

        public static void Shutdown()
        {
            lock (_lock)
            {
                _cancellationTokenSource?.Cancel();
            }
        }
        */

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint SetThreadExecutionState(EXECUTION_STATE esFlags);


        [Flags]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }
    }
}