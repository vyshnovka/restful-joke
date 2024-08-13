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
        private TextMeshProUGUI typingZone;
        [SerializeField]
        private TextMeshProUGUI nextTextZone;

        [SerializeField]
        private Color nextLetterColor = Color.gray;
        [SerializeField]
        private Color wrongLetterColor = Color.red;
        [SerializeField]
        private Color rightLetterColor = Color.green;

        [SerializeField]
        private string typingSymbol = "|";
        [SerializeField]
        private string nextText = "Press [Enter] to continue...";

        private string sentenceToType = "Type this."; //TODO: Make this for debug only.
        private int currentLetterIndex;
        private bool isKeyHeld;
        private bool isCorrectLetter;
        private bool isSentenceCompleted = false;
        private bool isBlinking = false; //! BAD. Just for testing.

        void Start()
        {
            Reset();
        }

        void Update()
        {
            if (!isSentenceCompleted)
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
                        isSentenceCompleted = true;
                        StopAllCoroutines();
                        typingZone.text = sentenceToType;
                    }
                }
            }
            else
            {
                if (!isBlinking)
                {
                    //? This is a temp solution. Need to find a better one.
                    nextTextZone.gameObject.SetActive(true);
                    nextTextZone.text = nextText;

                    StartCoroutine(UIHelpers.BlinkContent(
                        nextText,
                        " ",
                        (newText) =>
                        {
                            nextTextZone.text = newText;
                        },
                        0.5f));

                    isBlinking = true;
                }

                if (Input.GetKeyUp(KeyCode.Return))
                {
                    nextTextZone.gameObject.SetActive(false);
                    isBlinking = false;
                    StopAllCoroutines();
                    Reset();
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
                typingZone.text = $"{typedPart}{typingSymbol}<color=#{currentColor}>{displayNextLetter}</color>";
            }
            else
            {
                typingZone.text = $"{typedPart}{typingSymbol}";
            }
        }

        private void Reset()
        {
            //sentenceToType = JokeAPI.GenerateJoke().joke; //? What about JokeManager?
            sentenceToType = sentenceToType.Replace("\n", " ");
            currentLetterIndex = 0;
            isSentenceCompleted = false;
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
    }
}
