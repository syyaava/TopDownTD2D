using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TxtFileLogger : ILogger
{
    public string FileFormat { get; } = "txt";

    public string FullPathToLogFolder { get; } = "Log/";
    public string Filename { get; } = "log.txt";
    private string FullPathToLogFile => FullPathToLogFolder + Filename;


    public void Log(string message)
    {
        if(!Directory.Exists(FullPathToLogFile))
            Directory.CreateDirectory(FullPathToLogFile);

        using(var fs = new FileStream(FullPathToLogFile, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var sw = new StreamWriter(fs);
            sw.WriteLine(message);
        }
    }
}
