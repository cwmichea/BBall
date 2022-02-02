//using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Security.Cryptography;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    const float upforce = 8f;//physics
    Rigidbody rigid;//component from unity physical properties of the ball
    public float minTranslation = 0.05f;//minimum translation when bouncing the ball
    private GameManager manager;//reference to the singleton :GameManager
    //sound3part
    private AudioSource audioS;//reference to the AudioSource component
    // Start is called before the first frame update
    void Start()
    {
        //3partaudio
        audioS = GetComponent<AudioSource>(); //cache the component audiosource
        //
        rigid = GetComponent<Rigidbody>();
        manager = GameManager.instance;//retrieve the instance of the GameManager in my scene 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 colPos = collision.transform.position;//position of the collision object paddle or walls
        if (collision.transform.tag=="Paddle")
        {
            //calling sound
            audioS.Play();//play the sound
            //
            float diffX = minTranslation + (colPos.x - transform.position.x) * Random.Range(1,10);
            float diffZ = minTranslation + (colPos.z - transform.position.z) * Random.Range(1, 10);
            rigid.velocity = new Vector3(-diffX, upforce, -diffZ);//change the direction of the ball
            //Debug.Log("X : " + diffX+", Z:" + diffZ);
            manager.AddScore();
        }
        else
        {
            //GameOver
            manager.GameOver(this.gameObject);//call the game over function and pass the ball as reference
        }
    }
}
