using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class MDebug 
{
	[System.Serializable]
	public class Config
	{
		[SerializeField]
		public bool applyByMerge		= true;
		
		[SerializeField]
		public bool enableError			= true;

		[SerializeField]
		public bool enableAssert		= true;

		[SerializeField]
		public bool enableWarning		= true;

		[SerializeField]
		public bool enableLog			= true;

		[SerializeField]
		public bool enableException		= true;

		[SerializeField]
		public bool cacheEnable			= true;
		[SerializeField]
		public int cacheSize			= 100;


		[SerializeField]
		public string logfileAll			= "log_all.txt";
		[SerializeField]
		public string logfileError			= "log_error.txt";


		[SerializeField]
		public List<FlagData>	flags = new List<FlagData>();

		private Dictionary<int, FlagData> flagmap = new Dictionary<int, FlagData>();


		public void SetFlag(int id, bool isopen)
		{
			SetFlag(id, null, isopen);
		}

		public void SetFlag(int id, string tag, bool isopen)
		{
			if(flagmap.ContainsKey(id))
			{
				FlagData flag = flagmap[id];
				flag.isopen = isopen;
				flag.tag = string.IsNullOrEmpty(tag) ? flag.tag : tag;
			}
			else
			{
				FlagData flag = new FlagData(id, tag, isopen);
				flagmap.Add(flag.id, flag);
				flags.Add(flag);
			}
		}

		private void ListToDict()
		{
			foreach(FlagData item in flags)
			{
				if(flagmap.ContainsKey(item.id))
				{
					MDebug.LogErrorFormat(Flags.debug, "MDebugConfig.ListToDict MDebugFlag has id={0}, dict[{0}]={1}, item={1}", item.id, flagmap[item.id], item);
				}
				else
				{
					flagmap.Add(item.id, item);
				}
			}
		}

		public void Apply()
		{
			if(applyByMerge)
			{
				MDebug.config.Merge(this);
			}
			else
			{
				ListToDict();
				MDebug.config = this;
			}
		}

		public void Merge(Config config)
		{
			enableError 		= config.enableError;
			enableAssert 		= config.enableAssert;
			enableWarning 		= config.enableWarning;
			enableLog 			= config.enableLog;
			enableException 	= config.enableException;

			foreach(FlagData item in config.flags)
			{
				if(flagmap.ContainsKey(item.id))
				{
					MDebug.LogFormat(Flags.debug, "MDebugConfig.ListToDict MDebugFlag has id={0}, dict[{0}]={1}, item={1}", item.id, flagmap[item.id], item);
					flagmap[item.id] = item;
				}
				else
				{
					flagmap.Add(item.id, item);
					flags.Add(item);
				}
			}
		}

		public override string ToString ()
		{
			string liststr = "";
			foreach(FlagData item in flags)
			{
				liststr += item.ToString() + "\n";
			}

			return string.Format ("[MDebugConfig enableError={0}, enableAssert={1}, enableWarning={2}, enableLog={4}, enableException={5}] list=\n{6}", 
				enableError, enableAssert, enableWarning, enableLog, enableException, liststr);
		}
	}
}