using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawnerBehavior : MonoBehaviour
{
    public GameObject floor;
    public GameManager gameManager;

    void SpawnFloor()
    {
        Instantiate(floor, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
