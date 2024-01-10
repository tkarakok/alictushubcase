using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ILevelController
{
    void LoadScene(int sceneId, LoadSceneMode loadSceneMode, bool closeActiveScene);
}
