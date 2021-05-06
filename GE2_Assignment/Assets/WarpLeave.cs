using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpLeave : MonoBehaviour
{
    public GameObject ship;
    public float maxSpeedAfterLeave;
    public float maxVelocityAfterLeave;
    public int leaveAtWaypoint;
    public AudioClip sound;

    private AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MainShip mship = ship.GetComponent<MainShip>();
        if(mship.currentWaypoint == leaveAtWaypoint) {
            mship.maxSpeed = maxSpeedAfterLeave;
            mship.velocity = mship.velocity.normalized * maxVelocityAfterLeave;
            audioSources[1].PlayOneShot(sound);
            mship.currentWaypoint = 0;
        }
    }
}
