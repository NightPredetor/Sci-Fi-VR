using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParticleSpawner : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] protected ParticleSystem particleObj;
    [SerializeField] protected TextMeshPro text;
    [SerializeField] protected string message;
    #endregion

    #region MonoBehaviour
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul Stone"))
        {
            ShowMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Soul Stone"))
        {
            text.text = "DROP HERE";
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Shows the confirmation that ball has been dropped successfully.
    /// </summary>
    protected void ShowMessage()
    {
        particleObj.Play();
        text.text = message;
    }
    #endregion
}
