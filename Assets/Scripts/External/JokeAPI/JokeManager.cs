using TMPro;
using UnityEngine;

namespace External.JokeAPI
{
    public class JokeManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI jokeText;

        public void GetJoke()
        {
            Joke joke = JokeAPI.GenerateJoke();

            jokeText.text = joke.joke;
        }
    }
}

