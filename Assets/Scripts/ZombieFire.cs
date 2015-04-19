using UnityEngine;
using System.Collections;

public class ZombieFire : MonoBehaviour 
{
	public GameObject emitHateEffect;
	public float waitTime;

	float currentTime = 0;

	void Update()
	{
		currentTime += Time.deltaTime;
		if(currentTime >= waitTime)
		{
			currentTime = 0;
			if(GetComponent<SwitchColors>().currentColor != "pink")
				StartCoroutine(EmitHate());
			else 
				StopCoroutine(EmitHate());
		}	
	}

	IEnumerator EmitHate()
	{
		yield return new WaitForSeconds(.1f);
		Instantiate(emitHateEffect, transform.position, emitHateEffect.transform.rotation);
	}
}
