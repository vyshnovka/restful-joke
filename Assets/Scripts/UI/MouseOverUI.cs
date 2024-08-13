using TMPro;
using UnityEngine;
using Utility.Helpers;

namespace UI
{
    public class MouseOverUI : MonoBehaviour
    {
        private TextMeshProUGUI menuItem;

        void Awake() => menuItem = transform.GetComponentInChildren<TextMeshProUGUI>();

        void OnEnable() => menuItem.text = menuItem.text.TrimEnd('|');

        public void MouseEnter()
        {
            StartCoroutine(UIHelpers.BlinkContent(
                menuItem.text, 
                menuItem.text + "|", 
                (newText) => 
                { 
                    menuItem.text = newText; 
                }, 
                0.5f));
        }

        public void MouseExit()
        {
            StopAllCoroutines();
            menuItem.text = menuItem.text.TrimEnd('|');
        }
    }
}
