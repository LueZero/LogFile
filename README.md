# LogFile

```C#
var json = new Log(LogTypeEnume.json);
json.createLogFile("D:\\", "test", "{}");
Console.WriteLine(json.getLogFile());
json.deleteLogFile("D:\\", "test");
```