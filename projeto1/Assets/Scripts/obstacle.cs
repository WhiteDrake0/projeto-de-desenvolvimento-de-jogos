using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    //Velocidade do obstaculo
    public float bgSpeed;

    //Fora dos limites da camara
    public float outofBounds;


    void Start()
    {
        //Determinar a largura da camara
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        outofBounds = -width / 2;

    }

    // Update is called once per frame
    void Update() {

        transform.position += new Vector3(-bgSpeed * Time.deltaTime, 0f, 0f);
        if(transform.position.x < outofBounds)
        {
            Destroy(gameObject);
        }

    }

}
