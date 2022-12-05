using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    public float speed;
    public ParticleSystem particuleSystem;
    private Rigidbody rb;
    public int handCount;
    public GameObject gameManager;
    public AudioSource audiosource;
    public AudioClip breakingWall;

    public GameObject judgePlus50;

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
            collision.transform.gameObject.GetComponent<EntityCollisionBehavior>().Collision(gameObject, false);
            Instantiate(particuleSystem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Hand") && handCount == 2)
        {
            Instantiate(particuleSystem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameManager.GetComponent<GameManager>().SetScore(5);
            audiosource.clip = breakingWall;
            audiosource.Play();
            judgePlus50.GetComponent<JudgeBehavior>().JudgeStand();

            Destroy(gameObject);
        }
    }

    public void HandDetected()
    {
        handCount++;
    }
}
