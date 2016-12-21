using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Image CurrentHealthBar;
	public Canvas GameOverScreen;
	public float currWidth = 300;
	public float maxWidth = 300;
	public float currHeight;
	public int mainMenu;
	private int RestartIn;

	//starting values
	void Start()
	{
		currHeight = 25;
		mainMenu = 1;
		CurrentHealthBar.rectTransform.sizeDelta = new Vector2(currWidth ,currHeight);
		RestartIn = 7;
	}

	public void UpdateHealthBar()
	{
		if (currWidth > 0) //if the players health is greater than 0
		{
			currWidth -= (maxWidth / 10);
			CurrentHealthBar.rectTransform.sizeDelta = new Vector2 (currWidth, currHeight);

		}

		if (currWidth <= 0) // if the players health is less than or equal to 0
		{
			StartCoroutine(GameOver (mainMenu)); //Start the Game over function

		}
	}

	//picking up a healthpack
	public void AddHealth()
	{
		if (currWidth < maxWidth) 
		{
			currWidth += ((maxWidth / 10)*2); //adding 2 healthboxes

			if (currWidth > maxWidth) //have curr health be max health
			{
				currWidth = maxWidth;
			}

			CurrentHealthBar.rectTransform.sizeDelta = new Vector2 (currWidth, currHeight); //update the health bar
		}
	}

	//Collision with the enemuy
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			UpdateHealthBar (); //update the healthbar
		}

	}

	//Coroutine for the game over
	IEnumerator GameOver(int sceneDex)
	{
		//Time.timeScale = 1f - Time.timeScale;
		GameOverScreen.GetComponent<Canvas> ().enabled = true; //display the game over screen
		yield return new WaitForSeconds (RestartIn); //wait a few seconds
		//Time.timeScale = 1f - Time.timeScale;
		SceneManager.LoadScene (sceneDex); //reload the scene
	}
}
