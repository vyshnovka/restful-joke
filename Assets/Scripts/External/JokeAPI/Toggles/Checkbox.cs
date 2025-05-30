using System;
using UnityEngine;
using UnityEngine.UI;

namespace External.JokeAPI
{
    [Serializable]
    public class Checkbox<T> : MonoBehaviour
    {
        [SerializeField]
        private T toggleValue;

        public bool IsOn => toggle.isOn;
        public string ToggleKey => toggleValue.ToString();

        public bool HasChanged { get => hasChanged; set => hasChanged = value; }

        private Toggle toggle;
        private bool hasChanged = false;

        void OnEnable()
        {
            toggle = GetComponent<Toggle>();
            toggle.isOn = PlayerPrefs.GetInt(ToggleKey, 1) == 1;

            toggle.onValueChanged.AddListener((_) => HasChanged = true);
        }

        void OnDisable()
        {
            toggle.onValueChanged.RemoveAllListeners();
        }
    }
}
