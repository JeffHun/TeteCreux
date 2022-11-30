using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    public float speed;
    public ParticleSystem particuleSystem;
    private Rigidbody rb;
    private bool oneHand = false;
    public int handCount;

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
        if (/*collision.gameObject.CompareTag("Player") ||*/ handCount == 2);
        {
            collision.transform.gameObject.GetComponent<EntityCollisionBehavior>().Collision(gameObject);
            Instantiate(particuleSystem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void HandDetected()
    {
        handCount++;
        Debug.Log(handCount);
    }
}
