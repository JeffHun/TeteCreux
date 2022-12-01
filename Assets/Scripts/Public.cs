using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationIntensity = 20f;
    public float intensity = 0.5f;
    public float rotationSpeed = 1f;

    private float wave;
    private Transform tf;

    private void Start()
    {
        tf = transform;
    }

    void FixedUpdate()
    {
        wave = Mathf.PingPong(Time.time * speed, intensity);
        
        //People Translate
        tf.position = new Vector3(tf.position.x, wave, tf.position.z);

        //People Rotation
        tf.localRotation = Quaternion.Euler(tf.rotation.eulerAngles.x, tf.rotation.eulerAngles.y, rotationIntensity * Mathf.Sin(Time.time * rotationSpeed));
    }

    

}
