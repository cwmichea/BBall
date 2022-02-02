using System.Collections;
using System.Collections.Generic;

//using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;//reference that every script cna use to refer this specific object

    private int score = 0;//this is the score value
    public string preTextScore = "SCORE";//the default textfield filler. "Score"
    const int pointsPerBounce = 100;//how many points I score per bounce
    public Text txtScore;
    //2part
    const float timeScaleLimit = 3.0f;//max value
    //3part
    public GameObject smoke;//Smoke effect when it dies

    private float oldTime = 0f;//oldTime =0 or current timeScale
    public GameObject btnRetry;//reference to the button retry
    public GameObject btnExit;//reference to the button exit
    public string sceneToReload = "SampleScene";//thename of the scene to reload
    private bool gameOver = false; 

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);//if you are not he main instance of the script, autodestruction
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //3parttoo
        Cursor.lockState = CursorLockMode.Locked;//Freese the cursor in the middle of the screen
        Cursor.visible = false;//hide the cursor
        //
        txtScore.text = preTextScore + score.ToString("D8");//Score 0000 0000
        //3part
        btnExit.SetActive(false); //by default we hide the button
        btnRetry.SetActive(false);
    }
    //3part
    public void Quit()
    {
        // Application.Quit();//exit the game THIS IS FOR THE BUILD ONLY


#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif

    }
    public void Retry()
    {
        SceneManager.LoadScene(sceneToReload);//reload the scene esiest way that everything is in place
    }

    //2part
    //void IncreaseDiff()

    public void AddScore()
    {
        score += pointsPerBounce;//increase the score by 100
        txtScore.text = preTextScore + score.ToString("D8");//Score 0000 0000
    }
    //3part
    public void GameOver(GameObject ball)
    {
        smoke.transform.position = ball.transform.position;//move the smoke where the ball was.
        Destroy(ball);//remove the ball from the game
        Time.timeScale = 1.0f;//set the timeScale back to normal
        smoke.GetComponent<ParticleSystem>().Play();//play the particle system
        smoke.GetComponent<AudioSource>().Play();//play the particle system audio clip

        if (!gameOver)
        {
            gameOver = true;
            btnExit.SetActive(true);//enable the button
            btnRetry.SetActive(true);//enable the button
            //newthing
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel")&&!gameOver)
        {
            float prevTime = oldTime;//cache
            oldTime = Time.timeScale;
            Time.timeScale = prevTime;

            //if(Time)

            //new thing other part
            Cursor.lockState = (Time.timeScale > 0f) ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = (Time.timeScale > 0f) ? false : true;
        }
    }
}
