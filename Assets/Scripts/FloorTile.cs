using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    public FloorSpawner floorSpawner;
    public GameManager gameManager;

    private float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathWall"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("NewSpawnFloor"))
        {
            floorSpawner.SpawnTile();
        }
    }
    private void Update()
    {
        rb.velocity = transform.forward * speed * -1;
        speed = gameManager.GetComponent<GameManager>().speed;
    }
}
