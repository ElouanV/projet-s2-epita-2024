using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// Author : Elouan

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject Canvas;
    public Slider loadingslider;


    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Canvas.SetActive(false);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);
            loadingslider.value = progress;
            yield return null;
        }
    }
}
