using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipDay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(1))
		{
			skip();
		}
	}

	public void skip()
	{
		DayCounter.NextDay();
		DayCounter.resetTick();
	}
}
