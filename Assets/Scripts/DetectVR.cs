using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    public GameObject xrRig;
    public GameObject testRig;

    private void Start()
    {
        XRGeneralSettings xrSettings = XRGeneralSettings.Instance;

        if (xrSettings == null)
        {
            Debug.Log("XR General Settings is null!");
            return;
        }

        XRManagerSettings xrManager = xrSettings.Manager;

        if (xrManager == null)
        {
            Debug.Log("XR Manager Settings is null!");
            return;
        }

        XRLoader xrLoader = xrManager.activeLoader;

        if (xrLoader == null)
        {
            Debug.Log("XR Loader is null!");
            
            xrRig.SetActive(false);
            testRig.SetActive(true);

            return;
        }

        Debug.Log("XR Loader is not null!");

        xrRig.SetActive(true);
        testRig.SetActive(false);
    }
}
