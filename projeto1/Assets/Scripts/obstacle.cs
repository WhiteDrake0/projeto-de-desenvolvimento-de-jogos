using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    //public Renderer bgRend;
    public float bgSpeed;
    //public GameObject obst;





    void Start()
    {
        //mov = gameObject.GetComponent<Rigidbody>();
        //InvokeRepeating("newObst", 5f, 2f);

        

    }

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
}
