using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    private enum witchState {idle, walking, fire, lightning}
    //Brayden's variables
    /*
    private float FireOn = 0;
    private float LightOn = 0;
    */
    //To here
    private witchState state = witchState.idle;
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask ground;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
        if (Input.GetKeyDown("w") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);
        }
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);

        }
        if(Input.GetAxis("Fire1") > 0) 
        {
            state = witchState.fire;
        }
        //Brayden did this
        /*
        if (Input.GetKeyDown("q"))
        {
            if (FireOn == 0){
                state = witchState.fire;
                FireOn = 1;
            }
            else{
                state = witchState.idle;
                FireOn = 0;

            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (LightOn == 0){
                state = witchState.lightning;
                LightOn = 1;
            }
            else{
                state = witchState.idle;
                LightOn = 0;

            }
        }
        */
        //to this (I wanted to make it so I could activate them)
        if(Input.GetAxis("Fire2") > 0)
        {
            state = witchState.lightning;
        }
        if(transform.position.y < -8)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        VelocityState();
        anim.SetInteger("state", (int)state);

    }
    private void VelocityState()
    {
        /*
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
        */
        if(state == witchState.fire)
        {
            return;
        }
        if(state == witchState.lightning)
        {
            return;
        }
        if(Mathf.Abs(rb.velocity.x) > 1f)
        {
            // Moving
            state = witchState.walking;
        }
        else
        {
            state = witchState.idle;
        }
    }
    
}
