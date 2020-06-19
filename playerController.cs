using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public GameObject player;
    Rigidbody rb;

    public float movementSpeed;

    public LayerMask groundLayer;
    public float sphereRadius;
    
    public float jumpForce;

    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        // retrieve rb
        rb = player.GetComponent<Rigidbody>();
        sphereRadius = player.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {

        // want to get input

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movementForce = transform.forward * moveVertical + transform.right * moveHorizontal;

        // check if player is touching ground
        isGrounded = Physics.CheckSphere(transform.position, sphereRadius + 1, groundLayer);

        if (isGrounded)
        {
            // apply movement
            rb.AddForce(movementForce * movementSpeed * Time.deltaTime, ForceMode.Impulse);

            // check for space bar input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // make grounded = false
                isGrounded = false;
                rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            }

        }


    }


}
