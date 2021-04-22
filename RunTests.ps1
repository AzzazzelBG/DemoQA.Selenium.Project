dotnet test src\DemoQA.Selenium.Tests\DemoQA.Selenium.Tests.csproj -l:"trx;LogFileName=TestResults.trx"
Start-Process -NoNewWindow "./tools/TrxReporter.exe" -ArgumentList "-i ./src/DemoQA.Selenium.Tests/TestResults/TestResults.trx -o ./src/DemoQA.Selenium.Tests/TestResults/TestResults.html" -Wait
Invoke-Expression ./src/DemoQA.Selenium.Tests/TestResults/TestResults.html

Read-Host -Prompt "Press Enter to exit"
