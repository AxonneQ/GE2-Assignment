using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scene
{
    public SceneManager sm;
    public virtual void InitScene() {}
    public virtual void UpdateScene() {}
    public virtual void DestroyScene() {}

}
