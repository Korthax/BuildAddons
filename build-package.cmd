@echo off

%systemdrive%\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild BuildAddons.sln /nologo /t:Build /p:Configuration=Release /p:Platform="Any Cpu" /v:q

tools\nuget\nuget.exe pack nuget/BuildAddons.nuspec -OutputDirectory releases

