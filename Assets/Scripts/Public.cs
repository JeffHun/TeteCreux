using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationIntensity = 20f;
    public float intensity = 0.5f;
    public float rotationSpeed = 1f;

    private float rand;

    private float wave;
    private Transform tf;
    private float tfOrigin;
    private float tfOrigin2;

    public GameObject player;

    private void Start()
    {
        tf = transform;
        rand = Random.Range(0.5f, 2.0f);

        tfOrigin = transform.position.y;
        tfOrigin2 = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        intensity = player.GetComponent<EntityCollisionBehavior>().intensity;
        rotationSpeed = player.GetComponent<EntityCollisionBehavior>().rotationSpeed;
        speed = player.GetComponent<EntityCollisionBehavior>().speed;
    }

    void FixedUpdate()
    {
        wave = Mathf.PingPong(Time.time * speed * rand, intensity);
        
        //People Translate
        //ftf.position = new Vector3(tf.position.x, tf.position.y + wave, tf.position.z);
        tf.position = new Vector3(tf.position.x, tfOrigin + wave, tf.position.z);
        
        //People Rotation
        tf.localRotation = Quaternion.Euler(tf.rotation.eulerAngles.x, tf.rotation.eulerAngles.y, tfOrigin2 + rotationIntensity + rand * 10 * Mathf.Sin(Time.time * rotationSpeed));
    }

    

}
