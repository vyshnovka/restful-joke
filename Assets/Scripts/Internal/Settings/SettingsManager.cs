using External.JokeAPI;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private List<CategoryCheckbox> categories;
    [SerializeField]
    private List<BlacklistCheckbox> blacklisted;

    //TODO: Find a way to reuse the code and not rely on going through every list manually!
    /// <summary>Saves all toggle values to <see cref="PlayerPrefs"/>.</summary>
    public void ApplySettings()
    {
        foreach (var category in categories)
        {
            PlayerPrefs.SetInt(category.ToggleValue.ToString(), category.IsOn ? 1 : 0);
        }

        foreach (var blacklisted in blacklisted)
        {
            PlayerPrefs.SetInt(blacklisted.ToggleValue.ToString(), blacklisted.IsOn ? 1 : 0);
        }
    }
}
