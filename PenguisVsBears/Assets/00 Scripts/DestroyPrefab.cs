using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine("DestroyPrefabControl");
	}

	IEnumerator DestroyPrefabControl()
	{
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
