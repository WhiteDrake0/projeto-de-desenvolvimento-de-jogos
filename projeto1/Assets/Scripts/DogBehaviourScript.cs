using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviourScript : MonoBehaviour
{
    public Transform target; //the enemy's target
    
    void Start()
    {
         
       
    }

    // Update is called once per frame
    void Update()
    {
       // Follow the player 
       if(transform.position.y != target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y + 1.501f, target.position.z);
        }
    }
}
