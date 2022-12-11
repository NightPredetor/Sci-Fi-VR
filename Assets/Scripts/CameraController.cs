using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Serialized Fields
    [Header("Speed Parameters")]
    [SerializeField] float turnSpeed; // How fast the camera rotates.
    [SerializeField] float mouseSensitivity; // How much the camera rotates.

    // Limits up and down rotation.
    [Header("X Clamp Parameters")]
    [SerializeField] float xUpperClamp;
    [SerializeField] float xLowerClamp;
    #endregion

    #region Private Variables
    private Vector3 rotation;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        // Hide mouse pointer and confine it to the game window.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LateUpdate()
    {
        // Get rotation from mouse, multiplied by .
        rotation.y += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotation.x += -Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Clamp value to limit in X direction.
        if (rotation.x > xUpperClamp)
        {
            rotation.x = xUpperClamp;
        }
        else if (rotation.x < xLowerClamp)
        {
            rotation.x = xLowerClamp;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), turnSpeed * Time.deltaTime);
    }
    #endregion
}
