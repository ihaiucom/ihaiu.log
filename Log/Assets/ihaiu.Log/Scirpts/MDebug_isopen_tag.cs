using UnityEngine;
using System.Collections;
using UnityEngine.Internal;

public partial class MDebug 
{
	#region Log
	public static void Log(bool isopen, object tag, object message)
	{

	}


	public static void Log (bool isopen, object tag, object message, Object context)
	{

	}

	public static void LogFormat (bool isopen, object tag, string format, params object[] args)
	{

	}

	public static void LogFormat (bool isopen, object tag, Object context, string format, params object[] args)
	{
	}
	#endregion


	#region LogWarning
	public static void LogWarning (bool isopen, object tag, object message)
	{
	}

	public static void LogWarning (bool isopen, object tag, object message, Object context)
	{

	}

	public static void LogWarningFormat (bool isopen, object tag, string format, params object[] args)
	{
	}

	public static void LogWarningFormat (bool isopen, object tag, Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogError
	public static void LogError (bool isopen, object tag, object message)
	{
	}

	public static void LogError (bool isopen, object tag, object message, Object context)
	{
	}

	public static void LogErrorFormat (bool isopen, object tag, string format, params object[] args)
	{
	}

	public static void LogErrorFormat (bool isopen, object tag, Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogException
	public static void LogException (bool isopen, object tag, System.Exception exception)
	{
	}

	public static void LogException (bool isopen, object tag, System.Exception exception, Object context)
	{
	}

	#endregion



	#region Assert
	public static void Assert (bool isopen, object tag, bool condition)
	{
	}

	public static void Assert (bool isopen, object tag, bool condition, string message)
	{
	}

	public static void Assert (bool isopen, object tag, bool condition, object message)
	{
	}

	public static void Assert (bool isopen, object tag, bool condition, Object context)
	{
	}

	public static void Assert (bool isopen, object tag, bool condition, string message, Object context)
	{
	}

	public static void Assert (bool isopen, object tag, bool condition, object message, Object context)
	{
	}

	public static void AssertFormat (bool isopen, object tag, bool condition, Object context, string format, params object[] args)
	{
	}

	public static void AssertFormat (bool isopen, object tag, bool condition, string format, params object[] args)
	{
	}
	#endregion






	#region Draw
	public static void DrawLine (bool isopen, object tag, Vector3 start, Vector3 end)
	{
	}

	public static void DrawLine (bool isopen, object tag, Vector3 start, Vector3 end, Color color)
	{
	}

	public static void DrawLine (bool isopen, object tag, Vector3 start, Vector3 end, Color color, float duration)
	{
	}

	public static void DrawLine (bool isopen, object tag, Vector3 start, Vector3 end, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}

	public static void DrawRay (bool isopen, object tag, Vector3 start, Vector3 dir)
	{
	}

	public static void DrawRay (bool isopen, object tag, Vector3 start, Vector3 dir, Color color)
	{
	}

	public static void DrawRay (bool isopen, object tag, Vector3 start, Vector3 dir, Color color, float duration)
	{
	}

	public static void DrawRay (bool isopen, object tag, Vector3 start, Vector3 dir, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}
	#endregion
}
