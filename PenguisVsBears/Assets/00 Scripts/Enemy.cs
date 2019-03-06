using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	[SerializeField]
	float snowBearForce;
	[SerializeField]
	GameObject snowBullet;
	[SerializeField]
	GameObject target;
	[SerializeField]
	LayerMask whatIsPlayer;
	[SerializeField]
	EnemyType enemyType;
	Vector3 walkControl;
	float speed;
	bool walkCheckUp;
	bool walkCheckDown;

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

		
		if(enemyType.enemyTypeID == 1)
		{
			if(transform.position.x > target.transform.position.x)
			{
				walkControl = new Vector3(target.transform.position.x + 0.5f,target.transform.position.y,target.transform.position.z);
			}
			else if (transform.position.x < target.transform.position.x)
			{
				walkControl = new Vector3(target.transform.position.x - 0.5f,target.transform.position.y,target.transform.position.z);
			}
		}
		else if (enemyType.enemyTypeID == 2)
		{
			if(transform.position.x > target.transform.position.x)
			{
				walkControl = new Vector3(target.transform.position.x + 4f,target.transform.position.y,target.transform.position.z);
			}
			else if (transform.position.x < target.transform.position.x)
			{
				walkControl = new Vector3(target.transform.position.x - 4f,target.transform.position.y,target.transform.position.z);
			}
		}
		transform.position = Vector2.Lerp(transform.position,walkControl,0.05f );
		
	}
	IEnumerator EnemyAttackSytem()
	{
		
		
		while (true)
		{
			Vector2 direction = (Vector2)(target.transform.position - transform.position);
			direction.Normalize();
			yield return new WaitForSeconds(3f);
			if(enemyType.enemyTypeID == 2)
			{
			
				if(transform.position.x < target.transform.position.x)
				{
					GameObject newSnow = Instantiate(snowBullet,new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity) as GameObject;
					newSnow.GetComponent<Rigidbody2D>().velocity = direction * snowBearForce;
				}
				else if(transform.position.x > target.transform.position.x)
				{
					GameObject newSnow = Instantiate(snowBullet,new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity) as GameObject;
					newSnow.GetComponent<Rigidbody2D>().velocity = direction * snowBearForce;
				}

			}
		}
		
		
	}
}
[System.Serializable]
public class EnemyType 
{
	public int enemyTypeID;

}