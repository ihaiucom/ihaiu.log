using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class MDebug 
{
	public class LogCache 
	{
		private Queue<LogData> 		pool 			= new Queue<LogData>();
		private bool				isReceived 		= false;
	    public void Start()
	    {
			if(isReceived) return;
			isReceived = true;
			MDebug.logHandle.logDataReceived 	+= LogRecived;
			MDebug.logHandle.logMessageReceived += LogThreadReceived;
	    }

		public void Stop()
		{
			isReceived = false;
			MDebug.logHandle.logDataReceived 	-= LogRecived;
			MDebug.logHandle.logMessageReceived -= LogThreadReceived;
		}


		/** 接收MDebug的消息 */
		private void LogRecived(LogData item)
		{
			item.relation ++;
			pool.Enqueue(item);

			if(pool.Count > MDebug.config.cacheSize)
			{
				item = pool.Dequeue();
				item.relation --;
				item.Despawn();
			}
		}



		/** 接收MDebug的消息 */
		private void LogThreadReceived(string condition, string stackTrace, LogType type)
		{
			LogData item = LogData.Spawn();
			item.logType 	= type;
			item.msg 		= condition;
			item.stackTrace = stackTrace;
			item.flagId		= Flags.defaul.id;
			item.tag		= Flags.defaul.tag;
			item.SetDatetime();
			LogRecived(item);
		}
	}
}
