using UnityEngine;
using UnityEngine.UI;

public class Checkbox<T> : MonoBehaviour
{
    private Toggle toggle;

    [SerializeField]
    private T toggleValue;

    void Start()
    {
        toggle = GetComponent<Toggle>();

        toggle.onValueChanged.AddListener(OnToggle);

        toggle.isOn = PlayerPrefs.GetInt(toggleValue.ToString(), 1) == 1;
    }
    void OnDisable() => toggle.onValueChanged.RemoveAllListeners();

    /// <summary>Saves toggle value to <see cref="PlayerPrefs"/>.</summary>
    private void OnToggle(bool value) => PlayerPrefs.SetInt(toggleValue.ToString(), toggle.isOn ? 1 : 0);

}
