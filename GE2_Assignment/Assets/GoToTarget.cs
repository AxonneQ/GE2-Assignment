using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : SteeringBehaviour
{
    public string targetTag = "";
    public float range = 50;
    public float buffer = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override Vector3 Calculate() {
        (float, Vector3) closest = (range + 1, Vector3.zero);

        Collider[] foundEntities = Physics.OverlapSphere(transform.position, range);
        foreach (Collider entity in foundEntities)
        {
            if(entity.tag == targetTag){
                float dist = Vector3.Distance(transform.position, entity.transform.position);
                if(dist < closest.Item1) {
                    closest = (dist, entity.transform.position);
                }
            }
        }

        if(closest.Item1 < range) {
            //transform.position = Vector3.Lerp(transform.position, (closest.Item2 - (transform.position.normalized * 10)), 0.1f * Time.deltaTime);
            //transform.LookAt(closest.Item2);
            //Vector3 targetPos = Vector3.Lerp(transform.position, closest.Item2 - (transform.position.normalized * buffer), 1f);
            Vector3 targetPos = transform.position - closest.Item2;
            targetPos = closest.Item2 + (targetPos.normalized * buffer);
            if((closest.Item1 < buffer * 2)) {
                boid.velocity = Vector3.Lerp(boid.velocity, Vector3.zero, 5 * Time.deltaTime);
                if(closest.Item1 < buffer + 1) {
                    boid.velocity = Vector3.zero;
                    transform.LookAt(closest.Item2);
                    return Vector3.zero;
                } 
            }
            return boid.ArriveForce(targetPos);
        }
        return Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
