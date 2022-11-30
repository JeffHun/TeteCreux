using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerBehavior : MonoBehaviour
{
    public GameObject goodWall;
    public GameObject badWall;
    public GameObject goodWoodenSign;
    public GameObject badWoodenSign;
    public GameObject gameManager;
    private int rand;
    private int rand2;
    private int rand3;
    public int treadmillWidth;
    public float spaceBetweenWall;
    public float spawnFrequency;
    private bool loose;
    private float timer;

    private void Update()
    {
        spawnFrequency = gameManager.GetComponent<GameManager>().spawnFrequency;
        loose = gameManager.GetComponent<GameManager>().GetLoose();

        timer += Time.deltaTime;
        if(timer > spawnFrequency && !loose)
        {
            rand = UnityEngine.Random.Range(0, 2);
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
        rand2 = UnityEngine.Random.Range(0, 2);
        //rand3 = UnityEngine.Random.Range(1, 3);
        if (rand2 == 1)
        {
            Instantiate(goodWoodenSign, new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else
            Instantiate(badWoodenSign, new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);

        /*for (int i = 0; i< rand3; i++)
        {
            if (rand2 == 1)
            {
                Instantiate(goodWoodenSign, new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else
                Instantiate(badWoodenSign, new Vector3(transform.position.x + rand * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
        }*/
    }

    private void SpawnWall()
    {
        rand = UnityEngine.Random.Range(0, treadmillWidth);
        for (int i = 0; i < treadmillWidth; i++)
        {
            if (i == rand)
                Instantiate(goodWall, new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
            else
                Instantiate(badWall, new Vector3(transform.position.x + i * spaceBetweenWall, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
