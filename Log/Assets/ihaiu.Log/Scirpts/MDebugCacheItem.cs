using UnityEngine;
using System.Collections;
using System.Text;
using System;


[System.Serializable]
public class MDebugCacheItem
{
    [SerializeField]
    public LogType 		logType;

    [SerializeField]
    public string		datetime;

    [SerializeField]
    public int 			flagId;

    [SerializeField]
    public string		tag;

    [SerializeField]
    public string		msg;

    [SerializeField]
    public string       stackTrace;

    [SerializeField]
    public bool         isThread = false;

    public override string ToString()
    {
        return string.Format("{0} isThread={6} logType={1}, flagId={2}, tag={3}, msg={4}, stackTrace={5}\n\n", datetime, logType, flagId, tag, msg, stackTrace, isThread);
    }

    public void SetDatetime()
    {
        StringBuilder sb = StringBuilderCache.Acquire();
        DateTime time = DateTime.Now;        
        sb.Append(time.Hour);
        sb.Append(":");
        sb.Append(time.Minute);
        sb.Append(":");
        sb.Append(time.Second);
        sb.Append(".");
        sb.Append(time.Millisecond);
        sb.Append("-");
        sb.Append(Time.frameCount % 999);     
        datetime = StringBuilderCache.GetStringAndRelease(sb);
    }

    public void Clear()
    {
        datetime    = null;
        flagId      = 0;
        tag         = null;
        msg         = null;
        stackTrace  = null;
        isThread    = false;
    }

    public void Reset()
    {
        Clear();
        SetDatetime();
    }
}
