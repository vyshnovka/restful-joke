using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private RawImage viewImage;

    [SerializeField]
    private Gradient timeOfDay;

#if (UNITY_EDITOR)
    [Header("Debugging in Editor only")]
    [SerializeField]
    private bool testInEditor = false;

    [SerializeField]
    [Range(0f, 1f), Tooltip("Value used for debugging.")]
    private float timePassedInEditor;
#endif

    void Start()
    {
        StartCoroutine(UpdateTimeVisual());
    }

    void OnDestroy() => StopAllCoroutines();

    private IEnumerator UpdateTimeVisual()
    {
        while (true)
        {
#if (UNITY_EDITOR)
            if (testInEditor)
                viewImage.color = timeOfDay.Evaluate(timePassedInEditor);
            else
                viewImage.color = timeOfDay.Evaluate(TimePassed());

            yield return new WaitForEndOfFrame();
#else
            viewImage.color = timeOfDay.Evaluate(TimePassed());
            yield return new WaitForSecondsRealtime(300);
#endif
        }
    }

    /// <summary>Calculates time passed since midnight in seconds.</summary>
    /// <returns>Returns time ratio (from 0 to 1).</returns>
    private float TimePassed()
    {
        DateTime time = DateTime.Now;

        float secondsPassed = time.Hour * 60 * 60 + time.Minute * 60 + time.Second;
        float secondsFull = 24 * 60 * 60;

        float timeRatio = secondsPassed / secondsFull;

        return timeRatio;
    }
}
