using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    int roty = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Rotate", 1, 1);
        
    }
    void Rotate()
    {
        roty += 10;
        transform.Rotate(0, roty, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
