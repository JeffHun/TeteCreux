using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReplayOrQuit : MonoBehaviour
{
    private int handCount;
    public GameManager gameManager;
    public bool quit;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Hand") && handCount == 2 && !quit)
        {
            gameManager.GetComponent<GameManager>().Replay();
            handCount = 0;
        }
        if (collision.CompareTag("Hand") && handCount == 2 && quit)
        {
            gameManager.GetComponent<GameManager>().Quit();
            handCount = 0;
        }
    }

    public void HandDetected()
    {
        handCount++;
    }
}
