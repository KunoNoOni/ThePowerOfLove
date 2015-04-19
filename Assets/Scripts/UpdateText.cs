using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateText : MonoBehaviour 
{
	public Text text1;
	public GameObject text2;
	public GameObject text3;
	public int saved = 0;

	public void TextUpdateAdd()
	{
		if(saved != 8)
		{
			saved++;
			TextUpdate();
		}
	}

	public void TextUpdateSub()
	{
		if(saved != 8)
		{
			saved--;
            TextUpdate();
        }
	}

	void TextUpdate()
	{
		text1.text = "Human's Saved: "+saved;
	}

	public void TextUpdateGameOver()
	{
		text2.SetActive(true);
	}

	public void TextUpdateLevelWon()
	{
		text3.SetActive(true);
    }
}
