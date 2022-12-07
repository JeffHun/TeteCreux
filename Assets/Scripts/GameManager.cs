using OculusSampleFramework;
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
    private Transform originalFrom;
    private Quaternion to;
    private Quaternion start;
    public float speed;
    public float spawnFrequency;
    private int score = 0;
    public AudioClip loosed;
    public AudioSource audioSource;
    private bool loose = false;
    public GameObject scoreBehavior;
    public GameObject spawnBehavior;

    private List<GameObject> clones = new List<GameObject>();

    private float originalSpeed;
    private float originalFrequency;

    private float timer;
    public float coef;

    public void SetScore(int aScore)
    {
        score += aScore;
        Debug.Log(score);
        scoreBehavior.GetComponent<ScoreBehavior>().ScoreUpdate(score);
    }

    private void Start()
    {
        originalFrom = transform;
    }

    private void Awake()
    {
        from = transform;
        originalFrequency = spawnFrequency;
        originalSpeed = speed;
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

        timer += Time.deltaTime;
        if (timer > 1 && !loose)
        {
            speed += coef;
            spawnFrequency -= coef;
            timer = 0;
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
        loose = true;
        speed = 0;
        spawnFrequency = 0;
        audioSource.clip = loosed;
        audioSource.Play();

        clones = spawnBehavior.GetComponent<SpawnerBehavior>().GetClones();
        for (int i = 0; i < clones.Count; i++)
        {
            Destroy(clones[i]);
        }
    }

    public bool GetLoose()
    {
        return loose;
    }

    public void Replay()
    {
        speed = 0;
        spawnFrequency = 0;
        clones = spawnBehavior.GetComponent<SpawnerBehavior>().GetClones();
        for (int i = 0; i < clones.Count; i++)
        {
            Destroy(clones[i]);
        }
        to = Quaternion.Euler(0f, 0f, 0f);
        move = true;
        life = 3;
        score = 0;
        scoreBehavior.GetComponent<ScoreBehavior>().ResetRotation();
        speed = originalSpeed;
        spawnFrequency = originalFrequency;
        loose = false;
    }

    public void Quit()
    {
        Debug.Log("Lâche");
        Application.Quit();
    }
}
