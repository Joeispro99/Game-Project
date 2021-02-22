using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] private string buttonType;
    [SerializeField] private Rigidbody2D playerrb;
    [SerializeField] private Rigidbody2D petrb;
    [SerializeField] private Rigidbody2D firerb;
    public bool pause = false;
    
    public void OnButtonPress()
    {
        if(buttonType=="button1")
        {
            SceneManager.LoadScene("SampleScene");
        }
        if(buttonType=="pause")
        {
            if(pause == false)
            {
                playerrb.bodyType = RigidbodyType2D.Static;
                petrb.bodyType = RigidbodyType2D.Static;
                firerb.bodyType = RigidbodyType2D.Static;
                pause = true;
            } else if(pause == true)
            {
                playerrb.bodyType = RigidbodyType2D.Dynamic;
                petrb.bodyType = RigidbodyType2D.Dynamic;
                firerb.bodyType = RigidbodyType2D.Dynamic;
                pause = false;
            }
        }
    }
}
