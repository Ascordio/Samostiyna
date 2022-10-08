using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    private bool doJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !doJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            doJump = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            doJump = false;
        }
    }
}
