using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    private int life = 3;
    private bool move = false;
    private bool direction;
    private float timeCount = 0;
    public float rotationSpeed;
    private Transform from;
    private Quaternion to;
    private Quaternion start;

    void Start()
    {
        
    }
    private void Awake()
    {
        from = transform;
        Debug.Log(start.y);
    }
    
    void Update()
    {
        if(move)
        {
            timeCount += Time.deltaTime * rotationSpeed;
            from.localRotation = Quaternion.Lerp(start, to, timeCount);
            if (timeCount > 1)
            {
                move = false;
                timeCount = 0;
            }

        }
    }

    public void SetLife(int value)
    {
        life += value;
        
        if(life > 3)
            life = 3;

        move = true;

        start = from.localRotation;
        if (value > 0)
            to = Quaternion.Euler(90f, 0f, 0f) * start;
        else
            to = Quaternion.Euler(-90f, 0f, 0f) * start;

        if (life < 1)
            Lose();
    }

    private void Lose()
    {
        Debug.Log("Lose");
    }
}
