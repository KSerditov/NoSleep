$targetFrameworks = "net451", "net472", "net6.0", "net7.0", "netcoreapp3.1"
$runtimes = "win-x86", "win-x64"
$project = "./NoSleep/NoSleep-Core/NoSleep.csproj"

if (Test-Path "./NoSleep-Core-Executables") { Remove-Item "./NoSleep-Core-Executables" -Recurse -Force }

foreach ($framework in $targetFrameworks) {
    foreach ($runtime in $runtimes) {
        dotnet publish $project -c Release -f $framework -r $runtime --no-self-contained -o "./NoSleep-Core-Executables/$framework/$runtime"
    }
}


if (Test-Path "./NoSleep-PIX-Libs") { Remove-Item "./NoSleep-PIX-Libs" -Recurse -Force }
$project_pix = "./NoSleep/Activities.PIX.NoSleep/Activities.PIX.NoSleep.csproj"
dotnet publish $project_pix -c Release -o "./NoSleep-PIX-Libs"