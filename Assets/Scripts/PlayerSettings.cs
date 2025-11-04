using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSettings : MonoBehaviour
{
    
    public string Scene1;
    public string Scene2;
    public string Final;
    public string Merchant;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadScene(Scene1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene(Scene2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneManager.LoadScene(Final);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SceneManager.LoadScene(Merchant);
        }
    }

   
}
