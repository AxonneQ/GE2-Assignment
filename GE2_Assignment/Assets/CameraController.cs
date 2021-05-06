using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentCamera;
    public bool lookAtObject = true;
    public bool followObject = false;
    public int followStartAtWaypoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PathFollow>().currentWaypoint == followStartAtWaypoint && followObject == false) {
            followObject = true;
            //TextManager.WriteText("Testing text print!", 2);
        }

        if(followObject) {
            currentCamera.GetComponent<FollowObject>().enabled = true;
        }
    }
}
