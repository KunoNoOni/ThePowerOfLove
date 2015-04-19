using UnityEngine;
using System.Collections;

public class FountainSwitch : MonoBehaviour 
{
	public Material redLight;
	public Material greenLight;

	Renderer rMat;
	HateFountain hf;
	string lightOn = "green";

	void Start () 
	{
		rMat = GetComponent<Renderer>();
		hf = GameObject.Find("HateFountain").GetComponent<HateFountain>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(lightOn == "red" && other.gameObject.CompareTag("Player"))
		{
			rMat.material = greenLight;
			lightOn = "green";
			hf.fountainOn = true;
		}
		else if(lightOn == "green" && other.gameObject.CompareTag("Player"))
		{
			rMat.material = redLight;
			lightOn = "red";
			hf.fountainOn = false;
		}
	}

}
