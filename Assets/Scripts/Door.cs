using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator animator;

    #region MonoBehaviour
    void Start()
    {
        animator = GetComponent<Animator>();

        SoulStone.OnGrabbable += OpenDoor;
        Teleporter.OnTeleport += CloseDoor;
    }

    private void OnDestroy()
    {
        SoulStone.OnGrabbable -= OpenDoor;
        Teleporter.OnTeleport -= CloseDoor;
    }
    #endregion

    #region Private Methods
    private void OpenDoor()
    {
        animator.SetTrigger("Open");
    }

    private void CloseDoor()
    {
        animator.SetTrigger("Close");
    }
    #endregion
}
