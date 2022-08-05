using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryCheckbox : Checkbox
{
    [SerializeField]
    private Category toggleValue;

    public override void OnToggle(bool value)
    {
        PlayerPrefs.SetInt(toggleValue.ToString(), toggle.isOn == true ? 1 : 0);
    }
}
