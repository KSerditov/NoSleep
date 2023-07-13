$targetFrameworks = "net451", "net472", "net6.0", "net7.0"
$runtimes = "win-x86", "win-x64"

if (Test-Path "./publish") { Remove-Item "./Executables" -Recurse -Force }

foreach ($framework in $targetFrameworks) {
    foreach ($runtime in $runtimes) {
        dotnet publish -c Release -f $framework -r $runtime --no-self-contained -o "./Executables/$framework/$runtime"
    }
}