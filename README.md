# LogFile

```C#
var json = new Logger(LogTypeEnum.Json);

json.SetLogFileContent("{}");

json.CreateLogFile("D:\\", "test");

Console.WriteLine(json.GetLogFile());

json.DeleteLogFile("D:\\", "test");
```