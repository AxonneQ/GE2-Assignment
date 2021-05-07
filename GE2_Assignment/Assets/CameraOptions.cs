using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOptions : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject targetFocus;
    public bool lookAtObject = false;
    public int LookStartAtWaypoint = -1;
    public bool followObject = false;
    public int followStartAtWaypoint = -1;
    public int nextCameraAtWaypoint = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
