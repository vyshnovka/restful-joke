using TMPro;
using UnityEngine;

public class JokeManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI jokeText;

    public void SetRestrictions()
    {

    }

    public void GetJoke()
    {
        Joke joke = JokeAPI.GenerateJoke();

        jokeText.text = joke.joke;
    }
}
