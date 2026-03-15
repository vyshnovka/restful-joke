using Services.JokeAPI;
using UnityEngine;

namespace Gameplay.Typing
{
    public class JokeManager : MonoBehaviour
    {
        public static string GetJoke() => JokeAPI.GenerateJoke().joke;
    }
}

