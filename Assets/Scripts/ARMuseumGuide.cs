using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARMuseumGuide : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;
    private ARPlaneManager planeManager;
    private ARAnchorManager anchorManager;

    [SerializeField] private TexturePrefab[] prefabs;

    [Serializable]
    public class TexturePrefab
    {
        public string Name;
        public GameObject Prefab;
    }

    private Dictionary<string, GameObject> Videos = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        planeManager = GetComponent<ARPlaneManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
        }

        foreach (ARTrackedImage updatedImage in eventArgs.updated)
        {
            // Handle updated event
            //if (updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            Debug.Log(updatedImage.name);
            // check if inside view Camera.main updatedImage.transform
            if (updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited ||
                updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.None)
            {
                DestroyVideo(updatedImage);
            }
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateVideo(ARTrackedImage updatedImage)
    {
        if (Videos.ContainsKey(updatedImage.name))
            return;

        //updatedImage.name
        //GameObject video = Instantiate(prefab, trackedImageManager.trackedImagePrefab.transform);
        // Videos[updatedImage.name] = video;
    }

    private void DestroyVideo(ARTrackedImage updatedImage)
    {
        if (!Videos.ContainsKey(updatedImage.name))
            return;

        Destroy(Videos[updatedImage.name]);
    }
}
