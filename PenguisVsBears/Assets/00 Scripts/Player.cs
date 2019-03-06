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
	float attackDistance;
	
 	[SerializeField]
 	GameObject bullet1;
	[SerializeField]
	LayerMask whatIsGround;
	[SerializeField]
	LayerMask whatIsEnemy;
	bool grounded;
	bool doAttack;
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
			AttackSystem();
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
			
		} 
		else
		{
			
			grounded = false;
		}
		if(Input.GetAxis("Horizontal")> 0)
		{
			transform.localScale = new Vector3(6,6,6);
		}
		else if(Input.GetAxis("Horizontal") < 0)
		{
			transform.localScale = new Vector3(-6,6,6);
		}
		if(grounded)
		{
			if(Input.GetKeyDown(KeyCode.W))
			{
				rb.velocity = Vector2.up * jumpForce * Time.deltaTime ;
			}
		}
		

	}
	void AttackSystem()
	{
		RaycastHit2D attackControl = Physics2D.Raycast(transform.position, Vector2.right, attackDistance, whatIsEnemy );
		RaycastHit2D attackControl2 = Physics2D.Raycast(transform.position, -Vector2.right, attackDistance, whatIsEnemy );
		
		if(attackControl.collider != null || attackControl2.collider != null )
		{
			doAttack = true;
			
		}
		else
		{
			doAttack = false;
		}
		
		if(!doAttack)
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
		
		else
		{
			
		}
		

 	}
	
}
