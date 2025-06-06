using System;
using System.Collections;
using UnityEngine;
using Utility;
using Utility.Helpers;

namespace Internal.Time
{
    public class TimeManager : TestableMonoBehaviour
    {
#if (UNITY_EDITOR)
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
                    OnTimeUpdated?.Invoke(timePassedInEditor);
                else
                    OnTimeUpdated?.Invoke(TimeHelpers.TimePassed());

                yield return new WaitForEndOfFrame();
#else
                OnTimeUpdated.Invoke(TimeHelpers.TimePassed());
                yield return new WaitForSecondsRealtime(300);
#endif
            }
        }
    }
}
