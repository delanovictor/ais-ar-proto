using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
//using UnityEngine.Experimental.XR
using UnityEngine.SceneManagement;

using UnityEngine.XR.ARSubsystems;
using System;

public class ARPlacementSegundo : MonoBehaviour
{
    public GameObject placementIndicator;

    //private ARSessionOrigin arOrigin;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    void Start()
    {
        //arOrigin = FindObjectOfType<ARSessionOrigin>();
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
		{
            placementIndicator.SetActive(false);
		}
	}

    private void UpdatePlacementPose()
	{
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
		{
            PlacementPose = hits[0].pose;
		}
	}
}