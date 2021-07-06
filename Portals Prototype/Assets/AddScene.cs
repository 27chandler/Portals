using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }

    public void UnloadScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
