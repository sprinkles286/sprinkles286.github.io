using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour

{
    //public Vector3 pos = new Vector3(5f,10,15f);
    public TextMesh playerMSG;
    public Vector3 playerStart;
    public Transform obstacle, hazard;
    float tileAmount = 1f;
    public Transform playerPiece;
    public Transform[] manyHazards; 
    public Transform[] manyObstacles;
    // Start is called before the first frame update
    void Start()
    {
playerStart = playerPiece.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = playerPiece.position;

        // if(Input.anyKeyDown)
        // {
        //     playerMSG.text = "welcome";
        // }
        if (Input.GetKeyDown("left"))
        {
            newPos += new Vector3(-tileAmount, 0f, 0f);
            
        }
        if (Input.GetKeyDown("right"))
        {

            newPos += new Vector3(tileAmount, 0f, 0f);
       }
           
        if (Input.GetKeyDown("up"))
        {
            newPos += new Vector3(0f, 0f, tileAmount);

        }
        if (Input.GetKeyDown("down"))
        {

            newPos += new Vector3(0f, 0f, -tileAmount);
       }
       if (obstacle.position != newPos)
       {

       playerPiece.position = newPos;
       }

       if(hazard.position == playerPiece.position)
       {
           playerPiece.position = playerStart;
       }

            for (int i = 0; i < manyHazards.Length; i++)
            {
                if (manyHazards[i].position == playerPiece.position)
                {
                    playerPiece.position = playerStart;
                }
            }
            for (int i = 0; i < manyObstacles.Length; i++)
            {
                if (manyObstacles[i].position != newPos)
                {
                playerPiece.position = newPos;
                }
            }

            
       
    }
}
