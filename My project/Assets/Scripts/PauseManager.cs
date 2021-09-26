using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PauseManager", menuName = "PauseManager", order = 0)]
public class PauseManager : ScriptableObject
{
    public void PauseGame() => Time.timeScale = 0;

    public void PlayGame() => Time.timeScale = 1;
}
