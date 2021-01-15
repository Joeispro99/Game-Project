using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    [SerializeField] private int cherries = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Text cherryText;
    [SerializeField] private float hurtForce = 10f;

    private enum State {idle, running, jumping, falling, hurt}
    private State state = State.idle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            cherries += 1;
            cherryText.text = cherries.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if(state == State.falling)
            {
                rb.velocity = new Vector2(rb.velocity.x, hurtForce);
                Destroy(other.gameObject);
            } else
            {
                state = State.hurt;
                if(other.gameObject.transform.position.x > transform.position.x)
                {
                    //Enemy is to my right, get hurt and move left
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                } else {
                    //Enemy is to my left, get hurt and move right
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
            
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(state != State.hurt)
        {

        }
        Movement();
        VelocityState();
        anim.SetInteger("state", (int)state);
    }

    private void Movement()
    {
        float hdirection = Input.GetAxis("Horizontal");

        transform.rotation = new Quaternion(0f, 0f, 0f, transform.rotation.w);
        if(hdirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(hdirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else 
        {
        }
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < 0.5f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f){
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > 1f)
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
