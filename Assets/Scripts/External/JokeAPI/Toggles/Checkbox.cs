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

        private Toggle toggle;

        public bool IsOn => toggle.isOn;
        public string ToggleValue => toggleValue.ToString();

        void Start()
        {
            toggle = GetComponent<Toggle>();

            toggle.isOn = PlayerPrefs.GetInt(ToggleValue.ToString(), 1) == 1;
        }
    }
}
