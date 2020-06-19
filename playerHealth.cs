using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    float health, maxHealth = 1000f;
    public int enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        // keep maxHealth because health bars
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        //check if enemy
        if (collision.collider.gameObject.layer == enemyLayer)
        {
            // deal damage
            collision.collider.gameObject.GetComponent<enemyHealth>().TakeDamage(Random.Range(15, 20));

            // knockback
            collision.collider.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce((collision.collider.gameObject.transform.position - transform.position).normalized * 10, ForceMode.Impulse);

            // take damage
            TakeDamage(Random.Range(1,5));
        }
    }

    public void TakeDamage(float damage)
    {
        // take away health
        health -= 0.1f;
    }
}
