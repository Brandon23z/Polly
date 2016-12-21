using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
	
	//if the quit button was clicked
	public void QuitClicked(int clicked)
	{
		//quit was clicked
		if (clicked == 1)
			Application.Quit (); //quit the game
	}
}
