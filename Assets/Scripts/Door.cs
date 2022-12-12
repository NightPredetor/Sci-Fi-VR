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
    }
    #endregion

    #region Public Methods
    public void OpenDoor()
    {
        animator.SetTrigger("Open");
    }

    public void CloseDoor()
    {
        animator.SetTrigger("Close");
    }
    #endregion
}
