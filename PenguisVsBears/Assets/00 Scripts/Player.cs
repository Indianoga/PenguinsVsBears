using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	[SerializeField]
	float bulletVelocity;
	[SerializeField]
	float vel;
	[SerializeField]
	float jumpForce;
	[SerializeField]
	float groundDistance;
	
 	[SerializeField]
 	GameObject bullet1;
	[SerializeField]
	LayerMask whatIsGround;
	bool grounded;
	GameObject bullet;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine("Action");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator Action()
	{
		while (true)
		{
			yield return null;
			ShootingSystem();
			Walk();
		}
	
	}
	void Walk()
	{
		float posX = Input.GetAxis("Horizontal") * vel * Time.deltaTime;
		transform.Translate(posX,0,0);
		RaycastHit2D ground = Physics2D.Raycast(transform.position, -Vector2.up, groundDistance, whatIsGround );
		if(ground.collider != null)
		{
			grounded = true;
			Debug.Log("Is Grounded");
		} 
		else
		{
			Debug.Log("NO Grounded");
			grounded = false;
		}
		
		if(grounded)
		{
			if(Input.GetButtonDown("Vertical"))
			{
				rb.velocity = Vector2.up * jumpForce * Time.deltaTime ;
			}
		}
		

	}
	void ShootingSystem()
	{
		 if (Input.GetButtonDown("Fire1"))
     	{
         Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

         Vector2 direction = (Vector2)((worldMousePos - transform.position));
         direction.Normalize();

         // Creates the bullet locally
         GameObject bullet = (GameObject)Instantiate(bullet1, transform.position + (Vector3)(direction * 0.5f),Quaternion.identity);

         // Adds velocity to the bullet
         bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
    	 }

 	}
	
}
