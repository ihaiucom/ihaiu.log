using UnityEngine;
using System.Collections;
using UnityEngine.Internal;

public partial class MDebug 
{
	public static MDebug.LogHandle      logHandle  	= new MDebug.LogHandle();
    public static MDebug.Config      	config  	= new MDebug.Config();
	public static MDebug.LogCache       cache   	= new MDebug.LogCache();
	public static MDebug.LogFile       	file   		= new MDebug.LogFile();

	#region Log
	public static void Log(object message)
	{
	}


	public static void Log (object message, Object context)
	{
		
	}

	public static void LogFormat (string format, params object[] args)
	{
		
	}

	public static void LogFormat (Object context, string format, params object[] args)
	{
	}
	#endregion


	#region LogWarning
	public static void LogWarning (object message)
	{
	}

	public static void LogWarning (object message, Object context)
	{
		
	}

	public static void LogWarningFormat (string format, params object[] args)
	{
	}

	public static void LogWarningFormat (Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogError
	public static void LogError (object message)
	{
	}

	public static void LogError (object message, Object context)
	{
	}

	public static void LogErrorFormat (string format, params object[] args)
	{
	}

	public static void LogErrorFormat (Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogException
	public static void LogException (System.Exception exception)
	{
	}

	public static void LogException (System.Exception exception, Object context)
	{
	}

	#endregion



	#region Assert
	public static void Assert (bool condition)
	{
	}

	public static void Assert (bool condition, string message)
	{
	}

	public static void Assert (bool condition, object message)
	{
	}

	public static void Assert (bool condition, Object context)
	{
	}

	public static void Assert (bool condition, string message, Object context)
	{
	}

	public static void Assert (bool condition, object message, Object context)
	{
	}

	public static void AssertFormat (bool condition, Object context, string format, params object[] args)
	{
	}

	public static void AssertFormat (bool condition, string format, params object[] args)
	{
	}
	#endregion






	#region Draw
	public static void DrawLine (Vector3 start, Vector3 end)
	{
	}

	public static void DrawLine (Vector3 start, Vector3 end, Color color)
	{
	}

	public static void DrawLine (Vector3 start, Vector3 end, Color color, float duration)
	{
	}

	public static void DrawLine (Vector3 start, Vector3 end, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}

	public static void DrawRay (Vector3 start, Vector3 dir)
	{
	}

	public static void DrawRay (Vector3 start, Vector3 dir, Color color)
	{
	}

	public static void DrawRay (Vector3 start, Vector3 dir, Color color, float duration)
	{
	}

	public static void DrawRay (Vector3 start, Vector3 dir, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}
	#endregion
}
