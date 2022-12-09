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
            Instantiate(particuleSystem, new Vector3(transform.position.x-0.35f, transform.position.y+1.7f, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
            Destroy(gameObject);
        }

        if (collision.CompareTag("Hand") && handCount == 2)
        {
            Instantiate(particuleSystem, new Vector3(transform.position.x-0.35f, transform.position.y+1.7f, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
            gameManager.GetComponent<GameManager>().SetScore(5);
            audiosource.clip = breakingWall;
            audiosource.Play();
            judgePlus50.GetComponent<JudgeBehavior>().JudgeStand();
            StartCoroutine(ControllerVibration());
            Destroy(gameObject);
        }
    }

    IEnumerator ControllerVibration()
    {
        OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }

    public void HandDetected()
    {
        handCount++;
    }
}
