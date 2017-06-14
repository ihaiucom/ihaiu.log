using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public partial class MDebug 
{

	public class LogHandle 
	{
		public delegate void LogCallback (LogData logData);
		/** MDebug 消息事件 */
		public event LogCallback 				logDataReceived;

		/** Unity 消息事件 */
		public event Application.LogCallback 	logMessageReceived;

		
		private int 		mainThreadID 	= -1;
		private bool		isReceived 		= false;

		public LogHandle()
		{
			mainThreadID = Thread.CurrentThread.ManagedThreadId;
		}

		/** 启动监听"Unity日志"和"系统奔溃未捕获的日志" */
		public void Start()
		{
			if(isReceived) return;
			isReceived = true;

			Application.logMessageReceived          			+= LogReceived;
			Application.logMessageReceivedThreaded  			+= LogThreadReceived;
			System.AppDomain.CurrentDomain.UnhandledException 	+= UnhandledExceptionEventHandler;
		}

		/** 停止监听"Unity日志"和"系统奔溃未捕获的日志" */
		public void Stop()
		{
			isReceived = false;
			Application.logMessageReceived          			-= LogReceived;
			Application.logMessageReceivedThreaded  			-= LogThreadReceived;
			System.AppDomain.CurrentDomain.UnhandledException 	-= UnhandledExceptionEventHandler;
		}


		/** 接收MDebug的消息 */
		public void LogRecived(LogData data)
		{
			#if UNITY_EDITOR
			bool tmp = this.isReceived;
			if(tmp) Stop();
			data.Print();
			#endif
			if(logDataReceived != null)
			{
				logDataReceived(data);
			}
			#if UNITY_EDITOR
			if(tmp) Start();
			#endif
		}

		/** 接收Unity的消息 */
		private void LogReceived(string condition, string stackTrace, LogType type)
		{
			if (this.mainThreadID == Thread.CurrentThread.ManagedThreadId)
			{
				if(logMessageReceived != null)
				{
					logMessageReceived(condition, stackTrace, type);
				}
			}
		}

		/** 接收Unity其他线程的消息 */
		private void LogThreadReceived(string condition, string stackTrace, LogType type)
		{
			if (this.mainThreadID != Thread.CurrentThread.ManagedThreadId)
			{
				if(logMessageReceived != null)
				{
					logMessageReceived(condition, stackTrace, type);
				}
			}
		}

		/** 接收应用奔溃未捕获的消息 */
		private void UnhandledExceptionEventHandler (object sender, UnhandledExceptionEventArgs e)
		{
			if(logMessageReceived != null)
			{
				logMessageReceived( ((Exception)e.ExceptionObject).Message, ((Exception)e.ExceptionObject).StackTrace, LogType.Exception);
			}
		}
	}
}
