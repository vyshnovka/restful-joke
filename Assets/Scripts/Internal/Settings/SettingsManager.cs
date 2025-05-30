using External.JokeAPI;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField]
        private List<CategoryCheckbox> categories;
        [SerializeField]
        private List<BlacklistCheckbox> blacklisted;

        // TODO: Use events and subscribe instead of assigning via editor.
        /// <summary>Saves all toggle values to <see cref="PlayerPrefs"/>.</summary>
        public void ApplySettings()
        {
            foreach (var category in categories)
            {
                if (category != null && category.HasChanged)
                {
                    PlayerPrefs.SetInt(category.ToggleKey, category.IsOn ? 1 : 0);
                    category.HasChanged = false;
                }
            }

            foreach (var blacklisted in blacklisted)
            {
                if (blacklisted != null && blacklisted.HasChanged)
                {
                    PlayerPrefs.SetInt(blacklisted.ToggleKey, blacklisted.IsOn ? 1 : 0);
                    blacklisted.HasChanged = false;
                } 
            }

            PlayerPrefs.Save();
        }
    }
}
