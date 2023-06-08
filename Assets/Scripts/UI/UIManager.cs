using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameplayCanvas;
    [SerializeField]
    private GameObject loadingGif;
    [SerializeField]
    private GameObject windowsBackground;

    public void StartGameplay()
    {
        // Not the nicest solution, need to find more robust way.
        StartCoroutine(gameplayCanvas.ToggleActiveAfterDelay(4.5f));
        StartCoroutine(loadingGif.ToggleActiveAfterDelay(10));
        StartCoroutine(windowsBackground.ToggleActiveAfterDelay(10));
    }

    public void ExitGame() => Application.Quit();
}
