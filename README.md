# WinML Air Extension

This is an AIR Native Extension for Windows to experiment with [Windows Machine Learning](https://docs.microsoft.com/en-gb/windows/uwp/machine-learning/).

It also serves as a useful reference for how to call UWP APIs from a C# based ANE.

----------

**Getting the Dependencies**

Change directory into /example from the command line and run:
````shell
PS get_dependencies.ps1
````

**Important Notice for Windows Installation!**

The C# binaries(dlls) are now packaged inside the ANE. All of them **need to be deleted** from your AIRSDK.

FreSharp.ane is now a required dependency for Windows.

This ANE was compiled using MS Visual Studio 2015. As such, your ma