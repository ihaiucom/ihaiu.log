﻿using UnityEngine;
using System.Collections;
using UnityEngine.Internal;

public partial class MDebug 
{
	#region Log
	public static void Log(int flagId, object message)
	{

	}


	public static void Log (int flagId, object message, Object context)
	{

	}

	public static void LogFormat (int flagId, string format, params object[] args)
	{

	}

	public static void LogFormat (int flagId, Object context, string format, params object[] args)
	{
	}
	#endregion


	#region LogWarning
	public static void LogWarning (int flagId, object message)
	{
	}

	public static void LogWarning (int flagId, object message, Object context)
	{

	}

	public static void LogWarningFormat (int flagId, string format, params object[] args)
	{
	}

	public static void LogWarningFormat (int flagId, Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogError
	public static void LogError (int flagId, object message)
	{
	}

	public static void LogError (int flagId, object message, Object context)
	{
	}

	public static void LogErrorFormat (int flagId, string format, params object[] args)
	{
	}

	public static void LogErrorFormat (int flagId, Object context, string format, params object[] args)
	{
	}
	#endregion



	#region LogException
	public static void LogException (int flagId, System.Exception exception)
	{
	}

	public static void LogException (int flagId, System.Exception exception, Object context)
	{
	}

	#endregion



	#region Assert
	public static void Assert (int flagId, bool condition)
	{
	}

	public static void Assert (int flagId, bool condition, string message)
	{
	}

	public static void Assert (int flagId, bool condition, object message)
	{
	}

	public static void Assert (int flagId, bool condition, Object context)
	{
	}

	public static void Assert (int flagId, bool condition, string message, Object context)
	{
	}

	public static void Assert (int flagId, bool condition, object message, Object context)
	{
	}

	public static void AssertFormat (int flagId, bool condition, Object context, string format, params object[] args)
	{
	}

	public static void AssertFormat (int flagId, bool condition, string format, params object[] args)
	{
	}
	#endregion






	#region Draw
	public static void DrawLine (int flagId, Vector3 start, Vector3 end)
	{
	}

	public static void DrawLine (int flagId, Vector3 start, Vector3 end, Color color)
	{
	}

	public static void DrawLine (int flagId, Vector3 start, Vector3 end, Color color, float duration)
	{
	}

	public static void DrawLine (int flagId, Vector3 start, Vector3 end, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}

	public static void DrawRay (int flagId, Vector3 start, Vector3 dir)
	{
	}

	public static void DrawRay (int flagId, Vector3 start, Vector3 dir, Color color)
	{
	}

	public static void DrawRay (int flagId, Vector3 start, Vector3 dir, Color color, float duration)
	{
	}

	public static void DrawRay (int flagId, Vector3 start, Vector3 dir, [DefaultValue ("Color.white")] Color color, [DefaultValue ("0.0f")] float duration, [DefaultValue ("true")] bool depthTest)
	{
	}
	#endregion
}
