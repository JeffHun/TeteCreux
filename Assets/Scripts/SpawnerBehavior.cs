using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerBehavior : MonoBehaviour
{
    public GameObject goodWall;
    public GameObject badWall;
    private int rand;
    public int treadmillWidth;
    public float spaceBetweenWall;
    public float spawnFrequency;
    public float firstSpawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnWall", firstSpawnDelay, spawnFrequency);
    }

    private void SpawnWall()
    {
        rand = UnityEngine.Random.Range(0, treadmillWidth);
        for (int i = 0; i < treadmillWidth; i++)
        {
            if (i == rand)
                Instantiate(goodWall, new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
            else
                Instantiate(badWall, new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
