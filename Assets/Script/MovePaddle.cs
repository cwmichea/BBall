using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{

    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 transf = new Vector3();
        transf.x = (Input.GetAxis("Mouse X") * speed) * Time.deltaTime;
        transf.z = (Input.GetAxis("Mouse Y") * speed) * Time.deltaTime;

        transform.Translate(transf);//move the platform
    }
}
