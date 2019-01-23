using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoControls : MonoBehaviour {

    int lifePointsN;

    GameObject[] lifePoints;

    public GameObject pow; //NÃO SEI SE ISTO ESTÁ EVOCADO BEM, AQUI EU ARRASTEI O QUAD POW
    public float waitTime;
    

    void Start()
    {
        lifePointsN = 3;
        lifePoints = new GameObject[3]
        {
            GameObject.Find("LifePoints/life1"),
            GameObject.Find("LifePoints/life2"),
            GameObject.Find("LifePoints/life3")
        };
    }


    // Update is called once per frame
    void Update () {
		
        //move up
		if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 0.4){

            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
		}

        //move down
		if (Input.GetKeyDown(KeyCode.S) && transform.position.y > -1.5){
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 1);
        }

	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Obstacle"))
        {

            if(lifePointsN > 0)
            lifePointsN = lifePointsN - 1;

            lifePoints[lifePointsN].SetActive(false);


            StartCoroutine(WheelHit());




            if (lifePointsN <= 0)
            {
                print("game over");
            }
            
        }
    }

    private IEnumerator WheelHit ()
    {
        //ATIVAR O QUAD POW E DESATIVAR DEPOIS DE MEIO SEGUND
        pow.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        pow.SetActive(false);
    }

}