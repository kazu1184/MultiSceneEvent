using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    public void Replace(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void Hover(string name)
    {
        if (!UnityEngine.SceneManagement.SceneManager.GetSceneByName(name).isLoaded)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name, LoadSceneMode.Additive);
        }
    }

    public void Dispose(string name)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetSceneByName(name).isLoaded)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(name);
        }
    }
}