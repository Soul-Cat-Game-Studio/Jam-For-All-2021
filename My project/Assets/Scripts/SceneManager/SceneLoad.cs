using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneLoad
{
    public GameScene scene;

    public SceneLoadType sceneLoadType;

    public enum SceneLoadType
    {
        Additive = 1,
        Single = 0
        
    }
}
