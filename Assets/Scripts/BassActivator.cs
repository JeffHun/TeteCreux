using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassActivator : MonoBehaviour
{
    public AudioClip bassBase;
    public AudioSource audioSource;
    public LayerMask layerMask;

    void Start()
    {
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawLine(transform.position, hit.transform.position, Color.green);
            //Debug.Log(hit.transform.name);

            if (hit.transform.gameObject.CompareTag("BadWall"))
            {
                if (!audioSource.isPlaying)
                {
                    //Debug.Log("playing");
                    audioSource.clip = bassBase;
                    audioSource.Play();
                }
            }
        }
        else if (audioSource.isPlaying)
            audioSource.Stop();
    }
}
