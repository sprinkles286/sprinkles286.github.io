using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private float JumpSpeed = 6;
    Rigidbody rb;
    private bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && onGround == true)
        {
            rb.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
            onGround = false;
        }    }
    void OnCollisionEnter(Collision colGround)
    {
        onGround = true;
    }
}
