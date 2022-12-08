using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassActivator : MonoBehaviour
{
    public AudioClip bassBase;
    public AudioSource audioSource;
    public LayerMask layerMask;
    public GameManager gameManager;
    private float spawnFrequency;

    void Start()
    {
    }

    private void Update()
    {
        spawnFrequency = gameManager.GetComponent<GameManager>().spawnFrequency;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 15.21f - (5 - spawnFrequency), layerMask))
        {
            //Debug.DrawLine(transform.position, hit.transform.position, Color.green);
            //Debug.Log(hit.transform.name);

            if (hit.transform.gameObject.CompareTag("BadWall"))
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = bassBase;
                    audioSource.Play();
                }
            }
        }
        else if (audioSource.isPlaying)
            audioSource.Stop();
    }
}
