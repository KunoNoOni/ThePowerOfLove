using UnityEngine;
using System.Collections;

public class ShootHearts : MonoBehaviour 
{
	public GameObject heartPrefab;
	public PlayerController2 Player;
	public AudioClip clip;

	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0) && !Player.isPlayerDead && !Player.levelWon)
		{
			EmitLove();
		}
	}

	void EmitLove()
	{
		Instantiate(heartPrefab, this.transform.position, this.transform.rotation);
		source.PlayOneShot(clip,1);
	}
}
