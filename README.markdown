# Hazware Driver

This is a simple console application that utilizes MEF to run an application class 
derived from IRunnableApplication. This is used for running application code that 
might be hosted in a service, web application, or a WinForm / WPF applications. 

This is used mainly for testing in which I need a running console for 
logging. I found myself writing similar code to drive my apps during various stages
of development, and decided to just wrap it up into its own project.

To host a runnable application, build an assembly with a class derived from
IRunnableApplication or RunnableApplicationBase. Decorate the class using
[Export(typeof(IRunnableApplication))]. Place this assembly in the same directory 
as the ConsoleDriver application.

Thats it.