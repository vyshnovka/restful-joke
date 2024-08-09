using UnityEngine;
using UnityEngine.UI;

namespace Internal.Visuals
{
    public class Background : Illumination
    {
        [SerializeField]
        private RawImage viewImage;

        [SerializeField]
        private Gradient colorGradient;

        public override void UpdateTimeVisual(float timePassed) => viewImage.color = colorGradient.Evaluate(timePassed);
    }
}
