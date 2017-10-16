This is a simple C# program that contains SQL injection vulnerabilities. You need to have Visual Studio 2017, Fortify Package for Visual Studio 2017, and the .NET Framework 4.5.1 installed.
You can translate and scan the solution from the command line:
1. Start a Developer Command Prompt for Visual Studio 2017 window.  
2. Change to this directory (VS2017\Sample1) and run the following commands:
  $ sourceanalyzer -b cs-sample -clean
  $ sourceanalyzer -b cs-sample devenv Sample1.sln /REBUILD Debug
  $ sourceanalyzer -b cs-sample -scan
Alternatively, you can translate and scan the solution from Visual Studio:
1. In Visual Studio 2017, open Sample1\Sample1.sln.
2. Select Fortify > Analyze Solution.
NOTE: If you do not have the Fortify menu, you have not installed the Fortify Package for Visual Studio.

If you have MSBuild 15.0 installed, you can translate and scan the solution from the command line:
1. Start the Developer Command Prompt for Visual Studio 2017 window.
2. Change to this directory (VS2017\Sample1) and run the following commands:  
$ sourceanalyzer -b cs-sample -clean$ sourceanalyzer -b cs-sample msbuild Sample1.sln /t:"REBUILD" /p:Configuration="Debug" /p:Platform="Any CPU"$ sourceanalyzer -b cs-sample -scan
Alternatively, you can translate and scan the project binaries:
1. In Visual Studio 2017, open Sample1\Sample1.sln.
2. Select Build > Build Solution.
   You should see the executable Sample1\Sample1.exe and Debug outputs.
4. Start the Developer Command Prompt for Visual Studio 2017 window.4. Change to the Sample1 directory, and then run the following commands:
  $ sourceanalyzer -b cs-sample -clean  $ sourceanalyzer -b cs-sample -dotnet-version 4.5.1 Sample1.exe  $ sourceanalyzer -b cs-sample -scan
After successful completion of the scan, you should see the SQL Injection vulnerabilities and one Unreleased Resource vulnerability. Other categories might also be present, depending on the Fortify Rulepacks used in the scan.
The first SQL Injection vulnerability is reported for SqlDataAdapter object created with an argument to the main function.The second vulnerability shows the tainted data flow through String concatenation and cloning to a call to create a SqlDataAdapter.
The Unreleased Resource vulnerability is reported for the SQLConnection object held by the variable 'conn'. The program initializes this variable with a SQLConnection resource, but never calls the 'Dispose' method on the object. According to the C# API documentation, you should call the 'Dispose' method on these type of objects so that resources are released properly.