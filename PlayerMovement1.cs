using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float movementSpeed=6f;
    
    [SerializeField]float jumpForce=5f;
    [SerializeField]Transform groundCheck;
    [SerializeField]LayerMask ground;
    [SerializeField]AudioSource jumpSound;
    
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");

        rb.velocity=new Vector3(horizontal*movementSpeed, rb.velocity.y, vertical*movementSpeed);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
           Jump();
        }
    }
        void Jump(){
            rb.velocity=new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
            jumpSound.Play();
        }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, .1f,ground );
    }
}
