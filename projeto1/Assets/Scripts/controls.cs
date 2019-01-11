using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {

 
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.W) && transform.position.y < 0.4f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            print("up");
            
           
        }
       

        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > -1.6f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
            print("down");

        }

    }
}
