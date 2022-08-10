# LogFile

```C#
var json = new Logger(LogTypeEnum.Json, "D:\\", "test");

json.SetLogFileContent("{}");

json.CreateLogFile();

Console.WriteLine(json.GetLogFileContent());

json.DeleteLogFile();
```