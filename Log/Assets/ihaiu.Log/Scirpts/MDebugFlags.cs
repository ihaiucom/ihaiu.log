using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class MDebugFlags
{
	public static MDebugFlag defaul 	= new MDebugFlag(0		, "Default"		, true);
	public static MDebugFlag debug 		= new MDebugFlag(1		, "Default"		, true);
	public static MDebugFlag main 		= new MDebugFlag(2		, "Main"		, true);
	public static MDebugFlag login 		= new MDebugFlag(3		, "Login"		, true);
	public static MDebugFlag load 		= new MDebugFlag(4		, "Load"		, true);
}
