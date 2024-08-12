using UnityEngine;
using TMPro;
using System.Collections;
using External.JokeAPI;

namespace Internal.Gameplay
{
    public class TypingManager : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField]
        private TextMeshProUGUI typingText;

        [SerializeField]
        private Color nextLetterColor = Color.gray;
        [SerializeField]
        private Color wrongLetterColor = Color.red;
        [SerializeField]
        private Color rightLetterColor = Color.green;

        [SerializeField]
        private char typingSymbol = '|';
        [SerializeField]
        private float blinkSpeed = 0.5f;

        private string sentenceToType = "Type this.\nYeah, like that...";
        private int currentLetterIndex;
        private bool isKeyHeld;
        private bool isCorrectLetter;
        private bool isSentenceComplete = false;

        void Start()
        {
            //sentenceToType = JokeAPI.GenerateJoke().joke; //? What about JokeManager?
            sentenceToType = sentenceToType.Replace("\n", " ");
            currentLetterIndex = 0;
            StartCoroutine(BlinkTypingSymbol());
            UpdateTypingText();
        }

        void Update()
        {
            if (Input.anyKeyDown && !isSentenceComplete)
            {
                if (!string.IsNullOrEmpty(Input.inputString))
                {
                    char inputChar = Input.inputString.ToLower()[0];
                    isKeyHeld = true;

                    if (inputChar == sentenceToType[currentLetterIndex].ToString().ToLower()[0])
                    {
                        isCorrectLetter = true;
                        UpdateTypingText();
                    }
                    else
                    {
                        isCorrectLetter = false;
                        UpdateTypingText();
                    }
                }
            }

            if (!Input.anyKey && isKeyHeld)
            {
                isKeyHeld = false;

                if (isCorrectLetter)
                {
                    currentLetterIndex++;
                }

                isCorrectLetter = false;
                UpdateTypingText();

                if (currentLetterIndex >= sentenceToType.Length)
                {
                    isSentenceComplete = true;
                    StopCoroutine(BlinkTypingSymbol());
                    typingText.text = sentenceToType;
                }
            }
        }

        private void UpdateTypingText()
        {
            string typedPart = sentenceToType[..currentLetterIndex];
            string nextLetter = currentLetterIndex < sentenceToType.Length ? sentenceToType[currentLetterIndex].ToString() : "";

            string displayNextLetter = nextLetter == " " ? "[space]" : nextLetter;
            string currentColor = isKeyHeld ? (isCorrectLetter ? ColorUtility.ToHtmlStringRGB(rightLetterColor) : ColorUtility.ToHtmlStringRGB(wrongLetterColor)) : ColorUtility.ToHtmlStringRGB(nextLetterColor);

            if (!string.IsNullOrEmpty(nextLetter))
            {
                typingText.text = $"{typedPart}{typingSymbol}<color=#{currentColor}>{displayNextLetter}</color>";
            }
            else
            {
                typingText.text = $"{typedPart}{typingSymbol}";
            }
        }

        //TODO: Same logic in menu UI. Reuse the code!!!
        private IEnumerator BlinkTypingSymbol()
        {
            while (!isSentenceComplete)
            {
                //! Issue when the new line starts.
                typingSymbol = typingSymbol == '|' ? ' ' : '|';
                UpdateTypingText();
                yield return new WaitForSeconds(blinkSpeed);
            }
        }
    }
}
