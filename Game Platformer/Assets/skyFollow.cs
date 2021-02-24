using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyFollow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D characterrb;
    [SerializeField] private Transform charactertransform;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = characterrb.velocity;
    }
    void LateUpdate()
    {
        //go back to original position every second
        StartCoroutine(WaitForOneSecond());
    }
    private IEnumerator WaitForOneSecond()
    {
        yield return new WaitForSeconds(1
        );
        transform.position = new Vector3(charactertransform.position.x, charactertransform.position.y, charactertransform.position.z);
    }
}
