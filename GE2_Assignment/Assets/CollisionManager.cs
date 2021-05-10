using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject collisionEffect;
    public List<string> ignoreCollisionTags;
    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {   
        if(ignoreCollisionTags.Contains(other.gameObject.tag)) {
            return;
        }
        if(!hasCollided) {
            hasCollided = true;
            Debug.Log($"collided with {other.gameObject.tag}");

            if(collisionEffect != null) {
                GameObject effect = Instantiate(collisionEffect, transform.position, new Quaternion());
                Destroy(effect, 2.0f);
            }
            Destroy(gameObject);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
