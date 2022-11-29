using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbutt : MonoBehaviour
{
    public Rigidbody rb;
    float timer;
    bool posi = true;
    public float dist;

    Vector3 pos1;
    Vector3 pos2;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if(posi){
            pos1 = rb.position; //lock position one
            posi = false;
        }
        

        timer += Time.deltaTime;
        if(timer > 0.5f)
        {
            timer = 0;
            pos2 = rb.position; //lock position two

            dist = Vector3.Distance(pos1, pos2); //distance between pos1 and pos2 in 5s

            Debug.Log(dist);

            posi = true;
        }
    }
}
