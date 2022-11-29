using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassActivator : MonoBehaviour
{
    public AudioClip bassBase;
    public AudioSource audioSource;
    public bool playing = false;
    void Start()
    {
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 100f))
        {
            if (hit.transform.gameObject.CompareTag("BadWall"))
            {
                if(!audioSource.isPlaying)
                {
                    audioSource.clip = bassBase;
                    audioSource.Play();
                }
            }
            else
                audioSource.Stop();
        }
    }
}
