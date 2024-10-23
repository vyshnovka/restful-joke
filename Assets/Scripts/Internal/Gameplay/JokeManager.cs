using External.JokeAPI;
using UnityEngine;

namespace Internal.Gameplay
{
    public class JokeManager : MonoBehaviour
    {
        public static string GetJoke() => JokeAPI.GenerateJoke().joke;
    }
}

