using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MDebug 
{
	public class FlagData
	{
		[SerializeField]
		public int 		id;

		[SerializeField]
		public string 	tag;

		[SerializeField]
		public bool 	isopen;



		public FlagData()
		{
		}


		public FlagData(int id, string tag, bool isopen)
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
}
