using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : ParticleSpawner
{
    #region Serialized Fields
    [Header("Teleporter References")]
    [SerializeField] SoulStone soulStone;
    [SerializeField] Transform playerTransform;

    [Header("Teleporter Configurations")]
    [SerializeField] float teleportDelay;
    [SerializeField] Transform playerTeleportPosition;
    [SerializeField] Transform soulStoneTeleportPosition;
    #endregion

    #region MonoBehaviour
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul Stone"))
        {
            ShowMessage();

            StartCoroutine(Teleport());
        }
    }
    #endregion

    #region Private Methods
    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(teleportDelay);

        soulStone.OnTeleport();

        // Teleport.
        playerTransform.position = playerTeleportPosition.position;
        soulStone.gameObject.transform.position = soulStoneTeleportPosition.position;

        // Apply Transform changes to the physics engine.
        // As the player and stone have "Teleported", their Rigidbody, Collider etc. needs to be updated based on their transform. 
        Physics.SyncTransforms();
    }
    #endregion
}
