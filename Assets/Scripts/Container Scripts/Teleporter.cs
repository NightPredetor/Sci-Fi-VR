using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : ParticleSpawner
{
    #region Serialized Fields
    [SerializeField] Transform teleportPosition;
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] float teleportDelay;
    #endregion

    #region MonoBehaviour
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul Stone"))
        {
            StartCoroutine(Teleport());
        }
    }
    #endregion

    #region Private Methods
    private IEnumerator Teleport()
    {
        ShowMessage();

        yield return new WaitForSeconds(teleportDelay);

        playerRigidbody.MovePosition(teleportPosition.position);
    }
    #endregion
}
