using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    private enum State {idle, running, jumping}
    private State state = State.idle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        float hdirection = Input.GetAxis("Horizontal");

        transform.Rotate()transform.Rotate(transform.rotation.x, transform.rotation.y, 0)
        if(hdirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(hdirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else 
        {
        }
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10);
            state = State.jumping;
        }
        VelocityState();
        anim.SetInteger("state", (int)state);
    }

    private void VelocityState()
    {
        /*
        if(state == State.jumping)
        {

        }
        */
        if(Mathf.Abs(rb.velocity.x) > 1f)
        {
            // Moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
