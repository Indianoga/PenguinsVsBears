using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformEffector : MonoBehaviour 
{
	PlatformEffector2D effector2D;
	float waitTime;
	// Use this for initialization
	void Start () 
	{
		effector2D = GetComponent<PlatformEffector2D>();	
	}
	
	// Update is called once per frame
	void Update ()
	 {
		Check();
	 }
	 void Check()
	 {
		if(Input.GetKeyDown(KeyCode.W))
		{
			effector2D.rotationalOffset = 0;

		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			effector2D.rotationalOffset = 180;
		}
	 }
}
