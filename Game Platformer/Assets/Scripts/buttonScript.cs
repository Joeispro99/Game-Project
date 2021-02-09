using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] private string buttonType;
    
    public void OnButtonPress()
    {
        if(buttonType=="button1")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
