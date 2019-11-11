using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    static Animator myAnim;
    public float speed = 5.0f;
    public float rotationSpeed = 75.0f;
    Rigidbody rb;


    public CharacterController _controller;

    private Vector3 rotation;


    void Start()
    {
        myAnim = GetComponent<Animator>();
       rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        var right = vertical > 0;
       
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        transform.Translate(movement * speed * Time.deltaTime);
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = transform.TransformDirection(move);
        _controller.Move(move * speed);



        if (_controller.isGrounded)
        {
            
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            myAnim.SetBool("IsWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            myAnim.SetBool("IsWalking", false);
        }
        if (Input.GetKey(KeyCode.R))
        {
            myAnim.SetBool("Running", true);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            myAnim.SetBool("Running", false);
        }

        // Punch, Kick, Roll

        
        if (Input.GetKeyDown("1"))
        {
            myAnim.SetInteger("Punch", 1);
        }
        else if (Input.GetKeyUp("1"))
        {
            myAnim.SetInteger("Punch", 0);
        }
        if (Input.GetKeyDown("2"))
        {
            myAnim.SetInteger("Kick", 1);
        }
        else if (Input.GetKeyUp("2"))
        {
            myAnim.SetInteger("Kick", 0);
        }
        if (Input.GetKeyDown("3"))
        {
            myAnim.SetInteger("Dodge Roll", 1);
        }
        else if (Input.GetKeyUp("3"))
        {
            myAnim.SetInteger("Dodge Roll", 0);
        }

        //Rotate character

        if (horizontal > 0)
        {
            transform.Rotate(this.rotation);
        } else if (horizontal < 0)
        {
            transform.Rotate(this.rotation);
        }
        if (Input.GetKeyDown("space"))
        {
            myAnim.SetBool("Jump", true);

        } else if (Input.GetKeyUp("space")) {
           
            myAnim.SetBool("Jump", false); 
        }
        
        //Strafes
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myAnim.SetBool("Left Strafe", true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            myAnim.SetBool("Left Strafe", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myAnim.SetBool("Right Strafe", true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            myAnim.SetBool("Right Strafe", false);
        }




    }
}
