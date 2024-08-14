using UnityEngine;
using Utility.DataStructures;
using Utility.Helpers;

namespace Internal.Visuals
{
    public class Lamp : Illumination
    {
        [SerializeField]
        private Light lamp;

        [SerializeField]
        private NumericInterval<float>[] timeWithLightON;

        public override void UpdateTimeVisual(float timePassed) => lamp.enabled = NumericHelpers.IsInIntervals(timePassed, timeWithLightON);
    }
}
