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

This ANE was compiled using MS Visual Studio 2015. As such, your machine (and user's machines) will need to have Microsoft Visual C++ 2015 Redistributable (x86) runtime installed.

You can download it from here: https://www.microsoft.com/en-us/download/details.aspx?id=48145


This ANE also requires .NET 4.7 Framework. This is included with Windows 10 April Update 2018.

### Prerequisites

You will need:

- Windows 10 October Update 2018 (1809)
- .NET 4.7
- AIRSDK 32
- Visual Studio 2017
 

### References

- [Windows UWP Machine Learning](https://docs.microsoft.com/en-gb/windows/uwp/machine-learning/)
- [How to call Windows 10 APIs in a deskto