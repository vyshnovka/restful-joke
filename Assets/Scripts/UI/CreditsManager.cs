using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public partial class CreditsManager : MonoBehaviour
    {
        [Header("Credits Info")]
        [SerializeField]
        private List<CreditsGroup> creditsGroups;

        [Header("Scene References")]
        public Button startButton;
        public TextMeshProUGUI headerText;
        public Transform nameContainer;
        public GameObject nameTextPrefab;
        public TextMeshProUGUI thanksText;

        [Header("Delays and Speed Settings")]
        [SerializeField]
        private float headerTypingSpeed = 0.05f;
        [SerializeField]
        private float nameRevealDelay = 0.4f;
        [SerializeField]
        private float pauseAfterHeader = 1f;
        [SerializeField]
        private float pauseAfterNames = 1.5f;
        [SerializeField]
        private float thanksDuration = 3f;

        void Start()
        {
            headerText.text = "";
            thanksText.gameObject.SetActive(false);
            startButton.onClick.AddListener(() => StartCoroutine(PlayCredits()));
        }

        private IEnumerator PlayCredits()
        {
            foreach (Transform child in nameContainer)
            {
                Destroy(child.gameObject);
            }

            foreach (var group in creditsGroups)
            {
                // Type header
                yield return TypeHeader(group.header);
                yield return new WaitForSeconds(pauseAfterHeader);

                headerText.text = "";

                // Pre-create all name entries, but hidden.
                var nameEntries = new List<CanvasGroup>();
                foreach (string name in group.names)
                {
                    GameObject go = Instantiate(nameTextPrefab, nameContainer);
                    var tmp = go.GetComponent<TextMeshProUGUI>();
                    tmp.text = name;

                    var cg = go.GetComponent<CanvasGroup>();
                    if (cg == null)
                        cg = go.AddComponent<CanvasGroup>();

                    cg.alpha = 0;
                    nameEntries.Add(cg);
                }

                // Reveal names one by one.
                foreach (var cg in nameEntries)
                {
                    cg.alpha = 1;
                    yield return new WaitForSeconds(nameRevealDelay);
                }

                yield return new WaitForSeconds(pauseAfterNames);

                // Clean up for next group.
                foreach (Transform child in nameContainer)
                    Destroy(child.gameObject);
            }

            // Final message.
            thanksText.gameObject.SetActive(true);
            yield return new WaitForSeconds(thanksDuration);
            thanksText.gameObject.SetActive(false);

            // TODO: Disable credist canvas.
        }

        private IEnumerator TypeHeader(string text)
        {
            headerText.text = "";
            foreach (char c in text)
            {
                headerText.text += c;
                yield return new WaitForSeconds(headerTypingSpeed);
            }
        }
    }
}