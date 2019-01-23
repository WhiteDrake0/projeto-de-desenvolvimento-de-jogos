using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoControls : MonoBehaviour {

    int lifePointsN;

    GameObject[] lifePoints;

    public GameObject pow; 
    public float waitTime;
    public bool hit;

    //Os passos que o gato vai dar
    public float pos;


    void Start()
    {
        //Determinar a largura da camara
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        //Determinar a largura do background e do paceio/estrada
        float Wbg = width * 0.71f;
        float Wstreet = Wbg * 0.4f;
        pos = (Wstreet / 3) / 2;

        //Isto é onde o número de vidas é inserido
        lifePointsN = 3;
        lifePoints = new GameObject[3]
        {
            GameObject.Find("LifePoints/life1"),
            GameObject.Find("LifePoints/life2"),
            GameObject.Find("LifePoints/life3")
        };
       
    }


    // Update is called once per frame
    void Update()
    {
        
        //move up
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 0)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y + pos, transform.position.z + pos);
        }

        //move down
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > -pos*2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - pos, transform.position.z - pos);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        //Se collider com um obstaculo
        if (col.gameObject.CompareTag("Obstacle"))
        {
            //Retira uma vida
            if (lifePointsN > 0)
                lifePointsN = lifePointsN - 1;

            lifePoints[lifePointsN].SetActive(false);

            //Indicador que levou um hit
            StartCoroutine(Powsound());



            //Se os pontos virar a zero
            if (lifePointsN <= 0)
            {
                print("game over");
            }

        }
        if (col.gameObject.CompareTag("Player"))
        {
            print("bbbbb");
        }
    }

     

    private IEnumerator Powsound()
    {
        //ATIVAR O QUAD POW E DESATIVAR DEPOIS DE MEIO SEGUND
        pow.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        pow.SetActive(false);
    }

}