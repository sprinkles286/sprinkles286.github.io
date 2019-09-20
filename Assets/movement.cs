using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
public float health = 6;
    

    //If your GameObject keeps colliding with another GameObject with a Collider, do something
    void OnCollisionEnter(Collision collision)
    {
        //Check to see if the Collider's name is "Chest"
        if (collision.collider.name == "Damage")
        {
            //Output the message
            Debug.Log(health -= 1);
        }
        if (collision.collider.name == "Goal")
        {
            //Output the message
            Debug.Log("You Win!");
        }
        if (collision.collider.name == "Heal")
        {
            Debug.Log(health += 1);
        }
        if (health == 0)
        {
            Debug.Log("You Lose!");
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,0.06f);

        if(Input.GetKey("left"))
        {
        transform.Translate(-0.1f,0,0);
        }
        if(Input.GetKey("right"))
        {
        transform.Translate(0.1f,0,0);
        }
        // if(Input.GetKey("up"))
        // {
        // transform.Translate(-0.1f,0,0);
        // }
        // if(Input.GetKey("down"))
        // {
        // transform.Translate(0.1f,0,0);
        // }
    }
}
