using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MDebugConfig
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
	public List<MDebugFlag>	list = new List<MDebugFlag>();

	private Dictionary<int, MDebugFlag> dict = new Dictionary<int, MDebugFlag>();


	public void SetFlag(int id, bool isopen)
	{
		SetFlag(id, null, isopen);
	}

	public void SetFlag(int id, string tag, bool isopen)
	{
		if(dict.ContainsKey(id))
		{
			MDebugFlag flag = dict[id];
			flag.isopen = isopen;
			flag.tag = string.IsNullOrEmpty(tag) ? flag.tag : tag;
		}
		else
		{
			MDebugFlag flag = new MDebugFlag(id, tag, isopen);
			dict.Add(flag.id, flag);
			list.Add(flag);
		}
	}

	private void ListToDict()
	{
		foreach(MDebugFlag item in list)
		{
			if(dict.ContainsKey(item.id))
			{
				MDebug.LogErrorFormat(MDebugFlags.debug, "MDebugConfig.ListToDict MDebugFlag has id={0}, dict[{0}]={1}, item={1}", item.id, dict[item.id], item);
			}
			else
			{
				dict.Add(item.id, item);
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

	public void Merge(MDebugConfig config)
	{
		enableError 		= config.enableError;
		enableAssert 		= config.enableAssert;
		enableWarning 		= config.enableWarning;
		enableLog 			= config.enableLog;
		enableException 	= config.enableException;

		foreach(MDebugFlag item in config.list)
		{
			if(dict.ContainsKey(item.id))
			{
				MDebug.LogFormat(MDebugFlags.debug, "MDebugConfig.ListToDict MDebugFlag has id={0}, dict[{0}]={1}, item={1}", item.id, dict[item.id], item);
				dict[item.id] = item;
			}
			else
			{
				dict.Add(item.id, item);
				list.Add(item);
			}
		}
	}

	public override string ToString ()
	{
		string liststr = "";
		foreach(MDebugFlag item in list)
		{
			liststr += item.ToString() + "\n";
		}

		return string.Format ("[MDebugConfig enableError={0}, enableAssert={1}, enableWarning={2}, enableLog={4}, enableException={5}] list=\n{6}", 
			enableError, enableAssert, enableWarning, enableLog, enableException, liststr);
	}
}
