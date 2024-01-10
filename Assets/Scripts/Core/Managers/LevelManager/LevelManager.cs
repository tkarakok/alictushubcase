using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LevelController))]
public class LevelManager : Singleton<LevelManager>
{
    public LevelController LevelController { get; private set; }

    private void Awake()
    {
        LevelController = GetComponent<LevelController>();
        LevelController.LoadScene(1, LoadSceneMode.Additive);
    }
}
