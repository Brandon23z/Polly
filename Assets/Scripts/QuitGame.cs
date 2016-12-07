using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	public void QuitClicked(int clicked)
	{
		if (clicked == 1)
			Application.Quit ();
	}
}
