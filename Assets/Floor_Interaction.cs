using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Floor_Interaction : MonoBehaviour
{
    ARRaycastManager arraycastmanager;
    Tour_Manager tManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject spawnedVideo;
    void Awake()
    {
        arraycastmanager = GetComponent<ARRaycastManager>();
    }

    void Start()
    {
        tManager = GameObject.FindObjectOfType<Tour_Manager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }



    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition)) return;

        if (Input.touchCount > 0 && Input.touches[0].phase==TouchPhase.Began)
        {
            if (arraycastmanager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                var hitPose = hits[0].pose;
           // if (!tManager.tourStarted)
             //   {
                    Instantiate(spawnedVideo, hitPose.position, hitPose.rotation);
                    tManager.tourStarted = true;
              //  }

            }
        }

    }
}


