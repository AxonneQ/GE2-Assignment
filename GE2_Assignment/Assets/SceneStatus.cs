using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFinished;
    public GameObject triggerObject;
    public int finishAtWaypoint;
    
    
    void Start()
    {
        isFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        int currentWaypoint = triggerObject.GetComponent<MainShip>().currentWaypoint;
        if (currentWaypoint == finishAtWaypoint) {
            isFinished = true;
        }
    }
}
