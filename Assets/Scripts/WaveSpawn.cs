using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawn : MonoBehaviour
{
    public GameObject[] Enemy = null;

    public int hazardCount = 3;
    public float spawnWait = 0.5f;
    public float startWait = 4;
    public float waveWait = 4;
	public int maxWaves;
	public int enemyCount;
	public int enemiesThisWave;
	public int enemiesSpawned;
	public bool shouldSpawn;
	public int waveNumb; //which wave are they on
	public float cooldown;	//cooldown before the enemies start coming
	public int waveCoolDown;
	private int waveCoolDownTimer;
    public Transform[] spawnPoints;
	public GameObject WaveNumberText;
	public GameObject GonsLeftText;
	public GameObject WaveCompletedText;
	public GameObject WaveCoolDownText;
	private Text WNT; //Wave Number Text
	private Text GLT; //Gons Left Text
	private Text WCT; //Wave Completed Text
	private Text waveCoolText;
	public bool PrepareWaveRunning;
	public bool startNextRunning;
	public int kills;
	public int Score;
	public int BlockVal; //value of the block enemies
	public int TrapVal;	//value of the trapezoid enemies


	void Start()
	{
		PrepareWaveRunning = false; 
		waveNumb = 0;
		shouldSpawn = true;
		WNT = WaveNumberText.GetComponent<Text> ();
		GLT = GonsLeftText.GetComponent<Text> ();
		WCT = WaveCompletedText.GetComponent<Text> ();
		waveCoolText = WaveCoolDownText.GetComponent<Text> ();

	}

	void Update()
	{
		if (waveNumb == 0)  //if its the intial wave
		{
			warmup (); //go to warmup
		} 
			
		WNT.text = "Wave " + waveNumb; //update the text
		GLT.text = "Gons Left: " + enemyCount; //update the enemy count

		if (PrepareWaveRunning == true) //if the game is inbetween waves
		{
			PrepareNextWave (); //prepare the next wave
		}
	}

	IEnumerator SpawnWaves()
	{
		CalculateEnemies (); //calculate how many enemies are in this wave
		enemiesThisWave = enemyCount; //set the max enemies for this wave to enemy count

		yield return new WaitForSeconds(startWait); //wait for a lil
		while (shouldSpawn == true) //if should spawn enemies is true
		{
		
			for (int i = 0; i < hazardCount; i++)  //spawn em
			{
				int spawnPointIndex = Random.Range (0, spawnPoints.Length); //pick a spawn point
				int enemyIndex = Random.Range (0, Enemy.Length); //pick an enemy

				//if the amount of spawned enemies is less than the max enemies for this wave
				if (enemiesSpawned < enemiesThisWave) //spawn them
				{
					Instantiate (Enemy [enemyIndex], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					enemiesSpawned++;
				} 
				else //if the max amount of enemies has already been spawned
				{
					shouldSpawn = false; //set to false to stop the spawning
				}

				yield return new WaitForSeconds (spawnWait); //wait in between enemy spawns
			}
			yield return new WaitForSeconds (waveWait);

		} //exit the wave spawning
		//wave complete

		PrepareWaveRunning = true; //preparing for next wave
		startNextRunning = false; 
		waveCoolDownTimer = waveCoolDown; //countdown timer
		StopCoroutine (SpawnWaves());  //stop the spawning coroutine

	}

	void warmup()
	{
		
		cooldown -= Time.deltaTime; //countdown timer
		WCT.text = "Game Starting in " + Mathf.Floor (cooldown) + " seconds";

		if(cooldown < 0 && waveNumb == 0) //only do this when it is the intial wave
		{
			waveNumb++;
			WCT.text = "";
			StartCoroutine(SpawnWaves()); //start spawning enemies
		}
			
	}

	//calculate how many enemies will be in this wave
	void CalculateEnemies()
	{
		//basic algorithm i made: 
		//Base amount of enemies of 20 + 10 * the wave number + a random number from -9 to 9
		enemyCount = (20 + (10 * waveNumb)) + Random.Range (-9, 9); 
	}

	void PrepareNextWave()
	{
		if (enemyCount <= 0) //once the enemy count is less than or equal to 0
		{
			
			if (startNextRunning == false)
			{
				WCT.text = "WAVE COMPLETED"; //when the wave is complete display this text
				startNextRunning = true;
				StartCoroutine (StartNext ()); //start the coroutine for starting the next wave
			}

		}
	}

	//starting the next wave
	IEnumerator StartNext()
	{	
		while (waveCoolDownTimer  >= 0) //next wave is starting
		{
			if (waveCoolDownTimer <= 5) //when the countdown is at 5 seconds or less
			{
				WCT.text = "Next Wave is Starting"; //inform the player the next wave is starting
			}
			
			waveCoolText.text = "Wave Cooldown: " + waveCoolDownTimer.ToString() + " seconds"; //wave cooldown countdown
			yield return new WaitForSeconds (1f); //wait for a second
			waveCoolDownTimer--;
		}

		waveCoolText.text = "Wave Cooldown: -" ;
		WCT.text = "";
		shouldSpawn = true;
		waveNumb++; //increase the wave number
		enemiesSpawned = 0; //reset how many enemies have spawned
		PrepareWaveRunning = false;

		StartCoroutine (SpawnWaves ()); //start spawning enemies
		StopCoroutine (StartNext ());	//stop this coroutine

	}
}