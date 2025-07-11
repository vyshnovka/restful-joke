using External.JokeAPI;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        [Header("Checkbox Settings Data")]
        [SerializeField]
        private List<CategoryCheckbox> categories;
        [SerializeField]
        private List<BlacklistCheckbox> blacklisted;

        // TODO: Use events and subscribe instead of assigning via editor.
        /// <summary>
        /// Save all toggle values to <see cref="PlayerPrefs"/>.
        /// </summary>
        public void ApplySettings()
        {
            WriteSettings(categories);
            WriteSettings(blacklisted);

            PlayerPrefs.Save();
        }

        /// <summary>
        /// Go through all checkboxes and save only changed values to <see cref="PlayerPrefs"/>.
        /// </summary>
        /// <typeparam name="T">Instances of settings acting as checkboxes (e.g. categories).</typeparam>
        /// <param name="options">List of checkboxes to go through.</param>
        private void WriteSettings<T>(List<T> options) where T : ICheckbox
        {
            foreach (var option in options)
            {
                if (option != null && option.HasChanged)
                {
                    PlayerPrefs.SetInt(option.ToggleKey, option.IsOn ? 1 : 0);
                    option.HasChanged = false;
                }
            }
        }
    }
}
