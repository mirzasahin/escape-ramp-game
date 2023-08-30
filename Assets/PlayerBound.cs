using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour
{
    private float playerBound = 3.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -playerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -playerBound);
        }

        if (transform.position.z > playerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, playerBound);
        }


    }
}
