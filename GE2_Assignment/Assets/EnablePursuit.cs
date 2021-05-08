using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePursuit : MonoBehaviour
{
    public int enablePursuitAtWaypoit = -1;
    PathFollow pathFollow;

    // Start is called before the first frame update
    void Start()
    {
        pathFollow = GetComponent<PathFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pathFollow.currentWaypoint > -1 && pathFollow.currentWaypoint == enablePursuitAtWaypoit) {
            GetComponent<OffsetPursue>().enabled = true;
        }
    }
}
