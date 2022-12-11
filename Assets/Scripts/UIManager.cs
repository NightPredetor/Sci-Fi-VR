using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] List<GameObject> rightPanelButtonsList;
    #endregion

    #region Public Methods
    public void ShowSubPanel(int panelIndex)
    {
        if (panelIndex < 0 || panelIndex > rightPanelButtonsList.Count)
        {
            Debug.LogError("Invalid index number passed: " + panelIndex);
            return;
        }

        ToggleOffRightPanelButtons();

        rightPanelButtonsList[panelIndex].SetActive(true);
    }
    #endregion

    #region Private Methods
    private void ToggleOffRightPanelButtons()
    {
        // Toggle off all the right panel buttons.

        foreach (GameObject gameObject in rightPanelButtonsList)
        {
            gameObject.SetActive(false);
        }
    }
    #endregion
}
