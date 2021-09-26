using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneOperationManager", menuName = "Util/Scene Operation Manager", order = 0)]
public class SceneOperationManager : ScriptableObject
{
    public int startIndex = -1;
    [SerializeField] private int index;

    [Space(30)]
    public SceneOperation[] Operations;

    private void OnEnable() => ResetIndex();

    public void ResetIndex() => index = startIndex;


    public async void ExecuteNextOperationSequential()
    {
        if (++index >= Operations.Length) return;

        var currentOperation = Operations[index];

        await UnloadScenesSequential(currentOperation.unloadScenes);

        await LoadNextOperationSequential(currentOperation.loadScenes);
    }   
   
    public async void ExecuteOperationSequential(int i)
    {
        if (i >= Operations.Length) return;

        var currentOperation = Operations[i];

        await UnloadScenesSequential(currentOperation.unloadScenes);

        await LoadNextOperationSequential(currentOperation.loadScenes);
    }   
   
    public async void ExecuteOperationSequentialReset(int i)
    {
        if (i >= Operations.Length) return;

        index = i;

        var currentOperation = Operations[index];                

        await UnloadScenesSequential(currentOperation.unloadScenes);

        await LoadNextOperationSequential(currentOperation.loadScenes);
    }   

    private async UniTask LoadNextOperationSequential(SceneLoad[] sceneLoads)
    {
        foreach (var load in sceneLoads)
        {
            LoadSceneMode loadMode = (LoadSceneMode)load.sceneLoadType;

            var scene = SceneManager.LoadSceneAsync(load.scene.name, loadMode);
            scene.allowSceneActivation = false;

            await UniTask.WaitUntil(() => scene.progress >= .9f);

            scene.allowSceneActivation = true;
        }
    }  

    private async UniTask UnloadScenesSequential(SceneLoad[] sceneLoads)
    {
        foreach (var load in sceneLoads)
            await SceneManager.UnloadSceneAsync(load.scene.name).ToUniTask();
    }
}

