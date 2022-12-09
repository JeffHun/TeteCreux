using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReplayOrQuit : MonoBehaviour
{
    private int handCount;
    public GameManager gameManager;
    public bool quit;
    private bool loose;
    private float wave;
    private Transform tf;
    private float tfOrigin;
    public float speed;
    private float timer;

    private void Start()
    {
        tf = gameObject.transform.parent.gameObject.transform;
        tfOrigin = gameObject.transform.parent.gameObject.transform.position.z;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Hand") && handCount == 2 && !quit)
        {
            gameManager.GetComponent<GameManager>().Replay();
            handCount = 0;
        }
        if (collision.CompareTag("Hand") && handCount == 2 && quit)
        {
            gameManager.GetComponent<GameManager>().Quit();
            handCount = 0;
        }
    }

    public void HandDetected()
    {
        handCount++;
    }

    private void Update()
    {
        loose = gameManager.GetComponent<GameManager>().GetLoose();

        if (loose)
        {
            if(timer >= Mathf.PI)
                timer = Mathf.PI;
            else
                timer += Time.deltaTime;
            wave = Mathf.Sin(timer * speed);
            tf.position = new Vector3(tf.position.x, tf.position.y, tfOrigin + wave);
        }
        if(!loose)
        {
            tf.position = new Vector3(tf.position.x, tf.position.y, tfOrigin);
        }
    }
}
