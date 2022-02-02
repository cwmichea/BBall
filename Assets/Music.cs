using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public bool dontInterrupt = true;
    public static Music instance = null;//reference to the singleton Music
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!= this)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        if (dontInterrupt)
        {
            Object.DontDestroyOnLoad(this.gameObject);//preserve the object when moving to a new scene
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
