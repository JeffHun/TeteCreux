using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollisionBehavior : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject Headbutt;
    public AudioSource audioSource;
    public AudioSource secondAudioSource;
    public AudioClip monkeyCrowd;
    public AudioClip handWoodenSlap;
    public AudioClip damage;
    public AudioClip breakingWall;
    public AudioClip booCrowd;

    public void Collision(GameObject collisionedObject, bool hand)
    {
        if (collisionedObject.CompareTag("BadWall"))
        {
            gameManager.GetComponent<GameManager>().SetLife(-1);
            gameManager.GetComponent<GameManager>().SetScore(-50);
            audioSource.clip = damage;
            audioSource.Play();
            secondAudioSource.clip = breakingWall;
            secondAudioSource.Play();
        }
        if (collisionedObject.CompareTag("GoodWall"))
        {
            Debug.Log(Headbutt.GetComponent<Headbutt>().dist);
            if (Headbutt.GetComponent<Headbutt>().dist > 0.07f)
            {
                gameManager.GetComponent<GameManager>().SetScore(100);
                Debug.Log("Good velocity bien joué");
                audioSource.clip = monkeyCrowd;
                audioSource.Play();
                secondAudioSource.clip = breakingWall;
                secondAudioSource.Play();
            }
            else
            {
                gameManager.GetComponent<GameManager>().SetLife(-1);
                gameManager.GetComponent<GameManager>().SetScore(-50);
                audioSource.clip = damage;
                audioSource.Play();
                secondAudioSource.clip = breakingWall;
                secondAudioSource.Play();
            }
        }
        if (collisionedObject.CompareTag("BadWoodenSign") && !hand)
        {
            gameManager.GetComponent<GameManager>().SetLife(-1);
            gameManager.GetComponent<GameManager>().SetScore(-50);
            audioSource.clip = damage;
            audioSource.Play();
        }

        if (collisionedObject.CompareTag("BadWoodenSign") && hand)
        {
            gameManager.GetComponent<GameManager>().SetScore(+50);
            audioSource.clip = handWoodenSlap;
            audioSource.Play();
        }

        if (collisionedObject.CompareTag("GoodWoodenSign"))
        {
            gameManager.GetComponent<GameManager>().SetScore(-75);
            audioSource.clip = booCrowd;
            audioSource.Play();
            secondAudioSource.clip = handWoodenSlap;
            secondAudioSource.Play();
        }


    }
}
