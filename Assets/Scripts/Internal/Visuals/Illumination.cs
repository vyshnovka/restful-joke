using Internal.Time;
using UnityEngine;

namespace Internal.Visuals
{
    public abstract class Illumination : MonoBehaviour
    {
        private TimeManager timeManager;

        // TODO: Not the best approach with looking for an object. Refactor!
        void OnEnable()
        {
            timeManager = FindObjectOfType<TimeManager>();
            timeManager.OnTimeUpdated += UpdateTimeVisual;
        }

        void OnDisable() => timeManager.OnTimeUpdated -= UpdateTimeVisual;

        public abstract void UpdateTimeVisual(float timePassed);
    }
}
