using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floorTile;
    Vector3 nextSpawnPoint;
    private GameObject temp;

    void Awake()
    {
        nextSpawnPoint = transform.position;
    }
    public void SpawnTile()
    {
        temp = Instantiate(floorTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    private void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        
    }
}
