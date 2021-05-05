using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<GameObject> scenes;
    public int activeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        scenes = new List<GameObject>();
        // Add all scenes to list and turn them off.
        for(int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(false);
            scenes.Add(child); 
        }

        scenes[activeIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(scenes.Count > 0) {
            if(scenes[activeIndex].GetComponent<SceneStatus>().isFinished && scenes.Count > activeIndex) {
                scenes[activeIndex].SetActive(false);
                activeIndex++;
                scenes[activeIndex].SetActive(true);
            }
        }
    }
}


// Scene1 - Camera at protagonist flying into hyperspace, 5 seconds in switch to Scene2
// Scene2 - Leave hyperspace at asteroid field

