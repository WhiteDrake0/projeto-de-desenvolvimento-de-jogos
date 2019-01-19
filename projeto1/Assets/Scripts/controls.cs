using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {


    // Update is called once per frame
    void Update()
    {

        //move up
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 0.4)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
        }

        //move down
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > -1.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 1);
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Obstacle"))
        {
            print("hhh");
        }
    }
}
