using UnityEngine;

public class MainShip : MonoBehaviour
{
    public Vector3 velocity;
    public float speed;
    public Vector3 acceleration;
    public Vector3 force;
    public float maxSpeed = 5;
    public float mass = 1;
    public float slowingDistance = 80;
    public Path path;
    public bool pathFollowingEnabled = false;
    public float waypointDistance = 3;
    public int currentWaypoint = -1;
    public float banking = 0.1f; 
    public float damping = 0.1f;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + velocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + acceleration);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + force * 10);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        force = CalculateForce();
        acceleration = force / mass;
        velocity = velocity + acceleration * Time.deltaTime;
        transform.position = transform.position + velocity * Time.deltaTime;
        speed = velocity.magnitude;
        if (speed > 0)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            velocity -= (damping * velocity * Time.deltaTime);
        } 
    }

    public Vector3 PathFollow()
    {
        Vector3 nextWaypoint = path.NextWaypoint();
        if (path.IsLast())
        {   
            if(Vector3.Distance(transform.position, nextWaypoint) < waypointDistance) {
                pathFollowingEnabled = false;
                currentWaypoint++;
            }
            return Arrive(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
            {
                path.AdvanceToNext();
                currentWaypoint = path.next; 
            }
            return Seek(nextWaypoint);
        }
    }
    public Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return (desired - velocity);
    } 
    public Vector3 Arrive(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        float dist = toTarget.magnitude;
        float ramped = (dist / slowingDistance) * maxSpeed;
        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = (toTarget / dist) * clamped;

        return desired - velocity;
    }

    public Vector3 CalculateForce()
    {
        Vector3 f = Vector3.zero;

        if (pathFollowingEnabled)
        {
            f += PathFollow();
        }

        return f;
    }
}
