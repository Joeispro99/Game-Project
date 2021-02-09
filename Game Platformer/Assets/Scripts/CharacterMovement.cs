using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CharacterMovement : MonoBehaviour
{
    public enum witchState {idle, walking, fire, lightning}
    //Brayden's variables
    /*
    private float FireOn = 0;
    private float LightOn = 0;
    */
    //To here
    public witchState state = witchState.idle;
    private Rigidbody2D rb;
    [SerializeField] private Collider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private SpriteRenderer checkpointSprite;
    [SerializeField] private Transform checkpointTransform;
    public Sprite flagRed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if(checkpointSprite.sprite == flagRed)
            {
                transform.position = new Vector3(checkpointTransform.position.x,checkpointTransform.position.y+1,checkpointTransform.position.z);
                rb.velocity = new Vector2(0,0);
            } else {
                SceneManager.LoadScene(currentSceneName);
            }
        }
        if(collision.gameObject.tag == "Enemy")
        {
            // insert knockback
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            checkpointSprite.sprite = flagRed;
        }
    }
    private void Update()
    {
        float hdirection = Input.GetAxis("Horizontal");

        transform.rotation = new Quaternion((float)transform.rotation.x, (float)transform.rotation.y, 0f, (float)transform.rotation.w);
        if(hdirection < 0)
        {
            rb.velocity = new Vector2(-1*speed, rb.velocity.y);
            transform.localScale = new Vector2(-1*(float)0.3, transform.localScale.y);
        }
        else if(hdirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2((float)0.3, transform.localScale.y);
        } 
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if ((Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)) || (Input.GetKeyDown("w") && coll.IsTouchingLayers(ground)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);   
        }
        if (Input.GetAxis("Fire1") > 0) 
        {
            state = witchState.fire;
            //throw new Exception("State has been changed");
            StartCoroutine(waitForAWhile());
        }
        if(Input.GetAxis("Fire2") > 0)
        {
            state = witchState.lightning;
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
        if(transform.position.y < -20)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if(checkpointSprite.sprite == flagRed)
            {
            transform.position = new Vector3(checkpointTransform.position.x,checkpointTransform.position.y,checkpointTransform.position.z);
            rb.velocity = new Vector2(0,0);
            } else {
            SceneManager.LoadScene(currentSceneName);
            }
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
    
    // experimental
    // private IEnumerator waitfor83milliseconds()
    // {
    //     yield return new WaitForSeconds(0.083f);
    // }

    IEnumerator waitForAWhile()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("witch-fire"))
        {
            // Avoid any reload.
            state = witchState.idle;
        }
    }
    
}
