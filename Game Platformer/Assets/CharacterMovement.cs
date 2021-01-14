using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float addGrav;
    [SerializeField] private LayerMask ground;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
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
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);
            //rb.gravityScale = addGrav;
        }
        else if(Input.GetButtonDown("Jump"))
        {
            //rb.gravityScale = addGrav;

        }
        //Void (if it foes below y - 8)
        if(transform.position.y < -8)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

    }
    
}
