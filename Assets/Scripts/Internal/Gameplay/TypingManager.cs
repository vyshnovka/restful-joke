using External.JokeAPI;
using TMPro;
using UnityEngine;
using Utility.Helpers;

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
        private string typingSymbol = "|";

        private string sentenceToType = "Type this.\nYeah, like that...";
        private int currentLetterIndex;
        private bool isKeyHeld;
        private bool isCorrectLetter;

        void Start()
        {
            //sentenceToType = JokeAPI.GenerateJoke().joke; //? What about JokeManager?
            sentenceToType = sentenceToType.Replace("\n", " ");
            currentLetterIndex = 0;
            StartCoroutine(UIHelpers.BlinkContent(
                " ",
                "|",
                (newText) =>
                {
                    typingSymbol = newText;
                    UpdateTypingText();
                },
                0.5f));
            UpdateTypingText();
        }

        void Update()
        {
            if (Input.anyKeyDown)
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
                    StopAllCoroutines();
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
    }
}
