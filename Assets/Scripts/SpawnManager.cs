using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameController GameController;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 2f ;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval - (.1f * (GameController.difficulty + GameController.level)));
    }

    void SpawnRandomAnimal() 
    {
        if (GameController.animals > 0)
        { 
        // Randomly generate animal index and spawn position
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);

            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
            --GameController.animals;

        }
    }
}
