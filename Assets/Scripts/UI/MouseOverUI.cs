using System.Collections;
using UnityEngine;
using TMPro;

namespace UI
{
    public class MouseOverUI : MonoBehaviour
    {
        private TextMeshProUGUI menuItem;

        void Awake() => menuItem = transform.GetComponentInChildren<TextMeshProUGUI>();

        void OnEnable() => menuItem.text = menuItem.text.TrimEnd('|');

        public void MouseEnter() => StartCoroutine(CarriagePing());

        public void MouseExit()
        {
            StopAllCoroutines();

            menuItem.text = menuItem.text.TrimEnd('|');
        }

        //TODO: Same as TypingManager.BlinkTypingSymbol(). Reuse!
        private IEnumerator CarriagePing()
        {
            while (true)
            {
                menuItem.text += "|";
                yield return new WaitForSecondsRealtime(0.5f);

                menuItem.text = menuItem.text.TrimEnd('|');
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
    }
}
