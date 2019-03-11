using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{
	public Transform target;
	Vector3 newPosCam;
	public int camSpeed;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		newPosCam = new Vector3 (target.transform.position.x, target.transform.position.y + 1.5f, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPosCam, camSpeed * Time.deltaTime);
		if(transform.position.x <= 5.9)
		{
			transform.position = new Vector3(5.9f, transform.position.y, transform.position.z);
		}
	}
}
