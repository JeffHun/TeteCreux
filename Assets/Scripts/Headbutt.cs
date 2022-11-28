using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbutt : MonoBehaviour
{
    public Rigidbody rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (rb.velocity.y > 0)
        {
            Debug.Log("HeadButt");
        }
    }
}
