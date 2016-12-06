using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoad : MonoBehaviour
{

	public void LoadByIndex(int sceneDex)
	{
		SceneManager.LoadScene (sceneDex);

	}
}
