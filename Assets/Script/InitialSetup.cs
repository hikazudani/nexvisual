using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialSetup : MonoBehaviour
{

    [SerializeField] private float requiredArea;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject startExperienceUI;
    [SerializeField] private StartExperience startExperience;

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

        ARPlane targetPlane = GetBiggestPlane();

        if (targetPlane != null)
        {
            startExperience.OnStartExperience(targetPlane);
        }
        
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        planeManager.enabled = false;
        startExperienceUI.SetActive(false);
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

    private ARPlane GetBiggestPlane()
    {
        ARPlane biggestPlane = null;
        float biggestArea = 0f;

        foreach (var plane in planeManager.trackables)
        {
            float area = plane.extents.x * plane.extents.y;
            if(area > biggestArea)
            {
                biggestArea = area;
                biggestPlane = plane;
            }
        }
        return biggestPlane;
    }
}
