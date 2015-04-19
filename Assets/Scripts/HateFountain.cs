using UnityEngine;
using System.Collections;

public class HateFountain : MonoBehaviour 
{
	public GameObject emitHate;
	public float waitTime;
	public bool fountainOn = true;
	public AudioClip clip;
	
	float currentTime = 0;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}


	void Update()
	{
		currentTime += Time.deltaTime;
		if(currentTime >= waitTime)
		{
			currentTime = 0;
			if(fountainOn)
				StartCoroutine(EmitHateFountain());
			else
				StopCoroutine(EmitHateFountain());
		}
	}

	IEnumerator EmitHateFountain()
	{
		yield return new WaitForSeconds(.01f);
		Instantiate(emitHate,transform.position,emitHate.transform.rotation);
		source.PlayOneShot(clip,.8f);

	}

}
