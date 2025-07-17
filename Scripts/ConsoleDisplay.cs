using TMPro;
using UnityEngine;
using System.Collections;

public class ConsoleDisplay : MonoBehaviour
{
    public TextMeshProUGUI consoleText;
    public float displayDuration = 1f;  // Time to show the message
    public float fadeDuration = 0.5f;   // Time to fade out

    private Coroutine fadeCoroutine;

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Ignore long logs or multi-line logs
        if (string.IsNullOrWhiteSpace(logString) || logString.Length > 100 || logString.Contains("\n"))
            return;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        consoleText.text = logString;
        var color = consoleText.color;
        color.a = 1f;
        consoleText.color = color;

        fadeCoroutine = StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(displayDuration);

        float elapsed = 0f;
        Color originalColor = consoleText.color;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            consoleText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        consoleText.text = "";
    }
}
