using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAtWaypoint : MonoBehaviour
{
    public GameObject waypointSource;
    public int fadeInAtWaypoint = -1;
    bool fading = false;

    private float alpha = 0f; 
    private Texture2D texture;
    private float time = 0f;
    public Color fadeColor = Color.black;


    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeInAtWaypoint > -1 && waypointSource.GetComponent<PathFollow>().currentWaypoint == fadeInAtWaypoint && fading == false) {
            Debug.Log("fading...");
            alpha = 0f;
            time = 1f;
            fading = true;
        }
    }
}
