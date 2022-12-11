using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : ParticleSpawner
{
    #region Serialized Fields
    [Header("Teleporter References")]
    [SerializeField] GameObject canvasObj;
    [SerializeField] Rigidbody playerRigidbody;

    [Header("Teleporter Configurations")]
    [SerializeField] Transform teleportPosition;
    [SerializeField] float teleportDelay;
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

        canvasObj.SetActive(true);
        playerRigidbody.MovePosition(teleportPosition.position);
    }
    #endregion
}
