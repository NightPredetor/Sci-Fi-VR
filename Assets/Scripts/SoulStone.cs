using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulStone : MonoBehaviour
{
    [SerializeField] GameObject textObj;

    #region Public Methods
    public void HideText()
    {
        if (textObj)
        {
            textObj.SetActive(false);
        }
    }
    #endregion
}
