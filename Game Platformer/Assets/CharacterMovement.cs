using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static bool leftOrNot = false;
    public static bool rightOrNot = false;
    
    private void Update()
    {
        if (leftOrNot == true) {
            transform.position = new Vector3(transform.position.x - 5, transform.position.y, 0);
            leftOrNot = false;
        }
        if (rightOrNot == true) {
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, 0);
            rightOrNot = false;
        }
    }
}
