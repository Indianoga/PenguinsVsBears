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
	AudioClip[] musicManager;
	[SerializeField]
	AudioSource musicGame;
	Player player;

	int levelManager;
	int waveCountControl;
	int enemyCount;
	int count;
	[HideInInspector]
	public int safeSpawn;
	

	// Use this for initialization
	void Start () 
	{
		playerPrefab = GameObject.FindGameObjectWithTag("Player");
		player = playerPrefab.GetComponent<Player>();
		levelManager = PlayerPrefs.GetInt("level");
		SoundManager.instance.Play("Player",SoundManager.instance.clipList.penguinShoot,1f);
		
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
			spawners = GameObject.FindGameObjectsWithTag("spawner");
			PlayerPrefs.SetInt("level",player.wavesSystem);
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
			enemyCount = 5;
		}
	}

	public void CreateEnemy()
	{
		int randEnemy = Random.Range(0,enemyType.Length);
		int randSpawn = Random.Range(0,spawners.Length);
		if(safeSpawn < 5)
		{
			if(count <= enemyCount )
			{
				GameObject newEnemy = Instantiate(enemyType[randEnemy],spawners[randSpawn].transform.position,spawners[randSpawn].transform.rotation);
				count++;
				safeSpawn++;
			
			}
			
		}
		
		if(count == enemyCount)
		{
			player.wavesControl = false;
		}
		
		
	}

	
}
