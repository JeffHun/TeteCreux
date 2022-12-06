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
    private GameObject secondEntity;

    private GameObject entity;

    public List<GameObject> goodPeoples = new List<GameObject>();
    public List<GameObject> badPeoples = new List<GameObject>();

    private List<GameObject> clones = new List<GameObject>();

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
        //rand = UnityEngine.Random.Range(0, 2);

        if (timer > spawnFrequency && !loose)
        {
            //rand = UnityEngine.Random.Range(0, 2);

            if (rand == 1)
                SpanwWoodenSign();
            else
                SpawnWall();
            timer = 0;
        }
    }

    void Start()
    {
        loose = gameManager.GetComponent<GameManager>().GetLoose();
    }

    private void SpanwWoodenSign()
    {
        rand = UnityEngine.Random.Range(0, treadmillWidth);
        //rand2 = UnityEngine.Random.Range(0, 2);
        rand2 = 0;
        rand3 = UnityEngine.Random.Range(0, badPeoples.Count);
        if (rand2 == 1)
        {
            rand2 = UnityEngine.Random.Range(0, goodPeoples.Count);
            entity = Instantiate(goodPeoples[rand2], new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
            entity.tag = "GoodWoodenSign";
            clones.Add(entity);
        }
        else
        {
            entity = Instantiate(badPeoples[rand3], new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
            entity.tag = "BadWoodenSign";
            clones.Add(entity);
        }
    }

    private void SpawnWall()
    {
        rand = UnityEngine.Random.Range(0, treadmillWidth);
        for (int i = 0; i < treadmillWidth; i++)
        {
            rand2 = UnityEngine.Random.Range(0, walls.Count);
            if (i == rand)
            {
                entity = Instantiate(walls[rand2], new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
                entity.tag = "GoodWall";
                clones.Add(entity);
            }
            else
            {
                entity = Instantiate(walls[rand2], new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
                secondEntity = Instantiate(spikes, new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z+1.75f), Quaternion.identity);
                entity.tag = "BadWall";
                entity.layer = 6;
                clones.Add(entity);
                clones.Add(secondEntity);
            }
        }
    }

    public List<GameObject> GetClones()
    {
        return clones;
    }
}
