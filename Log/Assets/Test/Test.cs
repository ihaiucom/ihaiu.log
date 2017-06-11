using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public LogType filterLogType = LogType.Assert | LogType.Error | LogType.Exception;
	// Use this for initialization
	void Start () {
		Debug.logger.filterLogType = LogType.Assert | LogType.Error;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(10, 10, 100, 50), "Assert Ture"))
		{
			Debug.Assert(true, "TestAssert true");
		}


		if(GUI.Button(new Rect(10, 70, 100, 50), "Assert Ture"))
		{
			Debug.Assert(false, "TestAssert false");
		}


		if(GUI.Button(new Rect(10, 140, 100, 50), "Assert Ture gameObject"))
		{
			Debug.Assert(false, "TestAssert false", GameObject.Find("Main Camera"));
		}
	}
}
