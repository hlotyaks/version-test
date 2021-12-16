echo off

if "%1" == "debug" (
    xcopy .\bin\%1 ..\deploy /y
    GOTO:eof
)

if "%1" == "release" (
    xcopy .\bin\%1 ..\deploy /y
    GOTO:eof  
)

else (
    echo on
    echo provide "debug" or "release" as argument
)