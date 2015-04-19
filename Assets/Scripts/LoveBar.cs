using UnityEngine;
using System.Collections;

public class LoveBar : MonoBehaviour
{
	public PlayerController2 Player;
	public Transform ForegroundSprite;

	public void Update()
	{
		var lovePercent = Player.Love / (float)Player.MaxLove;
		
		ForegroundSprite.localScale = new Vector3(lovePercent, 1,1);
	}
}