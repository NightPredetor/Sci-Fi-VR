using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XROrigin))]
[RequireComponent(typeof(CharacterController))]
public class ContinuousMovement : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] float moveSpeed;
    [SerializeField] XRNode inputSource;
    #endregion

    #region Private Variables
    private Vector2 inputAxis;
    private Vector3 moveDirection;

    private XROrigin xrOrigin;
    private InputDevice inputDevice;
    private CharacterController characterController;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        xrOrigin = GetComponent<XROrigin>();
        characterController = GetComponent<CharacterController>();

        inputDevice = InputDevices.GetDeviceAtXRNode(inputSource);
    }

    private void Update()
    {
        // Get input with the controller input. 
        inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        // Get direction by calculating the controller input with respect to the camera facing direction.
        moveDirection.x = inputAxis.x * xrOrigin.Camera.transform.eulerAngles.y;
        moveDirection.z = inputAxis.y * xrOrigin.Camera.transform.eulerAngles.y;

        characterController.Move(moveDirection * Time.fixedDeltaTime * moveSpeed);
    }
    #endregion
}
