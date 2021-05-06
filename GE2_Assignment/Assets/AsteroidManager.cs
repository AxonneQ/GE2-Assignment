using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public int count = 50;
    public int radius = 100;
    private GameObject[] asteroids;
    // Start is called before the first frame update
    void Start()
    {
        asteroids = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = Random.insideUnitSphere * radius + transform.position;
            asteroids[i] = GameObject.Instantiate(asteroidPrefabs[Random.Range(0,3)], pos, new Quaternion());
        }

        for (int i = 0; i < count; i++)
        {
            if ((asteroids[i].transform.position - transform.position).sqrMagnitude > radius)
            {
                asteroids[i].transform.position = Random.insideUnitSphere.normalized * radius + transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
