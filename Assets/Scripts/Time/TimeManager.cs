using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private RawImage viewImage;

    [SerializeField]
    private int minBrightness;
    [SerializeField]
    private int maxBrightness;

    void Start() => StartCoroutine(UpdateTime());

    void OnDestroy() => StopAllCoroutines();

    private IEnumerator UpdateTime()
    {
        while (true)
        {
            viewImage.color = Color.HSVToRGB(0, 0, TimePassed() * 100);

            //yield return new WaitForSecondsRealtime(300);
            yield return new WaitForEndOfFrame();
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

        //TODO: Should return ratio as for timelapse. Currently logic is broken.
        return timeRatio < 0.5 ? timeRatio : 1 - timeRatio;
    }
}
