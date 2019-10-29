using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float tileAmount = 1f;
    public Transform key, goal;
    public Transform[] obstacles;
    public Transform[] hazards;
    public Vector3 playerStart, keyStart, goalStart;
    public TextMesh playerMsg;
    public AudioClip deathClip, winClip, keyClip, deniedClip, moveClip;
    public AudioSource myAud;
    bool hasKey = false;
    bool reachedGoal = false;
    

    // Start is called before the first frame update
    void Start()
    {
        playerStart = transform.position;
        keyStart = key.position;
        goalStart = goal.position;
    }

    // Update is called once per frame
  private  void Update()
    {// movement
        Vector3 newPos = transform.position;
        var left = Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A);
        var right = Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D);
        var up = Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W);
        var down = Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S);

        if (left || right || up || down)
        {
            myAud.PlayOneShot(moveClip, 1f);
            playerMsg.text = "Acquire key to reach goal";
            if(hasKey)
            {
                playerMsg.text = "Key Obtained!";
                if(reachedGoal)
                {
                    playerMsg.text = "You win!";
                }

            }

        }
        if (left)
        {
            newPos += new Vector3(-tileAmount, 0f, 0f);
        }
        if (right)
        {
            newPos += new Vector3(tileAmount, 0f, 0f);
        }
        if (up)
        {
            newPos += new Vector3(0f, 0f, tileAmount);
        }
        if (down)
        {
            newPos += new Vector3(0f, 0f, -tileAmount);
        }
        if (SpaceEmpty(newPos))
        {
            transform.position = newPos;
        }

        // gameplay controls
        if (key.position == transform.position)
        {
            myAud.PlayOneShot(keyClip, 1f);
            key.position = new Vector3(999f, 999f, 999f);
         //   playerMsg.text = "Key obtained!";
            hasKey = true;
        }
        if (goal.position == newPos)
        {
            if (hasKey)
            {
                reachedGoal = true;
           //     playerMsg.text = "You win!";
                myAud.PlayOneShot(winClip, 1f);
                goal.position = new Vector3(999f, 999f, 999f);
            }
        } 
        
        for (int i = 0; i < hazards.Length; i++)
        {
            if (hazards[i].position == transform.position)
            {
                myAud.PlayOneShot(deathClip, 1f);
                hasKey = false; reachedGoal = false;
                key.position = keyStart; goal.position = goalStart;
                transform.position = playerStart;
            }
        }

    } //end of Update 
    private bool SpaceEmpty(Vector3 position)
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (obstacles[i].position == position)
            {
                myAud.PlayOneShot(deniedClip, 1f);
                return false;
            }
        }
        return true;
    }
}
   

