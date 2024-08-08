using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utility.Helpers;

namespace Internal.Time
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; private set; }

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

        public event Action<float> OnTimeUpdated;

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
                    viewImage.color = timeOfDay.Evaluate(TimeHelpers.TimePassed());

                yield return new WaitForEndOfFrame();
    #else
                viewImage.color = timeOfDay.Evaluate(TimePassed());
                yield return new WaitForSecondsRealtime(300);
    #endif
            }
        }
    }
}
