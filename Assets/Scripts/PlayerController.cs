using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed = 5f;
	
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float mHorizontal = Input.GetAxis("Horizontal") * speed;
		float mVertical =  Input.GetAxis ("Vertical") * speed;

		transform.Translate(mHorizontal,0f,mVertical);



	}
}
