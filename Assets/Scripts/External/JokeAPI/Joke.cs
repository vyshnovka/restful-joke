using System;

namespace External.JokeAPI
{
    [Serializable]
    public class Joke
    {
        public bool error;
        public string category;
        public string type;
        public string joke = "There are no jokes for you today. But hasn't your life laughed at you yet?"; // Default value in case of missing joke (e.g. an error in web response might lead to this field being empty).
        public struct Flags
        {
            public bool nsfw;
            public bool religious;
            public bool political;
            public bool racist;
            public bool sexist;
            public bool explic;
        }
        public int id;
        public bool safe;
        public string lang;
    }
}
