using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_Text username;

    private void Start()
    {
        username.name = ServerJoiner.Name;
    }

    public void SetName(string name)
    {
        ServerJoiner.Name = name;
        username.text = name;
    }

    public void Play()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
