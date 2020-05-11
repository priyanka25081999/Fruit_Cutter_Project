using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{

    public GameObject fruitPrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    public int i=1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits(){
        while(i<=60)
        {
            float delay = Random.Range(minDelay,maxDelay);

            yield return new WaitForSeconds(delay);
            
            int spawnIndex = Random.Range(0,spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            
            // Add delay
            GameObject spawnedFruit = Instantiate(fruitPrefab,spawnPoint.position,spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
            i++;
        }
    }
}
