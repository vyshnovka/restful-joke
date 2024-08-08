using System;

namespace Utility.Helpers
{
    public static class TimeHelpers
    {
        /// <summary>Calculates time passed since midnight in seconds.</summary>
        /// <returns>Returns time ratio (from 0 to 1).</returns>
        public static float TimePassed()
        {
            DateTime time = DateTime.Now;

            float secondsPassed = time.Hour * 60 * 60 + time.Minute * 60 + time.Second;
            float secondsFull = 24 * 60 * 60;

            float timeRatio = secondsPassed / secondsFull;

            return timeRatio;
        }
    }
}
