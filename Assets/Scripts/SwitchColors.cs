using UnityEngine;
using System.Collections;

public class SwitchColors : MonoBehaviour 
{
	public Material green;
	public Material lightBlue;
	public Material lightPurple;
	public Material pink;
	public PlayerController2 Player;
	public int numHits = 0;
	public GameObject textManager;
	public string currentColor = "green";
	public GameObject loveEffect;

	Renderer rMat;

	void Start()
	{
		rMat = GetComponent<Renderer>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Love") && numHits != 3)
		{	
			numHits++;
			switch(numHits)
			{
				case 0:
				{
					rMat.material = green;
					currentColor = "green";
					break;
				}

				case 1:
				{
					rMat.material = lightBlue;
					currentColor = "lightBlue";
					break;
				}

				case 2:
				{
					rMat.material = lightPurple;
					currentColor = "lightPurple";
					break;
				}

				case 3:
				{
					rMat.material = pink;
					currentColor = "pink";
					if(Player.Love != Player.MaxLove)
						Player.GainLove();
					textManager.GetComponent<UpdateText>().TextUpdateAdd();
					Instantiate(loveEffect, transform.position, transform.rotation);
					break;
				}
			}
		}
	}
}
