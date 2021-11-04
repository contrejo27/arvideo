using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Video;

public class GuideVideoManager : MonoBehaviour
{
    public VideoClip[] vids;

    
    ARSessionOrigin arsessionOrigin;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        arsessionOrigin = GameObject.FindObjectOfType<ARSessionOrigin>();

        //cameraTarget = GameObject.FindGameObjectWithTag("CameraTarget");
        //InvokeRepeating("PointAtCamera", 1, 1);
    }
    void PointAtCamera()
    {
        transform.LookAt(arsessionOrigin.camera.transform);
    }
    // Update is called once per frame
    void Update()
    {

        PointAtCamera();
        //transform.LookAt(Camera.main.transform);
        //transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
    }

    public void SetVideo(string name)
    {
        foreach(VideoClip v in vids)
        {
            if(v.name == name)
            {
                GetComponent<VideoPlayer>().clip = v;

            }
        }
    }
}