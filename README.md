# unity-csharp-interpreter
Show how to use the new Mono 4.5 backend to interpret code in a running Unity app.

HOWTO

Modify the copy.sh file to suit your install, and run it : it will copy some dlls from Unity install to your Assets directory.
This was tested only with Unity2019.1.0a9 but it should work with other versions that includes mono 4.5.
(the project is setuped to use .NET 4.x in Edit/Project Settings/Scripting Runtime Version and API Compatibility Level)

You can then run the project, it creates a empty GameObject and Log a "Hello World" in the Console.
The project contains a single script.cs file in Assets, that is attached to the main camera.

This scripts compiles at runtime a code string and then interpret it.

![alt text](https://github.com/madlag/unity-csharp-interpreter/blob/master/screenshot.png?raw=true "Logo Title Text 1")


I am releasing this sample as it can be useful to quickly iterate on some code without relaunching the app, load some code from the network, monitor a file system for code changes and then running it asap etc.

(I did something similar with https://github.com/madlag/jarvis a few years ago).

Be careful, if you include this in your project and allows the app user to run its own code, he can do a lot of things...

With great power...
