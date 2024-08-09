using UnityEngine;

namespace Internal.Visuals
{
    public class GlobalLight : Illumination
    {
        [SerializeField]
        private Light globalLight;

        [SerializeField]
        private float minIntensity = 0.3f;
        [SerializeField]
        private float maxIntensity = 0.9f;

        public override void UpdateTimeVisual(float timePassed)
        {
            float intensityFactor = (Mathf.Sin(timePassed * Mathf.PI * 2 - Mathf.PI / 2) + 1) * 0.5f;
            globalLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, intensityFactor);
        }
    }
}
