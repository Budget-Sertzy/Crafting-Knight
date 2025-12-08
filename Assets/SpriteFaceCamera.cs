using UnityEngine;

public class SpriteFaceCamera : MonoBehaviour
{
  private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (cam == null) return;

        Vector3 camForward = cam.transform.forward;
        camForward.y = 0f;           // stay upright
        camForward.Normalize();

        transform.forward = camForward;
    }
}
