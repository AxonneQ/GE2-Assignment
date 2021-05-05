using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour
{
    public GameObject target;
    public bool isAttached = false;
    public float minimumDistance = 10.0f;
    public float stoppingDistance = 20.0f;
    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;

    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;

    [Range(0.0f, 1.0f)]
    public float banking = 0.1f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;

    void Start()
    {
        //offset = transform.position - target.transform.position;
    }

    
    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        Vector3 newAcceleration = force / mass;
        acceleration = Vector3.Lerp(acceleration, newAcceleration, Time.deltaTime);
        velocity += acceleration * Time.deltaTime;
        velocity = new Vector3(velocity.x, velocity.y, velocity.z);

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        if (velocity.magnitude > float.Epsilon)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            transform.position += velocity * Time.deltaTime;
            velocity *= (1.0f - (damping * Time.deltaTime));
        }
        
    }

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }

    public Vector3 ArriveForce(GameObject target, float slowingDistance = 15.0f)
    {
        Vector3 toTarget = target.transform.position - transform.position;

        float distance = toTarget.magnitude;
        if (distance <= minimumDistance)
        {
            transform.parent = target.transform;
            transform.rotation = new Quaternion();
            velocity = Vector3.zero;
            acceleration = Vector3.zero;
            transform.position = Vector3.Lerp(transform.position, transform.parent.position, 0.5f * Time.deltaTime);
            //transform.LookAt(Vector3.Lerp(transform.position, transform.parent.position, 0.001f));
            
            //transform.rotation = Quaternion.Slerp(transform.rotation, target.GetComponentInParent<Transform>().rotation, 0.1f);
        
            //isAttached = true;
            return Vector3.zero;
        }
        float ramped = maxSpeed * (distance / slowingDistance);

        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = clamped * (toTarget / distance);

        return desired - velocity;
    }


    Vector3 Calculate()
    {
        return ArriveForce(target, stoppingDistance);
    }


}