using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    [SerializeField] private Transform charactertransform;
    [SerializeField] private Rigidbody2D characterrb;
    [SerializeField] private Rigidbody2D rb;
    private void Update()
    {
        float hdirection = Input.GetAxis("Horizontal");

        if(hdirection > 0)
        {
            transform.position = new Vector3(charactertransform.transform.position.x - (float)1.5, charactertransform.transform.position.y - (float)0.3, charactertransform.transform.position.z);
            rb.velocity = new Vector2(characterrb.velocity.x, characterrb.velocity.y);
            transform.localScale = new Vector2(-1*(float)0.38865, transform.localScale.y);
        } else if(hdirection < 0)
        {
            transform.position = new Vector3(charactertransform.transform.position.x + (float)1.5, charactertransform.transform.position.y - (float)0.3, charactertransform.transform.position.z);
            rb.velocity = new Vector2(characterrb.velocity.x, characterrb.velocity.y);
            transform.localScale = new Vector2((float)0.38865, transform.localScale.y);
        } else 
        {
            rb.velocity = new Vector2(characterrb.velocity.x, characterrb.velocity.y);
        }
    }
}
