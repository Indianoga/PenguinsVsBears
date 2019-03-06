using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	[SerializeField]
	GameObject target;
	[SerializeField]
	LayerMask whatIsPlayer;
	[SerializeField]
	EnemyType enemyType;
	Vector3 walkControl;
	float speed;
	bool doAttack;	

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine("Action");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator Action()
	{
		StartCoroutine ("EnemyAttackSytem");
		while (true)
		{
			yield return null;
			Walk();
		}
	}
	void Walk()
	{
		if(transform.position.x > target.transform.position.x)
		{
			walkControl = new Vector3(target.transform.position.x + 0.5f,target.transform.position.y,target.transform.position.z);
		}
		else if (transform.position.x < target.transform.position.x)
		{
			walkControl = new Vector3(target.transform.position.x - 0.5f,target.transform.position.y,target.transform.position.z);
		}
		if(enemyType.enemyTypeID == 1)
		{
			transform.position = Vector2.Lerp(transform.position,walkControl,0.05f );
		}
	}
	IEnumerator EnemyAttackSytem()
	{

		yield return null;
		if(doAttack)
		{

		}
	}
}
[System.Serializable]
public class EnemyType 
{
	public int enemyTypeID;

}