using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private Animator playerMoving;
    
    
   
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            playerMoving.SetBool("Moving" , true);
        }
        else
        {
            playerMoving.SetBool("Moving" , false);
        }
            
        
    }

    
}
