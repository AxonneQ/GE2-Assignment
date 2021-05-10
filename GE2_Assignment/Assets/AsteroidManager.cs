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
            Vector3 pos = Random.insideUnitSphere * radius;
            pos = new Vector3(pos.x + radius, pos.y, pos.z);
            asteroids[i] = GameObject.Instantiate(asteroidPrefabs[Random.Range(0,3)], pos, new Quaternion());
            float scaleFactor = Random.Range(1,3);
            Vector3 scale = asteroids[i].transform.localScale;
            scale.x *= scaleFactor;
            scale.y *= scaleFactor;
            scale.z *= scaleFactor;
            asteroids[i].transform.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
