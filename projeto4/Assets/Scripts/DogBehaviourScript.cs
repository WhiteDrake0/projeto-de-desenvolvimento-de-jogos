using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviourScript : MonoBehaviour
{
    public Transform target; //the enemy's target
    public float currentTime; // o tempo corrent
    public float rateOfAttake; // o tempo para o proximo ataque
    public float count; // contagem do tempo
    public float Delay; // Duração do delay
    public bool vertical;
    public bool horizontal;
    public bool accao;
    public bool accao2;
    public bool fallow;
    private Animator animate;
    public int rnd;


    void Start()
    {
        currentTime = 0;
        animate = gameObject.GetComponent<Animator>();
        GameObject obj = GameObject.Find("Chico");
        target = obj.GetComponent<Transform>();
        fallow = true;

    }

    // Update is called once per frame
    void Update()
    {
            currentTime += Time.deltaTime;

            // variavel random
            if (currentTime >= rateOfAttake && fallow)
                rnd = Random.Range(1, 3);

            // Perseguir o jogador 
            if (transform.position.y != target.position.y && fallow)
            {
                transform.position = new Vector3(transform.position.x, target.position.y + 1.501f, target.position.z);
            }

            //animações
            if (rnd == 1 && vertical == false && horizontal == false && accao == false)
            {
                fallow = false;
                horizontal = true;

            }


            //Horizontal ataque delay
            if (horizontal)
            {

                count += Time.deltaTime;
                if (count >= Delay)
                {

                    horizontal = false;
                    accao = true;
                    FindObjectOfType<AudioController>().Play("swing");
            }
            }

            //Horizontal ataque
            if (accao && accao2 == false)
            {
                count += Time.deltaTime;
                if (count >= Delay + 0.4f)
                {
                    count = 0;
                    rnd = 0;
                    currentTime = 0;
                    accao = false;
                    StartCoroutine(FallowPlayer());
                }
            }


            if (rnd == 2 && vertical == false && horizontal == false && accao2 == false)
            {
                fallow = false;
                vertical = true;

            }


        // Delay do ataque vertical
        if (vertical)
            {
                count += Time.deltaTime;
                if (count >= Delay)
                {

                    vertical = false;
                    accao2 = true;
                    FindObjectOfType<AudioController>().Play("swing");

            }
            }

        //taque vertical
        if (accao2 && accao == false)
            {
                count += Time.deltaTime;



                if (count >= Delay + 0.4f)
                {
                    count = 0;
                    rnd = 0;
                    currentTime = 0;
                    accao2 = false;

                    //Para retumar a perseguição
                    StartCoroutine(FallowPlayer());
                }
            }

           

       

        animate.SetBool("Delay Horizontal", horizontal);
        animate.SetBool("Horizontal", accao);
        animate.SetBool("Delay vertical", vertical);
        animate.SetBool("vertical", accao2);
    }

    private IEnumerator FallowPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        fallow = true;
    } 


}
