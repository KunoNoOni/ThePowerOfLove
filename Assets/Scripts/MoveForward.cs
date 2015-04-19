using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour 
{
	public GameObject destroyEffect;

	float speed = 50;
	
	void Update () 
	{

		transform.position += transform.forward * speed * Time.deltaTime;
		StartCoroutine(DestroyHeart());
	}

	IEnumerator DestroyHeart()
	{
		yield return new WaitForSeconds(.2f);
		if(destroyEffect != null)
			Instantiate(destroyEffect,transform.position,transform.rotation);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Zombie"))
		{
			if(destroyEffect != null)
				Instantiate(destroyEffect,transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}


}
