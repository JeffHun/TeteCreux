using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int life = 3;
    private bool move = false;
    private float timeCount = 0;
    public float rotationSpeed;
    private Transform from;
    private Quaternion to;
    private Quaternion start;
    public float speed;
    public float spawnFrequency;
    private int score = 0;
    public AudioClip bigFart;
    public AudioSource audioSource;
    private bool loose = false;

    public void SetScore(int aScore)
    {
        score += aScore;
        Debug.Log(score);
    }

    private void Awake()
    {
        from = transform;
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
        if(life + value <= 3 && life + value >= 0)
        {
            life += value;
            move = true;
            start = from.localRotation;
            if (value > 0)
                to = Quaternion.Euler(90f, 0f, 0f) * start;
            else
                to = Quaternion.Euler(-90f, 0f, 0f) * start;
        }

        if(life == 0)
        {
            Lose();
        }
    }

    private void Lose()
    {
        Debug.Log("Lose");
        loose = true;
        speed = 0;
        spawnFrequency = 0;
        audioSource.clip = bigFart;
        audioSource.Play();
    }

    public bool GetLoose()
    {
        return loose;
    }
}
