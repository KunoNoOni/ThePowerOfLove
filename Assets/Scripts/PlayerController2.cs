using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour 
{
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;
	public int MaxLove = 100;
	public int Love;
	public GameObject loveEffect;
	public GameObject hateEffect;
	public bool isPlayerDead;
	public bool levelWon;
	public GameObject textManager;
	public LevelManager levelManager;
	public AudioClip clip1;
	public AudioClip clip2;

	AudioSource source;

	void Awake()
	{
		isPlayerDead = false;
		levelWon = false;
		Love = MaxLove;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		source = GetComponent<AudioSource>();
    }

    void Update() 
	{
		if(!isPlayerDead && !levelWon)
		{
			float translation = Input.GetAxis("Vertical") * speed;
			float translation2 = Input.GetAxis("Horizontal") * speed;
			float rotation = Input.GetAxis("Mouse X") * rotationSpeed;
			translation *= Time.deltaTime;
			translation2 *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate(translation2, 0, translation);
			transform.Rotate(0, rotation, 0);
		}

		if(Love > MaxLove)
			Love = MaxLove;

		if(Love < 0 )
			Love = 0;

		if(Love <= 0)
		{
			isPlayerDead = true;
			textManager.GetComponent<UpdateText>().TextUpdateGameOver();
			StartCoroutine(SwitchToLoseScreen());

		}

		if(textManager.GetComponent<UpdateText>().saved == 8 && !isPlayerDead)
		{
			if(levelManager.level == 3)
			{
				if(levelWon)
					return;

				levelWon = true;
				textManager.GetComponent<UpdateText>().TextUpdateLevelWon();
				StartCoroutine(SwitchToWinScreen());
			}
			else
			{
				if(levelWon)
					return;
				
				levelWon = true;
				textManager.GetComponent<UpdateText>().TextUpdateLevelWon();
				Debug.Log ("Calling NextLevel");
			  	StartCoroutine(SwitchToNextLevel());
			}
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			transform.position = new Vector3(0f,1f,0f);
			transform.rotation = Quaternion.identity;
		}
	}

	public void LoseLove()
	{
		if(Love != 0)
		{	
			Love -= 10;
			Instantiate(hateEffect,transform.position,transform.rotation);
			source.PlayOneShot(clip1,1);
		}
	}

	public void GainLove()
	{
		if(Love != 0)
			Love += 15;
		Instantiate(loveEffect,transform.position,transform.rotation);
		source.PlayOneShot(clip2,1);
	}

	IEnumerator SwitchToWinScreen()
	{
		yield return new WaitForSeconds(1.5f);
		{
			Application.LoadLevel("_WinScreen");
		}
	}

	IEnumerator SwitchToLoseScreen()
	{
		yield return new WaitForSeconds(1.5f);
		{
			Application.LoadLevel("_LoseScreen");
        }
    }

	IEnumerator SwitchToNextLevel()
	{
		yield return new WaitForSeconds(1.5f);
		{
			levelManager.UpdateLevel();
			Debug.Log ("Switching to the next level, which is "+levelManager.level);
			if(levelManager.level == 2)
				Application.LoadLevel("_Level2");
			else //if(levelManager.level == 3)
				Application.LoadLevel("_Level3");
        }
    }
}
