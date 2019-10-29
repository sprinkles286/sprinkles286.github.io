using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibles : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    private float forceAmt = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = Vector3.Normalize(transform.position - target.position);
        rb.AddForce(targetDir * forceAmt);
    }
}
