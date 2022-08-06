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

public enum Category
{
    Programming,
    Miscellaneous,
    Dark,
    Pun,
    Spooky
}

public enum Blacklist
{
    Nsfw,
    Religious,
    Politician,
    Racist,
    Sexist,
    Explicit
}

public static class JokeAPI
{
    private static string SetCategory()
    {
        return "Programming,Miscellaneous,Dark,Pun,Spooky";
    }

    private static string SetBlacklist()
    {
        return "";
    }

    public static Joke GenerateJoke()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/" + SetCategory() + "?" + SetBlacklist() + "type=single");

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Joke>(json);
    }
}
