using Internal.Audio;
using UnityEngine;
using Utility.Extensions;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Scene References")]
        [SerializeField]
        private GameObject gameplayCanvas;
        [SerializeField]
        private GameObject loadingCanvas;
        [SerializeField]
        private GameObject creditsCanvas;

        public void StartGameplay()
        {
            // TODO: Not the best approach. Refactor!
            AudioManager.OnPlaySound.Invoke("Button", null);

            _ = loadingCanvas.ToggleActiveAfterDelay(4f);
            _ = gameplayCanvas.ToggleActiveAfterDelay(10f);
            _ = loadingCanvas.ToggleActiveAfterDelay(11f);
        }

        public void ExitGame() => Application.Quit();
    }
}
