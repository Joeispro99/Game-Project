using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyFollow : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(characterTransform.position.x, characterTransform.position.y, 0);
    }
}
