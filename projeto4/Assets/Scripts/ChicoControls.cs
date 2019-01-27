using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoControls : MonoBehaviour {

    int lifePointsN;

    GameObject[] lifePoints;

    public GameObject pow; 
    public float waitTime;
    public bool hit;

    //GameOver
    public Act endact;
    public GameObject manager;


    //Os passos que o gato vai dar
    public float pos;

    //Animação de slide 
    private Animator animate;
    public bool slide;
    public float timeslide;
    public float tim;

    //Para invulnerabilidade
    Renderer rend;
    Color c;



    void Start()
    {

        endact = manager.GetComponent<Act>();
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
            GameObject.Find("Canvas/Lifepoints/life 1"),
            GameObject.Find("Canvas/Lifepoints/life 2"),
            GameObject.Find("Canvas/Lifepoints/life 3")
        };

        //Animação 
        animate = gameObject.GetComponent<Animator>();

        // frames de invulnerebilidade
        rend = gameObject.GetComponent<Renderer>();
        c = rend.material.color;

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

        //slide
        if (Input.GetKeyDown(KeyCode.D))
        {
            slide = true;
            tim = 0;

            FindObjectOfType<AudioController>().Play("Slide");
        }

        if (slide)
        {
            tim += Time.deltaTime;
            if(tim >= timeslide)
            {
                slide = false;
            }
        }


        animate.SetBool("slide", slide);

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
            StartCoroutine(Powsound(col));


            FindObjectOfType<AudioController>().Play("HitTrash");
            //Se os pontos virar a zero
            if (lifePointsN <= 0)
            {
                endact.GameOver();
                animate.SetBool("DeathByHazard", true);
                FindObjectOfType<AudioController>().Play("Fall");
            }

        }

        if (col.gameObject.CompareTag("Hazard"))
        {
            //Retira uma vida
            if (lifePointsN > 0)
                lifePointsN = lifePointsN - 1;

            lifePoints[lifePointsN].SetActive(false);

            FindObjectOfType<AudioController>().Play("HitBat");
            //Indicador que levou um hit
            StartCoroutine(Powsound(col));



            //Se os pontos virar a zero
            if (lifePointsN <= 0)
            {
                endact.GameOver();
                animate.SetBool("DeathbyBat", true);
                FindObjectOfType<AudioController>().Play("Fall");
            }

        }
    }

     

    private IEnumerator Powsound(Collider other)
    {
        //ATIVAR O QUAD POW E DESATIVAR DEPOIS DE MEIO SEGUND

        Physics.IgnoreLayerCollision(8, 9, true);
        Physics.IgnoreLayerCollision(8, 10, true);
        c.a = 0.5f;
        rend.material.color = c;
        pow.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        pow.SetActive(false);
        Physics.IgnoreLayerCollision(8, 9, false);
        Physics.IgnoreLayerCollision(8, 10, false);
        c.a = 1f;
        rend.material.color = c;
    }

}