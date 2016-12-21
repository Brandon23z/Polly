using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoad : MonoBehaviour
{
	//load the scene
	public void LoadByIndex(int sceneDex)
	{
		Time.timeScale = 1; //to make sure the time is set to 1
		SceneManager.LoadScene (sceneDex);

	}
}
