using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    public GameManager gameManager;

    private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = transform.forward * speed * -1;
        speed = gameManager.GetComponent<GameManager>().speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("DeathWall"))
        {
            Destroy(gameObject);
        }
    }
}
