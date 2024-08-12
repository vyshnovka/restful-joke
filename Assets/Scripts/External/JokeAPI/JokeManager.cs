using UnityEngine;

namespace External.JokeAPI
{
    //? Do I even need this?..
    public class JokeManager : MonoBehaviour
    {
        public string GetJoke() => JokeAPI.GenerateJoke().joke;
    }
}

