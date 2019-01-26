using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Act : MonoBehaviour
{

    //Ui variaveis
    private int metros;
    private Text textmetros;
    private Text GameOverText;
    private Text RestartText;

    //Background script
    public BackgroundAnimation bg;

    private float count;

    //Brutos gameOnject, position e script
    private GameObject Dog;
    private DogBehaviourScript stopDog;
    private Transform DogPos;

    // Game Over variavel 
    private bool endgame;


    // Start is called before the first frame update
    void Start()
    {
        metros = 0;
        endgame = false;

        Dog = GameObject.Find("Brutos");
        DogPos = Dog.GetComponent<Transform>();

        if (Dog != null) // verificar se o Cão existe
        {
            stopDog = Dog.GetComponent<DogBehaviourScript>();
        }
        if (stopDog == null) // verificar se o script existe
        {
            Debug.Log("Cannot find 'DogBehaviourScript' script");
        }


        //Determinar a largura da camara
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        DogPos.position = new Vector3(-width, DogPos.position.y, DogPos.position.z);
        stopDog.enabled = false;
        Dog.SetActive(false);

        //Metros
        GameObject score = GameObject.Find("Canvas/MeterCounter/numbers");
        textmetros = score.GetComponent<Text>();

        //Game Over texto
        GameObject over = GameObject.Find("Canvas/GameOver");
        GameOverText = over.GetComponent<Text>();

        //Game Over texto
        GameObject re = GameObject.Find("Canvas/ReStart");
        RestartText = re.GetComponent<Text>();

        GameOverText.text = "";
        RestartText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
        if(endgame == false)
        {
            count += Time.deltaTime;

            if(metros >= 30)
            WakeUpDog();


            metros = Mathf.RoundToInt(count);

            textmetros.text = metros + " m";
        }
        else
        {
            GameOverText.text = "Game Over";
            RestartText.text = "Press 'R' to restart Game or 'space' to quit game";
           
            //restart game
            if (Input.GetKeyDown(KeyCode.R))
            {
 
                SceneManager.LoadScene("SampleScene");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
        }
    }

    private void WakeUpDog()
    {
        // Reactivar o cão
        Dog.SetActive(true);

        if (DogPos.position.x <= -7.04f)
            DogPos.position = new Vector3(DogPos.position.x + 4*Time.deltaTime, DogPos.position.y, DogPos.position.z);


        if (DogPos.position.x >= -7.04f)
             stopDog.enabled = true;
    }

    public bool StopObs()
    {
        return endgame;
    }

    public void GameOver()
    {
        FindObjectOfType<AudioController>().Play("GameOver");
        Dog.SetActive(false);
        bg.enabled = false;
        gameObject.GetComponent<PoolManager>().enabled = false;
        endgame = true;

    }

}
