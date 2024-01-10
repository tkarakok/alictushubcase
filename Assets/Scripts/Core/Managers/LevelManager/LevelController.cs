using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour, ILevelController
{
    public void LoadScene(int sceneId, LoadSceneMode loadSceneMode, bool closeActiveScene = false)
    {
        if (closeActiveScene)
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneId, loadSceneMode);
    }
}
