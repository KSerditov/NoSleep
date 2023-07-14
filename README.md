- [Overview](#nosleep-overview)
- [Diagnostics](#diagnostics)
- [Using activity for PIX Robotics](#using-activity-for-pix-robotics)

# NoSleep Overview
.NET code and components to prevent entering sleep/power save mode on Windows for use with RPA tools or standalone.

# Diagnostics
Before applying the code or integrating it into your solution, it is better to make sure that you really having the sleep/power save issue. To do so, use pre-compiled executables from [Executables](./NoSleep.Releases/Executables/) folder:
1. Copy the executable that fits your installed .NET Runtime.
2. Launch it from the command line using the following syntax:
```
NoSleep.Executable.exe --listen-only
```
You should see something like this:
```
7/14/2023 11:04:07 PM +03:00: Initiating awaker...
7/14/2023 11:04:07 PM +03:00: System events listener has been started
7/14/2023 11:04:07 PM +03:00: Awaker is not started per --listen-only argument
Press ENTER to shutdown.
```
3. Wait required time so that your problem is reproduced and machine goes to sleep or locks or enters power save mode.
4. Unlock the machine and study the console output - in best case scenario you should see messages about entering power save mode or locked screen.
5. Press ENTER to stop the execution.
6. Launch without --listen-only:
```
NoSleep.Executable.exe --listen-only
```
You should see the following:
```
7/14/2023 11:08:22 PM +03:00: Initiating awaker...
7/14/2023 11:08:22 PM +03:00: System events listener has been started
7/14/2023 11:08:22 PM +03:00: Awaker has been started
Press ENTER to shutdown.
```
7. Wait the required time. If the issue is not reproduced - go ahead and integrate this component into your solution.

# Using activity for PIX Robotics
There is pre-compiled activity for PIX Robotics that can be directly used.
1. Copy content of [PIX Libraries](./NoSleep.Releases/Libs.PIX/) into PIX RPA installation folder.
2. Restart the PIX Studio and you should see the new activities:
   
   ![image](https://github.com/KSerditov/NoSleep/assets/3009597/209cd8d5-95fc-4ab6-b748-5fc8fd67cb2a)

3. Use NoSleep Launcher in the beginning of execution and call NoSleep Stopped in the very end (preferrably in final Finally block):
   
   ![image](https://github.com/KSerditov/NoSleep/assets/3009597/46654b8d-bb25-4476-981f-acc5d31d6648)

5. You can also use PIX-DemoProject to validate if it works (don't forget to adjust number of iterations and duration of the Waiting block to cover the time required to reproduce the issue)
