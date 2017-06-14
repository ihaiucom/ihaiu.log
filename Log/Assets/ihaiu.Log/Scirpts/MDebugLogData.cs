using UnityEngine;
using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;


public partial class MDebug 
{
	[System.Serializable]
	public class LogData
	{
		private bool 	inpool = false;
		public int 		relation = 0;

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

		[SerializeField]
		public bool         isUnhandledException = false;

	    public override string ToString()
	    {
	        return string.Format("{0} isThread={6} logType={1}, flagId={2}, tag={3}, msg={4}, stackTrace={5}\n\n", datetime, logType, flagId, tag, msg, stackTrace, isThread);
	    }


		public void Print()
		{
			switch(logType)
			{
			case LogType.Assert:
			case LogType.Error:
			case LogType.Exception:
				UnityEngine.Debug.LogError(this);
				break;
			case LogType.Warning:
				UnityEngine.Debug.LogWarning(this);
				break;
			case LogType.Log:
				UnityEngine.Debug.Log(this);
				break;
			}

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
	        datetime    			= null;
	        flagId      			= 0;
	        tag         			= null;
	        msg         			= null;
	        stackTrace  			= null;
			isThread    			= false;
			isUnhandledException    = false;
	    }

	    public void Reset()
	    {
	        Clear();
	        SetDatetime();
	    }

		public void Despawn()
		{
			Despawn(this);
		}


		/// <summary>
		/// 日志数据对象池
		/// </summary>
		private static Queue<LogData> pool = new Queue<LogData>();

		public static LogData Spawn()
		{
			LogData item;
			if(pool.Count > 0)
			{
				item = pool.Dequeue();
				item.inpool = false;
			}
			else
			{
				item = new LogData();
			}
			return item;
		}

		public static void Despawn(LogData item)
		{
			if(!item.inpool && item.relation <= 0)
			{
				item.inpool = true;
				item.Clear();
				pool.Enqueue(item);
			}
		}
	}
}
