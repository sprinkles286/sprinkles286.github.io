﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey("left"))
        {
        transform.Translate(-0.1f,0,0);
        }
        if(Input.GetKey("right"))
        {
        transform.Translate(0.1f,0,0);
        }
        if (Input.GetKey("up"))
        {
            transform.Translate(0f, 0, 0.1f);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0, 0, -0.1f);
        }
    }
}
