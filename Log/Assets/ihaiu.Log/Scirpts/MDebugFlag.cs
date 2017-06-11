using UnityEngine;
using System.Collections;

[System.Serializable]
public class MDebugFlag
{
	[SerializeField]
	public int 		id;

	[SerializeField]
	public string 	tag;

	[SerializeField]
	public bool 	isopen;



	public MDebugFlag()
	{
	}


	public MDebugFlag(int id, string tag, bool isopen)
	{
		this.id		= id;
		this.tag	= tag;
		this.isopen	= isopen;
	}

	public override string ToString ()
	{
		return string.Format ("[MDebugFlag id={0}, tag={1}, isopen={2}]", id, tag, isopen);
	}
}
