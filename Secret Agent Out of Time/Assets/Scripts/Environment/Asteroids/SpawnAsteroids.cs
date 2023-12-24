using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] GameObject asteroids;
    [SerializeField] int asteroidsCount;
    [SerializeField] float startWait;
    [SerializeField] float spawnWait;
    [SerializeField] float waveWait;
    [SerializeField] float asteroidescount;

    public Vector2 spawnSize;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) 
        {
            for (int i = 0; i < asteroidsCount; i++)
            {
                Vector3 spawnPosition = new Vector2(Random.Range(-spawnSize.x, spawnSize.x), spawnSize.y);
                Instantiate(asteroids, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            asteroidescount++;
            yield return new WaitForSeconds(waveWait);

            if (asteroidescount >= 5)
            {
               break;
            }
        }

    }    
}
