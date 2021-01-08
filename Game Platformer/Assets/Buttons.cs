using UnityEngine;

public class Buttons : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("pressed something");
        if (transform.parent.name == "left")
        {
            print("LEFT");
            CharacterMovement.leftOrNot = true;
            print("LEFT");
        }
        else if (transform.parent.name == "right")
        {
            print("RIGHT");
            CharacterMovement.rightOrNot = true;
            print("RIGHT");
        } else 
        {
            return;
        }
    }
    
}
