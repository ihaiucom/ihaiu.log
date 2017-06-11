using UnityEngine;
using System.Collections;
using UnityEngine.Internal;

public partial class MDebug 
{
	#region Log
	public static void Log(object tag, object message)
	{

	}


	public static void Log (object tag, object message, Object context)
	{

	}

	public static void LogFormat (object tag, string format, params object[] args)
	{

	}

	public static void LogFormat (object tag, Object context, string format, params object[] args)
	{
	}
	#endregion


	#region LogWarning
	public static void LogWarning (object tag, object message)
	{
	}

	public static void LogWarning (object tag, object message, Object context)
	{

	}

	public static void LogWarningFormat (object tag, string format, params object[] args)
	{
	}

	public static void LogWarningFormat (object tag, Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogError
	public static void LogError (object tag, object message)
	{
	}

	public static void LogError (object tag, object message, Object context)
	{
	}

	public static void LogErrorFormat (object tag, string format, params object[] args)
	{
	}

	public static void LogErrorFormat (object tag, Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogException
	public static void LogException (object tag, System.Exception exception)
	{
	}

	public static void LogException (object tag, System.Exception exception, Object context)
	{
	}

	#endregion



	#region Assert
	public static void Assert (object tag, bool condition)
	{
	}

	public static void Assert (object tag, bool condition, string message)
	{
	}

	public static void Assert (object tag, bool condition, object message)
	{
	}

	public static void Assert (object tag, bool condition, Object context)
	{
	}

	public static void Assert (object tag, bool condition, string message, Object context)
	{
	}

	public static void Assert (object tag, bool condition, object message, Object context)
	{
	}

	public static void AssertFormat (object tag, bool condition, Object context, string format, params object[] args)
	{
	}

	public static void AssertFormat (object tag, bool condition, string format, params object[] args)
	{
	}
	#endregion






	#region Draw
	public static void DrawLine (object tag, Vector3 start, Vector3 end)
	{
	}

	public static void DrawLine (object tag, Vector3 start, Vector3 end, Color color)
	{
	}

	public static void DrawLine (object tag, Vector3 start, Vector3 end, Color color, float duration)
	{
	}

	public static void DrawLine (object tag, Vector3 start, Vector3 end, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}

	public static void DrawRay (object tag, Vector3 start, Vector3 dir)
	{
	}

	public static void DrawRay (object tag, Vector3 start, Vector3 dir, Color color)
	{
	}

	public static void DrawRay (object tag, Vector3 start, Vector3 dir, Color color, float duration)
	{
	}

	public static void DrawRay (object tag, Vector3 start, Vector3 dir, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}
	#endregion
}
