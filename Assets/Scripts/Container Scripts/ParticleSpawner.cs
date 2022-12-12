using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class ParticleSpawner : MonoBehaviour
{
    #region Serialized Fields
    [Header("Particle References")]
    [SerializeField] protected ParticleSystem particleObj;

    [Header("Text References")]
    [SerializeField] protected TextMeshPro text;
    [SerializeField] protected string message;
    #endregion

    #region Private Variables
    private AudioSource audioSource;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul Stone"))
        {
            OnBallDrop();
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
    protected void OnBallDrop()
    {
        particleObj.Play();
        text.text = message;

        audioSource.Play();
    }
    #endregion
}
