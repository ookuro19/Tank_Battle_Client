using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBEDebug
{
    static public bool EnableLog = true;

    #region Log
    static public void Log(object message)
    {
        Log(message, null);
    }

    static public void Log(object message, Object context)
    {
        if (EnableLog)
        {
            Debug.Log(message, context);
        }
    }

    public static void LogFormat(string format, params object[] args)
    {
        if (EnableLog)
        {
            Debug.LogFormat(format, args);
        }
    }
    #endregion Log

    #region LogError
    static public void LogError(object message)
    {
        LogError(message, null);
    }
    static public void LogError(object message, Object context)
    {
        if (EnableLog)
        {
            Debug.LogError(message, context);
        }
    }
    #endregion LogError

    #region Warning
    static public void LogWarning(object message)
    {
        LogWarning(message, null);
    }

    static public void LogWarning(object message, Object context)
    {
        if (EnableLog)
        {
            Debug.LogWarning(message, context);
        }
    }
    #endregion Warning
}
