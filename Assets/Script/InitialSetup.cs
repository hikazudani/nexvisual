using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialSetup : MonoBehaviour
{

    [SerializeField] private float requiredArea;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject startExperienceUI;

    void OnEnable()
    {
        planeManager.planesChanged += OnPlanesUpdated;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesUpdated;
    }


    public void OnClickStartExperience()
    {
        Debug.Log("Initializing the AR Experience...");
        startExperienceUI.SetActive(false);
        planeManager.enabled = false;

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }

    private void OnPlanesUpdated(ARPlanesChangedEventArgs args)
    {
        foreach(var plane in args.updated)
        {
            if (plane.extents.x * plane.extents.y >= requiredArea)
            {
                // Plane Found
                startExperienceUI.SetActive(true);
            }
        }
    }
}
