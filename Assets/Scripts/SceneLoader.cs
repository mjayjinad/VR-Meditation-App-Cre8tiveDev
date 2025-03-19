using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    public float fadeDuration;

    private void Start()
    {
        Fader.FadeIn(fadeDuration);
    }

    public void ChangeToScene(string sceneName) => StartCoroutine(LoadSceneCoroutine(sceneName));

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        Fader.FadeOut(fadeDuration);
        while (Fader.isFading) yield return null;

        SceneManager.LoadSceneAsync(sceneName);
    }
}