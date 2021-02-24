using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fireball")
        {
            health -= 1;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
