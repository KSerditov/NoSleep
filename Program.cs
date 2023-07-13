using System;
using System.Runtime.InteropServices;

namespace NoSleep
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("Only Windows platform is supported. Press ENTER to quit.");
                Console.ReadLine();
                return;
            }

            bool listenOnly = Array.Exists(args, arg => arg == "--listen-only");


            Console.WriteLine($"{DateTimeOffset.Now}: Initiating awaker...");
            AwakeEvents.StartListening();
            Console.WriteLine($"{DateTimeOffset.Now}: System events listener has been started");


            if (!listenOnly)
            {
                AwakeUtilities.SetThreadExecutionState(AwakeUtilities.EXECUTION_STATE.ES_CONTINUOUS |
                                                                AwakeUtilities.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                                                                AwakeUtilities.EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                                                                AwakeUtilities.EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
                Console.WriteLine($"{DateTimeOffset.Now}: Awaker has been started");
            } else {
                Console.WriteLine($"{DateTimeOffset.Now}: Awaker is not started per --listen-only argument");
            }
            Console.WriteLine("Press ENTER to shutdown.");

            Console.ReadLine();
            AwakeUtilities.SetThreadExecutionState(AwakeUtilities.EXECUTION_STATE.ES_CONTINUOUS);
            AwakeEvents.StopListening();
            Console.WriteLine($"{DateTimeOffset.Now}: Awaker is shut down successfully.");
        }
    }
}