using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WoodenSignBehavior : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    public GameObject player;
    public GameObject gameManager;
    private Transform from;
    private Quaternion to;
    private float speedRotation = 0.5f;
    private float timeCount = 0.0f;
    private bool anim;
    private bool oneTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        from = transform;
    }

    void Update()
    {
        speed = gameManager.GetComponent<GameManager>().speed;


        if (anim)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
            rb.velocity = transform.up * speed * -1;
        }else
        rb.velocity = transform.forward * speed * -1;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<EntityCollisionBehavior>().Collision(gameObject, false);
        }

        if (collision.gameObject.CompareTag("Hand"))
        {
            player.GetComponent<EntityCollisionBehavior>().Collision(gameObject, true);
            anim = true;
        }
    }
}
