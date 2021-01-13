using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float hdirection = Input.GetAxis("Horizontal");

        transform.rotation = new Quaternion((float)transform.rotation.x, (float)transform.rotation.y, 0f, (float)transform.rotation.w);
        if(hdirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1*(float)0.33351, transform.localScale.y);
        }
        else if(hdirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2((float)0.33351, transform.localScale.y);
        } 
        else if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10);

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

    }
    
}
