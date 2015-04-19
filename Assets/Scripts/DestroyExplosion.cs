using UnityEngine;
using System.Collections;

public class DestroyExplosion : MonoBehaviour 
{
	void Update () 
	{
		StartCoroutine(DestroyExplosionEffect());
	}

	IEnumerator DestroyExplosionEffect()
	{
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}
}
