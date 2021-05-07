using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> guns;
    public GameObject priorityTarget;
    public GameObject target;
    public GameObject laserPrefab;
    public AudioClip laserSound;
    public bool isEnabled = true;
    public bool isShooting = false;
    public string lookForTag = "";
    public float rateOfFire = 0;


    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        audioSource = GetComponents<AudioSource>()[1];
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (target != null && isShooting)
            {
                for (int i = 0; i < guns.Count; i++)
                {
                    GameObject laser = GameObject.Instantiate<GameObject>(laserPrefab, guns[i].transform.position, transform.rotation);
                    laser.transform.LookAt(target.transform.position + guns[i].transform.localPosition);
                }
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(laserSound);
                }
            }
            if(rateOfFire > 0) {
                yield return new WaitForSeconds(1.0f / rateOfFire);
            } else {
                yield return new WaitForSeconds(1.0f / (float)Random.Range(0.5f, 3f));
            }  
        }
    }

    bool CheckIfInCone(float angle, Transform target)
    {
        var cone = Mathf.Cos(angle * Mathf.Deg2Rad);
        var heading = (target.position - transform.position).normalized;

        if (Vector3.Dot(transform.forward, heading) > cone)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == lookForTag)
        {
            isShooting = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == lookForTag && CheckIfInCone(30, other.transform))
        {
            if (priorityTarget != null)
            {
                if (other.gameObject == priorityTarget)
                {
                    target = priorityTarget;
                }
                else
                {
                    target = other.gameObject;
                }
            } else {
                target = other.gameObject;
            }

            isShooting = true;
        }
        else if (other.tag == lookForTag && !CheckIfInCone(30, other.transform))
        {
            isShooting = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

