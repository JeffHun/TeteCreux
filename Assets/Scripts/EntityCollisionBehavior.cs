using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollisionBehavior : MonoBehaviour
{
    public GameObject lifeDisplay;
    public GameObject Headbutt;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collision(GameObject collisionedObject)
    {
        if (collisionedObject.CompareTag("BadWall"))
            lifeDisplay.GetComponent<LifeDisplay>().SetLife(-1);
        if (collisionedObject.CompareTag("GoodWall"))
        {
            if (Headbutt.GetComponent<Headbutt>().dist > 0.07f)
            {
                Debug.Log("good headbang");
            }
            else
            {
                lifeDisplay.GetComponent<LifeDisplay>().SetLife(-1);
                Debug.Log("bad headbang");
            }
        } 
        
        
    }
}
