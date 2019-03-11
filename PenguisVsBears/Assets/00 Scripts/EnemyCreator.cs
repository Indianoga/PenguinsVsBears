using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour 
{
	[SerializeField]
	GameObject[] spawners;
	
	[SerializeField]
	GameObject[] enemyType;

	[SerializeField]
	GameObject playerPrefab;

	[SerializeField]
	AudioSource[] musicGame;
	Player player;

	int levelManager;
	int waveCountControl;
	int enemyCount;
	[HideInInspector]
	public int count;
	int randSpawn;
	[HideInInspector]
	public int safeSpawn;
	[SerializeField]
	GameObject startgame;
	int safeControl;
	

	// Use this for initialization
	void Start () 
	{
		playerPrefab = GameObject.FindGameObjectWithTag("Player");
		player = playerPrefab.GetComponent<Player>();
		musicGame[0].Play();
		
		StartCoroutine("Action");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void StartGame()
	{
		startgame.SetActive(false);
	}
	IEnumerator Action()
	{
		while (true)
		{
			yield return null;
			if(Input.GetKeyDown(KeyCode.Space)) break;
		}
		StartGame();
		musicGame[0].Stop();
		musicGame[1].Play();

		while (true)
		{
			yield return null;
			spawners = GameObject.FindGameObjectsWithTag("spawner");
			WaveCountControl();
			if(player.wavesControl)
			{
				CreateEnemy();
			}
		}
	}

	void WaveCountControl()
	{
		if(player.wavesSystem == 1)
		{
			enemyCount = 2;
			randSpawn = 0;
			safeControl = 1;
		}
		if(player.wavesSystem == 2)
		{
			enemyCount = 5;
			randSpawn = 1;
			safeControl = 2;
		}
		if(player.wavesSystem == 3)
		{
			enemyCount = 8;
			randSpawn = Random.Range(2,4);
			safeControl = 5;
		}
		if(player.wavesSystem == 4)
		{
			enemyCount = 10;
			randSpawn = Random.Range(3,5);
			safeControl = 5;
		}
		if(player.wavesSystem == 5)
		{
			enemyCount = 10;
			randSpawn = 5;
			safeControl = 8;
		}
		if(player.wavesSystem == 6)
		{
			enemyCount = 15;
			randSpawn = 7;
			safeControl = 9;
		}
		if(player.wavesSystem == 7)
		{
			enemyCount = 25;
			randSpawn = 6;
			safeControl = 10;
		}
		if(player.wavesSystem == 8)
		{
			enemyCount = 30;
			randSpawn = Random.Range(8,9);
			safeControl = 15;
		}
		if(player.wavesSystem == 9)
		{
			enemyCount = 45;
			randSpawn = Random.Range(9,11);
			safeControl = 20;
		}
	}

	public void CreateEnemy()
	{
		int randEnemy = Random.Range(0,enemyType.Length);
		
		if(safeSpawn < safeControl)
		{
			if(count <= enemyCount )
			{
				GameObject newEnemy = Instantiate(enemyType[randEnemy],spawners[randSpawn].transform.position,spawners[randSpawn].transform.rotation);
				count++;
				safeSpawn++;
			
			}
			
		}
		
		if(count >= enemyCount)
		{
			player.wavesControl = false;
		}
		
		
	}

	
}
