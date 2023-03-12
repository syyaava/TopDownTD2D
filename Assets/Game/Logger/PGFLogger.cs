using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PGFLogger
{
    public static List<ILogger> Loggers = new List<ILogger>();
    public static void Log(string message)
    {
        foreach (var logger in Loggers)
        {
            logger.Log(message);
        }
    }
}
