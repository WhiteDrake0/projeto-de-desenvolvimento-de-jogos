using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    //Velocidade do obstaculo
    public float bgSpeed;

    //Fora dos limites da camara
    public float outofBounds;

    //Manager script
    private Act cheack;


    void Start()
    {
        //Determinar a largura da camara
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        outofBounds = -width / 2;

        //Get manager
        GameObject manager = GameObject.Find("Manager");

        if(manager == null)
        {
            Debug.LogWarning("Game object Manager not found");
        }

        cheack = manager.GetComponent<Act>();

        if (cheack == null)
        {
            Debug.LogWarning("Script Act not found");
        }

    }

    // Update is called once per frame
    void Update() {


        transform.position += new Vector3(-bgSpeed * Time.deltaTime, 0f, 0f);
        if(transform.position.x < outofBounds)
        {
            gameObject.SetActive(false);
        }

        if(cheack.StopObs() == true)
        {
            gameObject.GetComponent<obstacle>().enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position += new Vector3(+20f * Time.deltaTime, 0f, 0.05f);
        }
    }

}
