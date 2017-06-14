using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;

public partial class MDebug 
{
	public class LogSocketServer 
	{
		private string pathRoot;
		public string PathRoot
		{
			get
			{
				if(string.IsNullOrEmpty(pathRoot))
				{
					pathRoot = Application.persistentDataPath + "/";
					#if UNITY_EDITOR
					pathRoot = Application.dataPath + "/./";
					#elif UNITY_STANDALONE
					pathRoot = Application.dataPath + "/";
					#endif
				}

				return pathRoot;
			}

			set
			{
				pathRoot = value;
			}
		}

		private string allPath;
		public string AllPath
		{
			get
			{
				if(string.IsNullOrEmpty(allPath))
				{
					allPath = PathRoot + "/" + MDebug.config.logfileAll;
				}

				return allPath;
			}

			set
			{
				allPath = value;
			}
		}


		private string errorPath;
		public string ErrorPath
		{
			get
			{
				if(string.IsNullOrEmpty(errorPath))
				{
					errorPath = PathRoot + "/" + MDebug.config.logfileError;
				}

				return errorPath;
			}

			set
			{
				errorPath = value;
			}
		}

		private Queue<LogData> 		pool 			= new Queue<LogData>();
		private Thread 				thread;

		private FileStream      	allFileStream;
		private StreamWriter    	allFileWriter;

		private FileStream      	errFileStream;
		private StreamWriter    	errFileWriter;

		private bool				isReceived 		= false;

	    public void Start()
	    {
			if(isReceived) return;
			isReceived = true;

			MDebug.logHandle.logDataReceived 	+= LogRecived;
			MDebug.logHandle.logMessageReceived += LogThreadReceived;


			allFileStream      	= new FileStream (AllPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			allFileWriter    	= new StreamWriter (allFileStream);


			errFileStream      	= new FileStream (ErrorPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			errFileWriter    	= new StreamWriter (errFileStream);

			ThreadStart threadStart = new ThreadStart(OnThreadLoop);
			thread = new Thread(threadStart);
			thread.Start();
	    }

		public void Stop()
		{
			if(!isReceived) return;
			isReceived = false;

			MDebug.logHandle.logDataReceived 	-= LogRecived;
			MDebug.logHandle.logMessageReceived -= LogThreadReceived;
			thread.Abort();

			allFileWriter.Dispose();
			allFileWriter.Close();
			allFileStream.Dispose();
			allFileStream.Close();
			allFileWriter = null;
			allFileStream = null;



			errFileWriter.Dispose();
			errFileWriter.Close();
			errFileStream.Dispose();
			errFileStream.Close();
			errFileWriter = null;
			errFileStream = null;
		}

		private void OnThreadLoop()
		{
			LogData 	item;
			string		msg;
			bool 		hasLogWrite	 	= false;
			bool 		hasErrorWrite 	= false;

			while(true)
			{
				if(!isReceived) break;

				hasLogWrite 	= false;
				hasErrorWrite 	= false;
				while(pool.Count > 0)
				{
					item = pool.Dequeue();
					msg = item.ToString();

					allFileWriter.WriteLine ( msg );
					hasLogWrite = true;

					switch(item.logType)
					{
					case LogType.Error:
					case LogType.Exception:
					case LogType.Assert:
						errFileWriter.WriteLine ( msg );
						hasErrorWrite = true;
						break;
					}

					item.relation --;
					item.Despawn();
				}

				if(hasLogWrite) allFileWriter.Flush ();
				
				Thread.Sleep(100);
			}
		}


		/** 接收MDebug的消息 */
		private void LogRecived(LogData item)
		{
			item.relation ++;
			pool.Enqueue(item);
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
