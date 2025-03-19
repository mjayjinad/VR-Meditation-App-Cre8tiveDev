using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public static Fader Instance = null;
    public static bool isFading = false;
    private Image fadePanel;

    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeInTime = 2f;
    [SerializeField] private float fadeOutTime = 2f;
    [SerializeField] private float delayBetweenFades = 2f;

    private void Awake()
    {
        if (Instance)
        {
            Debug.LogWarning("Already have a Fader singleton");
            Destroy(this);
            return;
        }
        Instance = this;
        fadePanel = GetComponentInChildren<Image>();
    }

    public static void FadeIn(float fadeTime = 3)
    {
        Instance?.StartCoroutine(Instance.Fade(Color.clear, fadeTime));
    }

    public static void FadeOut(float fadeTime = 3)
    {
        Instance?.StartCoroutine(Instance.Fade(Instance.fadeColor, fadeTime));
    }

    // Wrapper method to be called from the inspector
    public void InspectorFadeInFadeOut()
    {
        FadeInFadeOut(fadeInTime, fadeOutTime, delayBetweenFades);
    }

    public static void FadeInFadeOut(float fadeInTime, float fadeOutTime, float delayBetween)
    {
        Instance?.StartCoroutine(Instance.PerformFadeInFadeOut(fadeInTime, fadeOutTime, delayBetween));
    }

    private IEnumerator PerformFadeInFadeOut(float fadeInTime, float fadeOutTime, float delayBetween)
    {
        yield return Instance.Fade(Instance.fadeColor, fadeOutTime);
        yield return new WaitForSeconds(delayBetween);
        yield return Instance.Fade(Color.clear, fadeInTime);
    }

    private IEnumerator Fade(Color toColor, float duration)
    {
        if (isFading) yield break;
        isFading = true;
        float startTime = Time.time;
        Color startColor = fadePanel.color;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            fadePanel.color = Color.Lerp(startColor, toColor, t);
            yield return null;
        }
        fadePanel.color = toColor;
        isFading = false;
    }
}
