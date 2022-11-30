using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSignBehavior : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    public GameObject player;
    public GameObject gameManager;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<EntityCollisionBehavior>().Collision(gameObject, false);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Hand"))
        {
            player.GetComponent<EntityCollisionBehavior>().Collision(gameObject, true);
            Destroy(gameObject);
        }
    }
}
