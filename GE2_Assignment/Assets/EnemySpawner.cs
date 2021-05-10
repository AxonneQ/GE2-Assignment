using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject[] entities;
    public int count = 10;
    public int radius = 2000;
    public List<GameObject> prefabs;

    // Start is called before the first frame update
    void Start()
    {
        entities = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = Random.insideUnitSphere * radius;
            pos = new Vector3(pos.x + radius, pos.y, pos.z);
            entities[i] = GameObject.Instantiate(prefabs[Random.Range(0,2)], pos, new Quaternion());
            entities[i].GetComponent<GoToTarget>().range = 500;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
