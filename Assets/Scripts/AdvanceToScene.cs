using UnityEngine;
using System.Collections;

public class AdvanceToScene : MonoBehaviour 
{
	public string sceneName;

	void Update () 
	{
		if(!Input.GetMouseButtonDown(0))
			return;
		else
		{
			Application.LoadLevel(sceneName);
		}
	}
}
