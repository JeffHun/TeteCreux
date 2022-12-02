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

    public float intensity = .5f;
    public float rotationSpeed = 1f;
    public float speed = .5f;
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
                intensity = 1f;
                rotationSpeed = 2f;
                speed = 1f;
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

    private void Update()
    {
        if(audioSource.clip == monkeyCrowd && !audioSource.isPlaying)
        {
            intensity = .5f;
            rotationSpeed = 1f;
            speed = .5f;
        }
        if (gameManager.GetComponent<GameManager>().GetLoose())
        {
            intensity = .25f;
            rotationSpeed = .5f;
            speed = .25f;
        }
    }
}
