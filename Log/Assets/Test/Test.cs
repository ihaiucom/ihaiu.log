using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

public class Test : MonoBehaviour {


    public class LogReceiver
    {
        private LogFile     file;

        public LogReceiver()
        {
            string path = "logreceiver.txt";
            #if !UNITY_EDITOR && !UNITY_STANDALONE
            path = Application.persistentDataPath + "/" + path;
            #endif

            file = new LogFile(path);
        }

        public LogReceiver(LogFile file)
        {
            this.file = file;
        }

        public void Start()
        {
            Application.logMessageReceived          += LogReceived;
            Application.logMessageReceivedThreaded  += LogThreadReceived;
        }

        private void LogReceived(string condition, string stackTrace, LogType type)
        {
            file.LogReceived(condition, stackTrace, type);
        }


        private void LogThreadReceived(string condition, string stackTrace, LogType type)
        {
            file.LogThreadReceived(condition, stackTrace, type);
        }
    }


    public class LogHandle : ILogHandler
    {
        private LogFile     file;
        private ILogHandler defaultLogHandler = Debug.logger.logHandler;
        public bool         enableDefault     = true;


        public LogHandle()
        {
            string path = "loghandler.txt";
            #if !UNITY_EDITOR && !UNITY_STANDALONE
            path = Application.persistentDataPath + "/" + path;
            #endif

            file = new LogFile(path);
        }

        public LogHandle(LogFile file)
        {
            this.file = file;
        }

        public void Start()
        {
            Debug.logger.logHandler = this;
        }

        public void LogFormat (LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            file.LogFormat(logType, context, format, args);
            if (enableDefault)
            {
                defaultLogHandler.LogFormat(logType, context, format, args);
            }
        }

        public void LogException (Exception exception, UnityEngine.Object context)
        {
            file.LogException (exception, context);

            if (enableDefault)
            {
                defaultLogHandler.LogException (exception, context);
            }
        }
    }


    public class LogFile
    {
        public string           path;
        private FileStream      fileStream;
        private StreamWriter    streamWriter;
        private MDebugCacheItem item = new MDebugCacheItem();
        public LogFile(string path)
        {
            this.path = path;

            fileStream      = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            streamWriter    = new StreamWriter (fileStream);
        }

        public void LogFormat (LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            item.Reset();
            item.logType    = logType;
            item.msg        = String.Format(format, args);
            Log(item);
        }

        public void LogException (Exception exception, UnityEngine.Object context)
        {

            item.Reset();
            item.logType    = LogType.Exception;
            item.msg        = context + "\n" + exception.ToString();
            Log(item);
        }

        public void LogReceived(string condition, string stackTrace, LogType type)
        {
            item.Reset();
            item.logType    = type;
            item.msg        = condition;
            item.stackTrace = stackTrace;
            Log(item);
        }


        public void LogThreadReceived(string condition, string stackTrace, LogType type)
        {
            item.Reset();
            item.logType    = type;
            item.msg        = condition;
            item.stackTrace = stackTrace;
            item.isThread   = true;
            Log(item);
        }

		public void UnhandledExceptionEventHandler (object sender, UnhandledExceptionEventArgs e)
		{
			item.Reset();
			item.logType    			= LogType.Exception;
			item.msg        			= string.Format("sender={0}\n e={1}", sender, e);
			item.isUnhandledException   = true;
			Log(item);
		}

        public void Log(MDebugCacheItem item)
        {
            streamWriter.WriteLine ( item.ToString() );
            streamWriter.Flush ();
        }
    }





	public LogType filterLogType = LogType.Assert | LogType.Error | LogType.Exception;
	// Use this for initialization
	void Start () {
//		Debug.logger.filterLogType = LogType.Assert | LogType.Error;

//        Application.logMessageReceived += _OnLogCallbackHandler;
	
        logReciver  = new LogReceiver();
        logHandle   = new LogHandle();

		System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventHandler;
	}

	private LogFile unhandleFile;
	void UnhandledExceptionEventHandler (object sender, UnhandledExceptionEventArgs e)
	{
		if(unhandleFile == null) unhandleFile = new LogFile("logunhandled.txt");
		unhandleFile.UnhandledExceptionEventHandler(sender, e);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private LogReceiver      logReciver ;
    private LogHandle        logHandle  ;

	void OnGUI()
	{
		if(GUI.Button(new Rect(10, 10, 100, 50), "Assert Ture"))
		{
			Debug.Assert(true, "TestAssert true");
		}


		if(GUI.Button(new Rect(10, 70, 100, 50), "Assert Ture"))
		{
			Debug.Assert(false, "TestAssert false");
		}


		if(GUI.Button(new Rect(10, 140, 100, 50), "Assert Ture gameObject"))
		{
			Debug.Assert(false, "TestAssert false", GameObject.Find("Main Camera"));
		}



        if(GUI.Button(new Rect(10, 210, 100, 50), "Log"))
        {
            Debug.Log("Hello Log");
        }



        if(GUI.Button(new Rect(10, 280, 100, 50), "LogError"))
        {
            Debug.LogError("Hello LogError");
        }


        if(GUI.Button(new Rect(10, 350, 100, 50), "LogException"))
        {
            Debug.LogException(new Exception("Hello LogException"));
        }



        if(GUI.Button(new Rect(10, 350, 100, 50), "LogException"))
        {
            throw(new Exception("Hello Exception"));
        }

        if(GUI.Button(new Rect(10, 420, 100, 50), "Error"))
        {
            Camera camera = null;
            camera.gameObject.name = "";
        }


        if(GUI.Button(new Rect(140, 10, 150, 50), "LogReceiver Start"))
        {
            logReciver.Start();
        }


        if(GUI.Button(new Rect(320, 10, 150, 50), "LogHandle Start"))
        {
            logHandle.Start();
        }


        if(GUI.Button(new Rect(320, 70, 150, 50), "LogHandle enableDefault:" + (logHandle != null ? logHandle.enableDefault.ToString() : "null") ) )
        {
            logHandle.enableDefault = !logHandle.enableDefault;
        }




		if(GUI.Button(new Rect(500, 10, 150, 50), "Show"))
		{
			GameObject.Find("Reporter").GetComponent<Reporter>().show = true;
		}
	}


}
