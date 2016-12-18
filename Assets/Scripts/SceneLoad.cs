using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoad : MonoBehaviour
{

	public void LoadByIndex(int sceneDex)
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (sceneDex);

	}
}
