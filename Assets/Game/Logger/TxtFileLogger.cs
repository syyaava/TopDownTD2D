using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TxtFileLogger : ILogger
{
    public string FileFormat { get; } = "txt";

    public string FullPathToLog { get; } = "Log/log.txt";

    public void Log(string message)
    {
        using(var fs = new FileStream(FullPathToLog, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var sw = new StreamWriter(fs);
            sw.WriteLine(message);
        }
    }
}
