using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClone : MonoBehaviour
{
    [SerializeField] private GameObject GameObjectToBeCloned;
    public int clonestomake;
    public GameObject GameObjectClone;
    public int clones = 0;
    public void Clone()
    {
        if(clones < clonestomake)
        {
            Debug.Log("cloned");
            GameObjectClone = Instantiate(GameObjectToBeCloned, new Vector3(0, 0.5f, 0), GameObjectToBeCloned.transform.rotation);
            clones += 1;
            GameObjectClone.name = "" + clones;
            GameObjectClone.GetComponent<ObjectClone>().clones = clones;
        }
    }
}
