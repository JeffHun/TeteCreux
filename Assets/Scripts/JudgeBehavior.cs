using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JudgeBehavior : MonoBehaviour
{
    private Transform tf;
    private Vector3 nextPosition;
    private float interpolationRatio;
    public float movingSpeed;
    private float timeCountMoving = 0;
    private bool animation = false;
    private float tfOrigin;

    void Start()
    {
        tf = transform;
        tfOrigin = transform.position.y;

        nextPosition = new Vector3(transform.position.x, tf.position.y+2, transform.position.z);
    }

    public void JudgeStand()
    {
        animation = true;
    }

    private void Update()
    {
        if(animation)
        {
            timeCountMoving += Time.deltaTime;
            tf.position = new Vector3(tf.position.x, tfOrigin + Mathf.Sin(timeCountMoving * movingSpeed)*2f, tf.position.z);
            if(timeCountMoving> Mathf.PI)
            {
                timeCountMoving = 0;
                animation = false;
            }
        }
    }
}
