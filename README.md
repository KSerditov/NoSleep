- [Overview](#nosleep-overview)
- [Diagnostics](#diagnostics)
- [Using activity for PIX Robotics](#using-activity-for-pix-robotics)

# NoSleep Overview
NoSleep provides .NET code and components designed to prevent a Windows system from entering sleep or power save mode. It's designed for integration with Robotic Process Automation (RPA) tools, though it can be used as a standalone solution as well.

# Diagnostics
Before you integrate the NoSleep code into your solution, it's crucial to verify that your system is indeed experiencing issues related to sleep or power save modes. To do this, you can use pre-compiled executables from the [Executables](./NoSleep.Releases/Executables/) folder. Follow these steps:

1. Copy the executable that fits your installed .NET Runtime.
2. Launch it from the command line using this command:
```
NoSleep.Executable.exe --listen-only
```
The output should look something like this:
```
7/14/2023 11:04:07 PM +03:00: Initiating awaker...
7/14/2023 11:04:07 PM +03:00: System events listener has been started
7/14/2023 11:04:07 PM +03:00: Awaker is not started per --listen-only argument
Press ENTER to shutdown.
```
3. Let your machine run for the amount of time needed for the problem to manifest. This could be the time it takes for the machine to enter sleep mode, lock, or enter power save mode.
4. After that time has passed, unlock your machine and examine the console output. Ideally, you should see messages about the machine entering power save mode or the screen locking.
5. Press ENTER to stop the execution.
6. Now, launch the application without `--listen-only`:
```
NoSleep.Executable.exe --listen-only
```
The output should be similar to this:
```
7/14/2023 11:08:22 PM +03:00: Initiating awaker...
7/14/2023 11:08:22 PM +03:00: System events listener has been started
7/14/2023 11:08:22 PM +03:00: Awaker has been started
Press ENTER to shutdown.
```
7. Let the machine run for the required duration. If the issue doesn't recur, feel free to integrate NoSleep into your solution.

# Using activity for PIX Robotics
There is pre-compiled activity for PIX Robotics that can be directly used.
1. Copy the contents of [PIX Libraries](./NoSleep.Releases/Libs.PIX/) for target architecture into PIX RPA installation folder.
2. Restart PIX Studio and you'll find new activities:
   
![image](https://github.com/KSerditov/NoSleep/assets/3009597/97bc3501-38e5-4f09-9abe-86fb943de031)

3. At the start of the execution, use the NoSleep Launcher, and call NoSleep Stopper at the end (preferably in the final 'Finally' block):
   
![image](https://github.com/KSerditov/NoSleep/assets/3009597/03461fa8-c6b0-4c10-b17d-4ab6f34ab278)

4. You can also use the [PIX-DemoProject](./PIX-DemoProject) to test if it's working. Remember to adjust the number of iterations and the duration of the 'Waiting' block to cover the time required to reproduce the issue.
