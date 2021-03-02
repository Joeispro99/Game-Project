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
    [SerializeField] private SpriteRenderer blur;
    [SerializeField] private Transform blurtransform;
    [SerializeField] private Transform playertransform;
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
                blur.color = new Color(1f,1f,1f,0.5f);
                blurtransform.position = playertransform.position;
                pause = true;
            } else if(pause == true)
            {
                playerrb.bodyType = RigidbodyType2D.Dynamic;
                petrb.bodyType = RigidbodyType2D.Dynamic;
                firerb.bodyType = RigidbodyType2D.Dynamic;
                blur.color = new Color(1f,1f,1f,0f);
                pause = false;
            }
        }
    }
}
