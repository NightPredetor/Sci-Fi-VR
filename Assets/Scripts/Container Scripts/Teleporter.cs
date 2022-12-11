using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : ParticleSpawner
{
    #region Serialized Fields
    [SerializeField] Transform teleportPosition;
    [SerializeField] Rigidbody playerRigidbody;
    #endregion

    #region MonoBehaviour
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul Stone"))
        {
            // TODO: Teleport Logic.
            particleObj.Play();
            playerRigidbody.MovePosition(teleportPosition.position);
        }
    }
    #endregion
}
