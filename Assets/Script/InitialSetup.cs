using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializedField] private float requiredArea;
    [SerializedField] private ARPlaneManager planeManager;
    [SerializedField] private GameObject startExperienceUI;

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
