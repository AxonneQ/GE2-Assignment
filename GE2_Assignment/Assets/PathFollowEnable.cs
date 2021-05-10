using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowEnable : MonoBehaviour
{
    public int enablePathFollowAtWaypoint = -1;
    public GameObject triggerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerObject.GetComponent<PathFollow>().currentWaypoint == enablePathFollowAtWaypoint) {
            GetComponent<PathFollow>().pathFollowingEnabled = true;
        }
    }
}
