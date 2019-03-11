using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelGeneretor : MonoBehaviour {
	
	
	GameObject playerPrefab;
	Player player;
	[SerializeField]
	GameObject FaseSetup;
	[SerializeField]
	Texture2D[] Maps;
	[SerializeField]
	Texture2D map;

	[SerializeField]
	ColorToPrefab[] colorMappings;
	
	bool mapCheck;
	
	void Start () 
	{
		playerPrefab = GameObject.FindGameObjectWithTag("Player");
		player = playerPrefab.GetComponent<Player>();
		map = Maps[0];
		StartCoroutine("Action");
		
		
	}

	private void Update() 
	{

		
	}

	IEnumerator Action()
	{
		
		while (true)
		{
			yield return null;
			
			if(!mapCheck)
			{
				GenerateLevel(); 
				mapCheck = true;
			}
			
			
			
		}
	}
	public void GenerateLevel()
	{
		for(int x = 0; x < map.width; x++)
		{
			for(int y = 0; y < map.height; y++)
			{
				GenereteTile(x,y);
			}
		}
	}

	void GenereteTile(int x, int y )
	{
		Color pixelColor = map.GetPixel(x,y);
		if (pixelColor.a == 0)
		{
			return;
		}
		foreach(ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color .Equals(pixelColor) )
			{
				Vector2 position = new Vector2(x,y);
				GameObject newFase = Instantiate(colorMapping.prefab,position,Quaternion.identity,transform);
				newFase.transform.parent = FaseSetup.transform;
			}
		}

	}

	
}
