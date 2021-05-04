using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Scene currentScene;


    public GameObject enemyFighterPrefab;
    public GameObject enemyMotherShipPrefab;
    public GameObject friendlyFighterPrefab;


    public List<GameObject> enemyFighters;
    public List<GameObject> enemyMotherships;
    public List<GameObject> friendlyFighters;
    public GameObject protagonist;

    


    // Start is called before the first frame update
    void Start()
    {
        currentScene = new Scene1();
        currentScene.InitScene();
    }

    // Update is called once per frame
    void Update()
    {
        currentScene.UpdateScene();
    }
}


// Scene1 - Camera at protagonist flying into hyperspace, 5 seconds in switch to Scene2
// Scene2 - Leave hyperspace at asteroid field


class Scene1 : Scene {

}
