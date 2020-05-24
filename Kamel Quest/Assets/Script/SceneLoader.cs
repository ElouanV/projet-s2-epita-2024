using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// Author : Elouan

/// <summary>
/// The main <c>SceneLoader</c> class.
/// Contains all methods for the loading of a scene.
/// <para> While the scene is loading, a loading screen is active with a slider corresponding to the progress of loading  </para>
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject Canvas;
    public Slider loadingslider;

    ///<summary>
    /// This method is called when the player change the scene of game, by starting a party, or leave the battle scene
    ///</summary>
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
            Debug.Log(progress);
            loadingslider.value = progress;
            yield return null;
        }
    }
}
