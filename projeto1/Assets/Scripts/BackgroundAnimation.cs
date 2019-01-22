using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour {

	public Renderer bgRend;
	public float bgSpeed;
    public float tileSizeY;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; 
    }


    // Update is called once per frame
    void Update () {

      //  bgRend.material.mainTextureOffset += new Vector2(bgSpeed*Time.deltaTime, 0f);	
        float newPosition = Mathf.Repeat(Time.time * bgSpeed, tileSizeY);
        transform.position = startPosition + Vector3.left * newPosition;
	}
}
