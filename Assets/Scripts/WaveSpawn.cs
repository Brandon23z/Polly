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
    public Transform[] spawnPoints;
	public GameObject WaveNumberText;
	public GameObject GonsLeftText;
	private Text WNT; //Wave Number Text
	private Text GLT; //Gons Left Text

	/*
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);

				Instantiate(Enemy[Random.Range(1,2)], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }*/


	void Start()
	{
		waveNumb = 0;
		shouldSpawn = true;
		WNT = WaveNumberText.GetComponent<Text> ();
		GLT = GonsLeftText.GetComponent<Text> ();

	}

	void Update()
	{
		if (waveNumb == 0) 
		{
			warmup ();
		} 
			
		WNT.text = "Wave " + waveNumb + "/" + maxWaves;
		GLT.text = "Gons Left: " + enemyCount;
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

				if (enemiesSpawned < enemiesThisWave)
				{
					Instantiate (Enemy [Random.Range (1, 2)], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
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

		waveNumb++; //Delete lter


	}

	void warmup()
	{
		
		cooldown -= Time.deltaTime;

		if(cooldown < 0 && waveNumb == 0) 
		{
			waveNumb++;
			StartCoroutine(SpawnWaves());
		}
			
	}

	void CalculateEnemies()
	{
		enemyCount = (20 + (10 * waveNumb)) + Random.Range (-9, 9);

	}

}