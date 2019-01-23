using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    //public Renderer bgRend;
    public float bgSpeed;
    //public GameObject obst;


    private Quaternion targetRotation;


    // Update is called once per frame
    void Update() {

        transform.position += new Vector3(-bgSpeed * Time.deltaTime, 0f, 0f);


    }

    private void OnEnable()
    {
        StartCoroutine(waitForDesable());
    }

    private IEnumerator waitForDesable()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            //EMPURRAR O CAIXOTE DO LIXO
                //PARA NÃO HAVER CONFLITO AS BOX COLLIDERS DOS OBSTACULOS E DO CHICO PRECISAM DE SER 0.05
            transform.position += new Vector3(+20f * Time.deltaTime, 0f, 0.05f);
        }
    }

}
