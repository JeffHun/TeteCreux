using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("GoodWall"));
        {
            collision.GetComponent<WallBehavior>().HandDetected();
        }

    }
}
