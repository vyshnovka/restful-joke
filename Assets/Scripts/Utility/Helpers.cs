using System;
using System.Collections;
using UnityEngine;
using Utility.DataStructures;

namespace Utility.Helpers
{
    public static class TimeHelpers
    {
        /// <summary>
        /// Calculates time passed since midnight in seconds.
        /// </summary>
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

    public static class UIHelpers
    {
        /// <summary>
        /// Blink a symbol, part of a string, or the entire string.
        /// </summary>
        /// <param name="blinkState1">Current text state.</param>
        /// <param name="blinkState1">Text state after blinking.</param>
        /// <param name="setText">An action to update the text.</param>
        /// <param name="interval">Blinking interval in seconds.</param>
        /// <param name="loop">Whether the blinking should loop indefinitely.</param>
        public static IEnumerator BlinkContent(string blinkState1, string blinkState2, Action<string> setText, float interval, bool loop = true)
        {
            while (loop)
            {
                setText.Invoke(blinkState1);
                yield return new WaitForSecondsRealtime(interval);

                setText.Invoke(blinkState2);
                yield return new WaitForSecondsRealtime(interval);
            }
        }
    }

    public static class NumericHelpers
    {
        /// <summary>
        /// Determines whether a given numeric value falls within any of the specified intervals.
        /// </summary>
        /// <param name="number">The numeric value to check against the intervals.</param>
        /// <param name="intervals">An array of time intervals, each defined by a start and end time.</param>
        /// <returns>Returns <c>true</c> if the value is within any of the specified intervals, <c>false</c> otherwise.</returns>
        public static bool IsInIntervals<T>(T number, NumericInterval<T>[] intervals) where T : IComparable<T>
        {
            foreach (var interval in intervals)
            {
                if (number.CompareTo(interval.start) >= 0 && number.CompareTo(interval.end) <= 0)
                    return true;
            }
            return false;
        }
    }
}
