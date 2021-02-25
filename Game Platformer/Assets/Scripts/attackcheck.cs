using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackcheck : MonoBehaviour
{
    public bool attackdies = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fireball")
        {
            attackdies = true;
        }
    }
}
