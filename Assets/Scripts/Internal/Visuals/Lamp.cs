using UnityEngine;

namespace Internal.Visuals
{
    //TODO: Make more generic!
    [System.Serializable]
    public struct TimeInterval
    {
        public float startTime;
        public float endTime;
    }

    public class Lamp : Illumination
    {
        [SerializeField]
        private Light lamp;

        [SerializeField]
        private TimeInterval[] timeWithLightON;

        public override void UpdateTimeVisual(float timePassed)
        {
            lamp.enabled = IsInTimeIntervals(timePassed, timeWithLightON);
        }

        //? Maybe make as an extension?
        private bool IsInTimeIntervals(float timePassed, TimeInterval[] intervals)
        {
            foreach (var interval in intervals)
            {
                if (timePassed >= interval.startTime && timePassed <= interval.endTime)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
