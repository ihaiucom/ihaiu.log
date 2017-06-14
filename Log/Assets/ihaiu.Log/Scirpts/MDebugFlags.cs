using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class MDebug 
{
	public partial class Flags
	{
		public static FlagData defaul 		= new FlagData(0		, "Default"		, true);
		public static FlagData debug 		= new FlagData(1		, "Default"		, true);
		public static FlagData main 		= new FlagData(2		, "Main"		, true);
		public static FlagData login 		= new FlagData(3		, "Login"		, true);
		public static FlagData load 		= new FlagData(4		, "Load"		, true);
	}
}
