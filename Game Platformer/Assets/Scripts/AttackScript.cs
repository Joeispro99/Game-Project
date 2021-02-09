using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private bool fireballAnimationPlaying = false;
    [SerializeField] private CharacterMovement character;
    [SerializeField] private Transform characterTransform;
    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("collided");
    //     if(collision.gameObject.tag == "Spike")
    //     {
    //         Debug.Log("collided with ground");
    //         GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    //         GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
    //     }
    // }
    private void Update()
    {
        if(character.state == CharacterMovement.witchState.fire)
        {
            if(characterTransform.localScale.x == 0.3f)
            {
                transform.position = new Vector3(characterTransform.transform.position.x+1f, characterTransform.transform.position.y, characterTransform.transform.position.z);
                transform.localScale = new Vector2(1f,1f);
            } else if(characterTransform.localScale.x == -0.3f)
            {
                transform.position = new Vector3(characterTransform.transform.position.x-1f, characterTransform.transform.position.y, characterTransform.transform.position.z);
                transform.localScale = new Vector2(-1f,1f);
            }
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            do
            {
                if(fireballAnimationPlaying) break;
                GetComponent<Animator>().Play("Fireball-Appear");
            } while (false);
            StartCoroutine(waitForAWhile());
        }
    }
    IEnumerator waitForAWhile()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fireball-Appear"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            GetComponent<Animator>().Play("Fireball-Move");
            if(characterTransform.localScale.x == 0.3f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + 2f, GetComponent<Rigidbody2D>().velocity.y);
            } else if(characterTransform.localScale.x == -0.3f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - 2f, GetComponent<Rigidbody2D>().velocity.y);                
            }
        }
    }
}
