using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Returntogame : MonoBehaviour {

	//SCRIPT NO LONGER USED
	public void UnPause(bool pause)
	{
		if (pause == true) 
		{
			Cursor.visible = !Cursor.visible;
			Time.timeScale = 1f - Time.timeScale;
			pause = false;
		}

	}

}
