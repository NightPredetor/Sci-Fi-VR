using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] protected ParticleSystem particleObj;
    #endregion

    #region MonoBehaviour
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul Stone"))
        {
            particleObj.Play();
        }
    }
    #endregion
}
