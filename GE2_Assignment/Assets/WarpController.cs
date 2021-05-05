using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpController : MonoBehaviour
{
    public int warpStartAtWaypoint = 0;
    public GameObject warpPrefab;
    
    private ParticleSystem warpPS;
    private GameObject warpObject;
    private bool warpEnabled = false;
    private bool initWarp = true;

    // Start is called before the first frame update
    void Start()
    {
        warpObject = Instantiate(warpPrefab, transform.position, new Quaternion());
        warpObject.transform.parent = transform;
        warpObject.transform.localPosition = new Vector3(0f, 0f, -40f);
        warpObject.transform.localRotation = new Quaternion(0f, 180f, 0f, 1);
        warpObject.SetActive(false);
        
        warpPS = warpObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<MainShip>().currentWaypoint == warpStartAtWaypoint) {
            warpEnabled = true;
        }

        if(warpEnabled) {
            warpObject.SetActive(true);
            
            if(initWarp) {
                //warpObject.transform.position = Vector3.Lerp(warpObject.transform.position, transform.position, 0.001f);
                Vector3 shipVel = GetComponent<MainShip>().velocity;
                Vector3 warpVel = (shipVel.normalized * Time.deltaTime * 200f);
                warpObject.transform.position += warpVel;
                if(Vector3.Distance(warpObject.transform.position, transform.position) > 400f) {
                    initWarp = false;
                }
            } else {

            }
        }

        if(!warpEnabled) {
            warpObject.SetActive(false);
        }
    }
}
