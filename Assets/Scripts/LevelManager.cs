using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public int level;

	void Start()
	{		
		DontDestroyOnLoad(this);
	}

	public void UpdateLevel()
	{
		level++;
		Debug.Log ("Level Manager says the level is "+level);
	}
}
