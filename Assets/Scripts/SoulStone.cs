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
public class SoulStone : MonoBehaviour
{
    public static Action OnGrabbable;

    #region Serialized Fields
    [SerializeField] GameObject canvasObj;
    #endregion

    #region MonoBehaviour
    void Start()
    {
        Teleporter.OnTeleport += OnTeleport;
    }

    private void OnDestroy()
    {
        Teleporter.OnTeleport -= OnTeleport;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Return if grabbable OR the canvas is already on.
        if (TryGetComponent(out XRGrabInteractable _) || canvasObj.activeInHierarchy)
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
        gameObject.AddComponent<XRGrabInteractable>();

        OnGrabbable?.Invoke();
    }

    private void OnTeleport()
    {
        // Toggles on the canvas.
        canvasObj.SetActive(true);

        // Removes the object from being grabbable.
        Destroy(gameObject.GetComponent<XRGrabInteractable>());
    }
    #endregion
}
