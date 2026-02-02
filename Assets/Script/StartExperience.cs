using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartExperience : MonoBehaviour
{
	[SerializeField] private GameObject cube;

	public void OnStartExperience(ARPlane plane)
	{
		Instantiate(cube, plane.transform.position, Quaternion.identity);
	}
}
