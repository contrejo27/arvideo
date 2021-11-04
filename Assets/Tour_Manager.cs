using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Tour_Manager : MonoBehaviour
{
    GameObject ARSession;
    public bool tourStarted = false;
    public GameObject testCube;


    public GameObject trackingObject;
    public Vector3 studioSpawnPosition;

    private void Awake()
    {
        ARSession = GameObject.FindGameObjectWithTag("AR_Session_Origin");
        ARSession.GetComponent<ARPlaneManager>().enabled = true;
        ARSession.GetComponent<Floor_Interaction>().enabled = true;
        Instantiate(testCube, trackingObject.transform.position,trackingObject.transform.rotation);
        //InvokeRepeating("ShootCube", 2,2);   
    }

    void ShootCube()
    {
        GameObject X = Instantiate(testCube, trackingObject.transform.position, Quaternion.identity);
        X.GetComponent<Rigidbody>().AddForce(-trackingObject.transform.up *10);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        //GetComponent<Canvas>().worldCamera = UnityEngine.XR.ARFoundation.ARSession.Camera;
        //ARSession.GetComponent<ARSession>().Camera;
        /*if (tourStarted)
        {
            RaycastHit hit;
        if (Physics.Raycast(trackingObject.transform.position, -trackingObject.transform.up, out hit))
            studioSpawnPosition = hit.transform.position;

            Instantiate(testCube, studioSpawnPosition, Quaternion.identity);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(trackingObject.transform.position, -trackingObject.transform.up);
    }
}


