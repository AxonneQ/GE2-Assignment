using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> cameras;
    public GameObject currentCamera;
    private int currentCameraIndex;
    public GameObject currentTarget;
    public GameObject targetFocus;
    public bool lookAtObject = false;
    public int LookStartAtWaypoint;
    public bool followObject = false;
    public int followStartAtWaypoint;
    public int nextCameraAtWaypoint = -1;


    private Vector3 defaultDirection;
    private float timeToSwitch = 1;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].SetActive(false);
        }
        currentCameraIndex = 0;
        currentCamera = cameras[currentCameraIndex];
        UpdateOptions();
        currentCamera.SetActive(true);
    }

    private void UpdateOptions()
    {
        defaultDirection = currentCamera.transform.forward;

        CameraOptions options = currentCamera.GetComponent<CameraOptions>();
        lookAtObject = options.lookAtObject;
        LookStartAtWaypoint = options.LookStartAtWaypoint;
        followObject = options.followObject;
        followStartAtWaypoint = options.followStartAtWaypoint;
        currentTarget = options.targetObject;
        if (options.targetFocus == null)
        {
            targetFocus = currentTarget;
        }
        else
        {
            targetFocus = options.targetFocus;
        }
        nextCameraAtWaypoint = options.nextCameraAtWaypoint;
    }

    public void NextCamera()
    {
        currentCamera.SetActive(false);
        currentCamera = cameras[currentCameraIndex++];
        UpdateOptions();
        currentCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int currentWaypoint = currentTarget.GetComponent<PathFollow>().currentWaypoint;

        if (currentWaypoint == followStartAtWaypoint && followObject == false)
        {
            followObject = true;
        }

        if (currentWaypoint == LookStartAtWaypoint && lookAtObject == false && targetFocus != null)
        {
            lookAtObject = true;
        }

        if (followObject)
        {
            currentCamera.GetComponent<FollowObject>().enabled = true;
        }
        else
        {
            //currentCamera.GetComponent<FollowObject>().enabled = false;
        }

        if (lookAtObject)
        {
            if (targetFocus != null)
            {
                currentCamera.transform.rotation = Quaternion.Slerp( 
                    currentCamera.transform.rotation, 
                    Quaternion.LookRotation( targetFocus.transform.position - currentCamera.transform.position ), 
                    Time.deltaTime * 5.0f);
            }
            else
            {
                timeToSwitch -= Time.deltaTime;
                if (timeToSwitch <= 0) {
                    currentCamera.transform.rotation = Quaternion.Slerp( 
                        currentCamera.transform.rotation, 
                        Quaternion.LookRotation( defaultDirection ), 
                        Time.deltaTime * 2.0f);
                }
                //lookAtObject = false;
            }
        }

        if (currentWaypoint == nextCameraAtWaypoint && nextCameraAtWaypoint > -1)
        {
            NextCamera();
        }
    }
}
