using UnityEngine;
using System.Collections;

public class EmitHateCollision : MonoBehaviour 
{
	public ParticleSystem part;
	public ParticleCollisionEvent[] collisionEvents;
	public Material green;
	public Material pink;
	
	bool alreadyHurt = false;

	void Start()
	{
		part = GetComponent<ParticleSystem>();
		collisionEvents = new ParticleCollisionEvent[16];
	}

	void OnParticleCollision(GameObject other) 
	{
		int safeLength = part.GetSafeCollisionEventSize();
		if (collisionEvents.Length < safeLength)
			collisionEvents = new ParticleCollisionEvent[safeLength];
		
		int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
		Rigidbody rb = other.GetComponent<Rigidbody>();
		int i = 0;
		while (i < numCollisionEvents) 
		{
			if (rb && !alreadyHurt) 
			{	
				if(other.gameObject.CompareTag("Player"))
				{
					alreadyHurt = true;
					other.gameObject.GetComponent<PlayerController2>().LoseLove();
					StartCoroutine(FlipAlreadyHurt());
				}

				if(other.gameObject.CompareTag("Zombie"))
				{	
					other.gameObject.GetComponent<Renderer>().material = green;
					other.gameObject.GetComponent<SwitchColors>().numHits = 0;
					if(other.gameObject.GetComponent<SwitchColors>().currentColor == "pink")
					{
						other.gameObject.GetComponent<SwitchColors>().currentColor = "green";
						other.gameObject.GetComponent<SwitchColors>().textManager.GetComponent<UpdateText>().TextUpdateSub();
					}
				}
			}
			i++;
		}
	}

	IEnumerator FlipAlreadyHurt()
	{
		yield return new WaitForSeconds(5f);
		alreadyHurt = false;
	}
}
