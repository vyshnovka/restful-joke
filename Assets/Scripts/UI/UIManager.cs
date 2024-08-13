using UnityEngine;
using Utility.Extensions;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameplayCanvas;
        [SerializeField]
        private GameObject loadingImage;

        public void StartGameplay()
        {
            //TODO: Not the best approach.
            _ = loadingImage.ToggleActiveAfterDelay(4f);
            _ = gameplayCanvas.ToggleActiveAfterDelay(10f);
            _ = loadingImage.ToggleActiveAfterDelay(11f);
        }

        public void ExitGame() => Application.Quit();
    }
}
