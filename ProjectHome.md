# SharpFann #
C# 4.0 Binding for the FANN http://leenissen.dk/fann/wp/ (Fast Artificial Neural Network Library)


## Summary ##

This is pretty much a direct port from the Java binding project FannJ http://code.google.com/p/fannj. It is written in .NET 4.0 only because I was playing around with the Parallels features.  If you need it in a lower version it is easy to just rip out the parallels code.

## Note ##
If you have found your way here you should also take a look at this project: http://code.google.com/p/fanndotnetwrapper/.  This is a C++ wrapper assembly that you can directly reference into the solution (should work for any .NET language).  I suggest having a browse of the SharpFann project for examples using FANN directly with C#, but use the other wrapper for your projects if you can.

## Requirements ##
This project uses pinvoke to call methods on the FANN Dll.  You will need to download the source code from the FANN website and compile the Dll.  This is easy even if you don't know C.  Simply download the code, open the project in this directory: fann-2.1.0\MicrosoftWindowsDll.

Build the project under ReleaseFloatMultiThreaded.

Add the newly built Dll to the C# path and you are good to go.  Also make sure the Dll file is named: fannfloatMT.dll
Either that or alter the DllImport commands in the Trainer and BaseFann class files.

## License ##
The license for this project should be whatever the two projects I based this on are.  (FannJ and FANN).  If I have screwed up the license requirements of this code in any way let me know and I will fix it.
