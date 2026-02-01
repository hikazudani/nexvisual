using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private float requiredArea;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject startExperienceUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            if ( plane.extents.x * plane.extents.y >= requiredArea)
            {
                // Found a plane
                startExperienceUI.SetActive(true);
                return;
            }
        }

        // no plane found
        startExperienceUI.SetActive(false);
    }
}
