using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

    public GameObject Obstacle; //Objecto a ser Spawn
    public float rateSpawn;     // Intervalo de spawn
    public float currentTime;

    private float pos;    // Diferensa entre as posições 
    private float width;   // largura dos limites
    private float height; // Altura dos limites
    public bool Stop;

    // Start is called before the first frame update
    void Start()
    {

        //Determinar a largura da camara
        Camera cam = Camera.main;
         height = 2f * cam.orthographicSize;
         width = height * cam.aspect;

        //Determinar a largura do background e do paceio/estrada
        float Wbg = width * 0.71f;
        float Wstreet = Wbg * 0.4f;
        pos = (Wstreet / 3) / 2;

        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= rateSpawn)
        {
            // Para definir a posição de cada obstaculo
            int randomPos = Random.Range(1, 4);


            if (randomPos == 1)
            {
                currentTime = 0;
                GameObject Spawned = Instantiate(Obstacle) as GameObject;
                Spawned.transform.position = new Vector3(width + 5f, -0.8f, -1f);
            } else if (randomPos == 2)
            {
                currentTime = 0;
                GameObject Spawned = Instantiate(Obstacle) as GameObject;
                Spawned.transform.position = new Vector3(width + 5f, -0.8f - pos, -1f - pos);
            }
            else if (randomPos == 3)
            {
                currentTime = 0;
                GameObject Spawned = Instantiate(Obstacle) as GameObject;
                Spawned.transform.position = new Vector3(width + 5f, -0.8f - pos*2, -1f - pos*2);
            }
        }
    }
}
