using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSignBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.forward * speed * -1;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("RightHand") || collision.gameObject.CompareTag("LeftHand")) ;
        {
            Destroy(gameObject);
        }
    }
}
