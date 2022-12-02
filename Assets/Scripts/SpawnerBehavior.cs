using OVR.OpenVR;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerBehavior : MonoBehaviour
{
    public List<GameObject> walls = new List<GameObject>();
    public GameObject spikes;

    private GameObject entity;

    public List<GameObject> goodPeoples = new List<GameObject>();
    public List<GameObject> badPeoples = new List<GameObject>();

    public GameObject gameManager;
    private int rand;
    private int rand2;
    private int rand3;
    public int treadmillWidth;
    public float spaceBetweenWall;
    private float spawnFrequency;
    private bool loose;
    private bool repeat = false;
    private float timer;

    private void Update()
    {
        spawnFrequency = gameManager.GetComponent<GameManager>().spawnFrequency;
        loose = gameManager.GetComponent<GameManager>().GetLoose();

        timer += Time.deltaTime;
        rand = UnityEngine.Random.Range(0, 2);

        if (timer > spawnFrequency && !loose)
        {
            rand = UnityEngine.Random.Range(0, 2);

            if (rand == 1)
                SpanwWoodenSign();
            else
                SpawnWall();
            timer = 0;
        }

        /*if(timer > spawnFrequency * 0.5 && !loose && rand == 1)
        {
            SpanwWoodenSign();
            repeat = true;
        }

        if(timer > spawnFrequency && repeat && !loose)
        {
            SpanwWoodenSign();
            repeat = false;
            timer = 0;
        }
        else if(timer > spawnFrequency && !loose)
        {
            rand = UnityEngine.Random.Range(0, 2);
            if (rand == 1)
                SpanwWoodenSign();
            else
                SpawnWall();
            timer = 0;
        }*/
    }

    void Start()
    {
        loose = gameManager.GetComponent<GameManager>().GetLoose();
    }

    private void SpanwWoodenSign()
    {
        rand = UnityEngine.Random.Range(0, treadmillWidth);
        rand2 = UnityEngine.Random.Range(0, goodPeoples.Count);
        rand3 = UnityEngine.Random.Range(0, badPeoples.Count);
        if (rand2 == 1)
        {
            entity = Instantiate(goodPeoples[rand2], new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
            entity.tag = "GoodWoodenSign";
        }
        else
        {
            entity = Instantiate(badPeoples[rand3], new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
            entity.tag = "BadWoodenSign";
        }
    }

    private void SpawnWall()
    {
        rand = UnityEngine.Random.Range(0, treadmillWidth);
        rand2 = UnityEngine.Random.Range(0, walls.Count);
        for (int i = 0; i < treadmillWidth; i++)
        {
            if (i == rand)
            {
                entity = Instantiate(walls[rand2], new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
                entity.tag = "GoodWall";
            }else
            {
                Instantiate(spikes, new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z+1.75f), Quaternion.identity);
                entity = Instantiate(walls[rand2], new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
                entity.tag = "BadWall";
                entity.layer = 6;
            }
        }
    }
}
