using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollisionBehavior : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject Headbutt;

    public void Collision(GameObject collisionedObject, bool hand)
    {
        if (collisionedObject.CompareTag("BadWall"))
        {
            gameManager.GetComponent<GameManager>().SetLife(-1);
            gameManager.GetComponent<GameManager>().SetScore(-150);
        }
        if (collisionedObject.CompareTag("GoodWall"))
        {
            if (Headbutt.GetComponent<Headbutt>().dist > 0.07f)
            {
                gameManager.GetComponent<GameManager>().SetScore(150);
            }
            else
            {
                gameManager.GetComponent<GameManager>().SetLife(-1);
                gameManager.GetComponent<GameManager>().SetScore(-75);
            }
        }
        if (collisionedObject.CompareTag("BadWoodenSign") && !hand)
        {
            gameManager.GetComponent<GameManager>().SetLife(-1);
            gameManager.GetComponent<GameManager>().SetScore(-50);
        }

        if (collisionedObject.CompareTag("GoodWoodenSign"))
        {
            gameManager.GetComponent<GameManager>().SetScore(-50);
        }

        if (collisionedObject.CompareTag("BadWoodenSign") && hand)
        {
            gameManager.GetComponent<GameManager>().SetScore(+50);
        }

    }
}
