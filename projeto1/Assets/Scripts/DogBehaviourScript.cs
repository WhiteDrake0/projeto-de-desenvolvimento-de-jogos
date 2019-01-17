using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviourScript : MonoBehaviour
{
    public Transform target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    
    //private Vector3 mytransform = target.transform;

    // Start is called before the first frame update
    void Start()
    {
         
       
    }

    // Update is called once per frame
    void Update()
    {
        //rotate to look at the player
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);


        //move towards the player
       // transform.position += transform.forward * Time.deltaTime * moveSpeed;
       if(transform.position.y != target.position.y)
        {
            transform.position = new Vector2(transform.position.x, target.position.y + 1.501f);
        }
    }
}
