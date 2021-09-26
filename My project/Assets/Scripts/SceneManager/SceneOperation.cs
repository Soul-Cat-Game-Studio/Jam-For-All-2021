using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneOperation
{
    public SceneLoad[] unloadScenes;

    [Space(20)]

    public SceneLoad[] loadScenes;
}
