using System;
using System.Net;
using System.IO;
using UnityEngine;

[Serializable]
public class Joke
{
    public bool error;
    public string category;
    public string type;
    public string joke;
    public struct flags
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

public static class JokeAPI
{
    public static Joke GenerateJoke()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/Miscellaneous,Dark,Pun,Spooky?type=single");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Joke>(json);
    }
}
