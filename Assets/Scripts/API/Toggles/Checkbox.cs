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

        toggle.isOn = PlayerPrefs.GetInt(toggleValue.ToString(), 1) == 1 ? true : false;
    }

    public void OnToggle(bool value)
    {
        PlayerPrefs.SetInt(toggleValue.ToString(), toggle.isOn == true ? 1 : 0);
    }
}
