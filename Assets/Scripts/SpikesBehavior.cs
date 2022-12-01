using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    public GameManager gameManager;

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
        Destroy(gameObject);
    }
}
