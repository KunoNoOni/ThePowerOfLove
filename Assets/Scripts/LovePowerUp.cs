using UnityEngine;
using System.Collections;

public class LovePowerUp : MonoBehaviour 
{
	//public PlayerController2 Player;
	public GameObject loveEffect;
	public AudioClip clip;

	AudioSource source;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Instantiate(loveEffect,transform.position,transform.rotation);
			Destroy(gameObject);
			other.gameObject.GetComponent<PlayerController2>().Love += 25;
			source = other.gameObject.GetComponent<AudioSource>();
			Debug.Log(source);
			source.PlayOneShot(clip,1);
		}
	}
}
