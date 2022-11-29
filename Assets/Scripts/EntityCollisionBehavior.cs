using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollisionBehavior : MonoBehaviour
{
    public GameObject lifeDisplay;
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
            lifeDisplay.GetComponent<LifeDisplay>().SetLife(+1);
    }
}
