using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] float moveSpeed;
    #endregion

    #region Private Variables
    private bool isGrounded;

    private Vector3 xOffset;
    private Vector3 zOffset;
    private Vector3 moveOffset;

    private Rigidbody rb;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get offset with respect to Camera.
        xOffset = Input.GetAxis("Horizontal") * Camera.main.transform.right;
        zOffset = Input.GetAxis("Vertical") * Camera.main.transform.forward;

        // Calculate move offset.
        moveOffset = xOffset + zOffset;
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            moveOffset.y = 0;

            rb.velocity = moveSpeed * Time.fixedDeltaTime * moveOffset;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    #endregion
}
