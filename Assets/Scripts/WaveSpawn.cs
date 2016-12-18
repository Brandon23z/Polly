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
		if (waveNumb == 0) 
		{
			warmup ();
		} 
			
		WNT.text = "Wave " + waveNumb + "/" + maxWaves;
		GLT.text = "Gons Left: " + enemyCount;

		if (PrepareWaveRunning == true) 
		{
			PrepareNextWave ();
		}
	}

	IEnumerator SpawnWaves()
	{
		CalculateEnemies ();
		enemiesThisWave = enemyCount;

		yield return new WaitForSeconds(startWait);
		while (shouldSpawn == true)
		{
		
			for (int i = 0; i < hazardCount; i++) 
			{
				int spawnPointIndex = Random.Range (0, spawnPoints.Length);
				int enemyIndex = Random.Range (0, Enemy.Length); 
				if (enemiesSpawned < enemiesThisWave)
				{
					Instantiate (Enemy [enemyIndex], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					enemiesSpawned++;
				} 
				else 
				{
					shouldSpawn = false;
				}

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}

		PrepareWaveRunning = true;
		startNextRunning = false;
		waveCoolDownTimer = waveCoolDown;
		StopCoroutine (SpawnWaves()); 
		


	}

	void warmup()
	{
		
		cooldown -= Time.deltaTime;
		WCT.text = "Game Starting in " + Mathf.Floor (cooldown) + " seconds";
		if(cooldown < 0 && waveNumb == 0) 
		{
			waveNumb++;
			WCT.text = "";
			StartCoroutine(SpawnWaves());
		}
			
	}

	void CalculateEnemies()
	{
		enemyCount = (20 + (10 * waveNumb)) + Random.Range (-9, 9); //Change first ten back to twenty
	}

	void PrepareNextWave()
	{
		if (enemyCount <= 0) 
		{
			
			if (startNextRunning == false)
			{
				WCT.text = "WAVE COMPLETED";
				startNextRunning = true;
				StartCoroutine (StartNext ());
			}

		}
	}

	IEnumerator StartNext()
	{	
		while (waveCoolDownTimer  >= 0) 
		{
			if (waveCoolDownTimer <= 5)
			{
				WCT.text = "Next Wave is Starting";
			}
			
			waveCoolText.text = "Wave Cooldown: " + waveCoolDownTimer.ToString() + " seconds";
			yield return new WaitForSeconds (1f);
			waveCoolDownTimer--;
		}

		waveCoolText.text = "Wave Cooldown: -" ;
		WCT.text = "";
		shouldSpawn = true;
		waveNumb++;
		enemiesSpawned = 0;
		PrepareWaveRunning = false;

		StartCoroutine (SpawnWaves ());
		StopCoroutine (StartNext ());

	}
}