using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera thirdPersonCam;
    public Camera firstPersonCam;
    public PlayerMovement player;

    private bool isFirstPerson = false;

    void Start()
    {
        SetThirdPerson();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isFirstPerson)
                SetThirdPerson();
            else
                SetFirstPerson();
        }
    }

    void SetFirstPerson()
    {
        thirdPersonCam.enabled = false;
        firstPersonCam.enabled = true;

        player.SetCamera(firstPersonCam.transform);
        isFirstPerson = true;
    }

    void SetThirdPerson()
    {
        firstPersonCam.enabled = false;
        thirdPersonCam.enabled = true;

        player.SetCamera(thirdPersonCam.transform);
        isFirstPerson = false;
    }
}
