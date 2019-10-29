using UnityEngine;

public class movement : MonoBehaviour

{
    Rigidbody rb;
    public float forceAmt = 80f;
    public int score;
    public TextMesh myText;
  //  public TextMesh deathText;
   public Transform playerPiece;
    public Vector3 playerStart;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      playerStart = playerPiece.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            myText.text = "Score: " + score + System.Environment.NewLine + "Lives: " + lives;
        }

        if (score == 7)
        {
            myText.text = "You Win! " + System.Environment.NewLine + "Final Score: " + score + " | Rem. Lives: " + lives;
        }
        // add force to the object/rigidbody to cause movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey("up"))
        {
            rb.AddForce(new Vector3(0f, 0f, 0.2f) * forceAmt);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
        {
            rb.AddForce(new Vector3(-0.2f, 0f, 0f) * forceAmt);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey("down"))
        {
            rb.AddForce(new Vector3(0f, 0f, -0.2f) * forceAmt);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
        {
            rb.AddForce(new Vector3(0.2f, 0f, 0f) * forceAmt);
        }


    }
    //collision with collectibles
    void OnCollisionEnter(Collision colReport)
    {
        if (colReport.gameObject.CompareTag("collectible"))
        {
            Destroy(colReport.gameObject);
            score += 1;
        }
        if (colReport.gameObject.CompareTag("enemy"))
        {
            lives -= 1;
            playerPiece.position = playerStart;
        }
        if (lives == 0)
        {
            myText.text = "You Lose! Press any key to continue";
            Destroy(transform);
        }
    }

}
