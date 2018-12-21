using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour {

	public Renderer bgRend;
	public float bgSpeed;

	// Use this for initialization
	void Start () {
		/*mat = GetComponent<Renderer>().material;
		mat.SetTextureOffset(Vector2.zero, "_MainTex");
        offsetTexture = 0f;*/
	}
	
	// Update is called once per frame
	void Update () {
		
		bgRend.material.mainTextureOffset += new Vector2(bgSpeed*Time.deltaTime, 0f);		
	}
}
