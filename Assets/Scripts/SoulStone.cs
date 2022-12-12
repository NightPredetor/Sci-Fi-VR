using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// The stone is not grabbable at the start.
/// On touching the stone for the first time, the canvas will show up.
/// On equipping from the canvas, the stone will become grabbable.
/// On being dropped inside Box C, the stone will not be grabbable anymore until re-equiped.
/// </summary>
[RequireComponent(typeof(XRGrabInteractable))]
public class SoulStone : MonoBehaviour
{
    public static Action OnGrabbable;

    #region Serialized Fields
    [SerializeField] GameObject canvasObj;
    [SerializeField] ParticleSystem particleEffect;
    #endregion

    #region Private Variables
    private XRGrabInteractable xrGrabInteractable;
    #endregion

    #region MonoBehaviour
    void Start()
    {
        Teleporter.OnTeleport += OnTeleport;

        xrGrabInteractable = GetComponent<XRGrabInteractable>();

        xrGrabInteractable.enabled = false;
        canvasObj.SetActive(false);
        particleEffect.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Teleporter.OnTeleport -= OnTeleport;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Return if not collided with Player OR
        // already grabbable OR
        // the canvas is already on.
        if (collision.gameObject.CompareTag("Player") is false ||
            xrGrabInteractable.enabled ||
            canvasObj.activeInHierarchy)
        {
            return;
        }

        canvasObj.SetActive(true);
    }
    #endregion

    #region Public Methods
    public void MakeGrabbable()
    {
        // Makes the object grabbable.
        xrGrabInteractable.enabled = true;

        particleEffect.gameObject.SetActive(true);
        particleEffect.Play();

        OnGrabbable?.Invoke();
    }

    private void OnTeleport()
    {
        // Toggles on the canvas.
        canvasObj.SetActive(true);
        particleEffect.gameObject.SetActive(false);

        // Removes the object from being grabbable.
        xrGrabInteractable.enabled = false;
    }
    #endregion
}
