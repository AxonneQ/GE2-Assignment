using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timeUntilDestruction = 0;
    public GameObject destructionEffect;
    // Start is called before the first frame update
    void Start()
    {
        if(timeUntilDestruction > 0) {
            Destroy(gameObject, timeUntilDestruction);
        }
    }

    void OnDestroy() {
        GameObject effect = Instantiate(destructionEffect, transform.position, new Quaternion());
        Destroy(effect, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
