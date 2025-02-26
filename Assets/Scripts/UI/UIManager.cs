using Internal.Audio;
using UnityEngine;
using Utility.Extensions;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameplayCanvas;
        [SerializeField]
        private GameObject loadingCanvas;
        [SerializeField]
        private GameObject creditsCanvas;

        public void StartGameplay()
        {
            //Not the best approach.
            AudioManager.OnPlaySound.Invoke("Button", null);

            _ = loadingCanvas.ToggleActiveAfterDelay(4f);
            _ = gameplayCanvas.ToggleActiveAfterDelay(10f);
            _ = loadingCanvas.ToggleActiveAfterDelay(11f);
        }

        public void ExitGame() => Application.Quit();

        public void EnableCredits()
        {
            _ = creditsCanvas.ToggleActiveAfterDelay(15f);
        }
    }
}
