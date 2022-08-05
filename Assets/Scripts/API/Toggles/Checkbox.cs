using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Checkbox : MonoBehaviour
{
    [NonSerialized]
    public Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();

        toggle.onValueChanged.AddListener(OnToggle);
    }

    public abstract void OnToggle(bool value);
}
