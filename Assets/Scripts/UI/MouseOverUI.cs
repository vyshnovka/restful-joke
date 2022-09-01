using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseOverUI : MonoBehaviour
{
    private TextMeshProUGUI menuItem;

    private void Start()
    {
        menuItem = transform.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void MouseEnter()
    {
        StartCoroutine(CarriagePing());
    }

    public void MouseExit()
    {
        StopAllCoroutines();

        menuItem.text = menuItem.text.TrimEnd('|'); ;
    }

    private IEnumerator CarriagePing()
    {
        while (true)
        {
            menuItem.text += "|";

            yield return new WaitForSecondsRealtime(0.5f);

            menuItem.text = menuItem.text.TrimEnd('|'); ;

            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
