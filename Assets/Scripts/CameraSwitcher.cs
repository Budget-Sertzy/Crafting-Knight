using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineCamera camera1;
    public Camera camera2;
    
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Press 'C' to switch
        {
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        camera1.enabled = !camera1.enabled;
        camera2.enabled = !camera2.enabled;
    }
}
