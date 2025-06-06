using Internal.Audio;
using TMPro;
using UnityEngine;
using Utility;
using Utility.Helpers;

//TODO: REFACTOR!!!
namespace Internal.Gameplay
{
    public class TypingManager : TestableMonoBehaviour
    {
        [Header("Scene References")]
        [SerializeField]
        private TextMeshProUGUI typingZone;
        [SerializeField]
        private TextMeshProUGUI nextTextZone;

        [Header("Color Data")]
        [SerializeField]
        private Color nextLetterColor = Color.gray;
        [SerializeField]
        private Color wrongLetterColor = Color.red;
        [SerializeField]
        private Color rightLetterColor = Color.green;

        [Header("Strings Data")]
        [SerializeField]
        private string typingSymbol = "|";
        [SerializeField]
        private string nextText = "Press [Enter] to continue...";

        private string sentenceToType;
        private int currentLetterIndex;

        //TODO: Make a state machine out of all the flags.
        private bool isKeyHeld;
        private bool isCorrectLetter;
        private bool isSentenceCompleted = false;
        private bool isBlinking = false; //! BAD. Just for testing.

        public void StartGame() => Reset();

        void Update()
        {
            if (!isSentenceCompleted)
            {
                HandleTypingInput();
            }
            else
            {
                HandleSentenceCompletion();
            }
        }

        private void HandleTypingInput()
        {
            if (Input.anyKeyDown && !string.IsNullOrEmpty(Input.inputString))
            {
                char inputChar = Input.inputString.ToLower()[0];
                isKeyHeld = true;

                isCorrectLetter = inputChar == sentenceToType[currentLetterIndex].ToString().ToLower()[0];
                SelectAndPlayTypingSound(isCorrectLetter);
                UpdateTypingText();
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
                    CompleteSentence();
                }
            }
        }

        private void CompleteSentence()
        {
            isSentenceCompleted = true;
            StopAllCoroutines();
            typingZone.text = sentenceToType;
        }

        private void HandleSentenceCompletion()
        {
            if (!isBlinking)
            {
                StartBlinking();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                AudioManager.OnPlaySound.Invoke("Other Keys", "Spacebar Key");

                StopBlinking();
                Reset();
            }
        }

        //TODO: Separate from typing, this is clearly UI!
        private void StartBlinking()
        {
            nextTextZone.gameObject.SetActive(true);
            nextTextZone.text = nextText;

            StartCoroutine(UIHelpers.BlinkContent(
                nextText,
                " ",
                newText => nextTextZone.text = newText,
                0.75f));

            isBlinking = true;
        }

        private void StopBlinking()
        {
            nextTextZone.gameObject.SetActive(false);
            isBlinking = false;
            StopAllCoroutines();
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

        private void SelectAndPlayTypingSound(bool isCorrectLetter = true)
        {
            string category;
            string name;

            if (isCorrectLetter)
            {
                var isSpacePressed = Input.GetKeyDown(KeyCode.Space);

                category = isSpacePressed ? "Other Keys" : "Main Keys";
                name = isSpacePressed ? "Spacebar Key" : null;
            }
            else
            {
                category = "Other Keys";
                name = "Wrong Key";
            }

            AudioManager.OnPlaySound.Invoke(category, name);
        }

        private void Reset()
        {
#if (UNITY_EDITOR)
            if (testInEditor)
                sentenceToType = "Testing the code.\nHello!";
            else
                sentenceToType = JokeManager.GetJoke();
#else
            sentenceToType = JokeManager.GetJoke();
#endif
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
