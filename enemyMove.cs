using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    [SerializeField]
    float speed, jumpForce;
    public int groundLayer;
    public GameObject player;

    Rigidbody rb;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        // get rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get direction
        direction = (player.transform.position - transform.position).normalized * speed * Time.deltaTime;

        // apply force
        rb.AddForce(direction.x, 0f, direction.z, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check if colliding with ground
        if (collision.collider.gameObject.layer == groundLayer)
        {
            // execute jump
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
        }
    }
}
