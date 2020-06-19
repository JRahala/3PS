using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField]
    float health, maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        // set health
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        // change health
        health -= damage;

        //check if enemy dead
        if (health <= 0)
        {
            // remove from game
            Destroy(transform.parent.gameObject);
        }
    }
}
