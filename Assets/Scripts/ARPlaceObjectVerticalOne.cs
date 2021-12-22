
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class ARPlaceObject : MonoBehaviour
{
    public GameObject parent;
    public GameObject placementIndicator;
    public GameObject objectToPlace;

    public GameObject [] objects;


    public int optionIndex = 0;
    // private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private ARRaycastManager aRRaycastManager;

    private bool placementPoseIsValid = false;


    void Start()
    {
        // arOrigin = FindObjectOfType<ARSessionOrigin>();
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();

        objectToPlace = objects[optionIndex];

        Debug.Log("Start"); 
    }

    void Update()
    { 
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            Debug.Log("Touch");

            if(Screen.height * .3f < Input.touches[0].position.y){
                Debug.Log("Valid Touch");
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                Debug.Log(placementPoseIsValid);
                if(Physics.Raycast(ray, 100)){
                    Debug.Log("There is a object");
                }else{
                    if(placementPoseIsValid){
                        PlaceObject();
                    }
                }
                
            }

        }

        // if(Input.GetMouseButtonDown(0)){
        //     PlaceObject();
        // }
    }

    private void UpdatePlacementPose(){
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;

        if(placementPoseIsValid){
            placementPose = hits[0].pose;
        }

    }

    private void UpdatePlacementIndicator(){
       if(placementPoseIsValid){
           placementIndicator.SetActive(true);
           placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
       }else{
           placementIndicator.SetActive(false);
       }

    }
 
    private void PlaceObject(){
        objectToPlace = objects[0];//simpleUI.index
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation * Quaternion.Euler(0, 180f, 0), parent.transform);
    }

   
}
