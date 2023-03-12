using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ILogger
{
    public string FileFormat { get; }
    public string FullPathToLog { get; }
    public void Log(string message);
}
