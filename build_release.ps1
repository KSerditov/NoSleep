$targetFrameworks = "net451", "net472", "net6.0", "net7.0", "netcoreapp3.1"
$runtimes = "win-x86", "win-x64"
$project = "./NoSleep/NoSleep.Executable/NoSleep.Executable.csproj"

if (Test-Path "./NoSleep.Releases/Executables") { Remove-Item "./NoSleep.Releases/Executables" -Recurse -Force }

foreach ($framework in $targetFrameworks) {
    foreach ($runtime in $runtimes) {
        dotnet publish $project /p:DebugType=None /p:DebugSymbols=false -c Release -f $framework -r $runtime --no-self-contained -o "./NoSleep.Releases/Executables/$framework/$runtime"
    }
}


if (Test-Path "./NoSleep.Releases/Libs.PIX") { Remove-Item "./NoSleep.Releases/Libs.PIX" -Recurse -Force }
$project_pix = "./NoSleep/Activities.PIX.NoSleep/Activities.PIX.NoSleep.csproj"
foreach ($runtime in $runtimes) {
    dotnet publish $project_pix /p:DebugType=None /p:DebugSymbols=false -c Release -r $runtime -o "./NoSleep.Releases/Libs.PIX/$runtime"
}


