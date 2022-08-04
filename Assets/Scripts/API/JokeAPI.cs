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
    Misc,
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
    public static string category;
    public static string blacklist;

    public static void SetCategory()
    {
        //category = Category.Any.ToString();
        category = "Programming,Miscellaneous,Dark,Pun,Spooky";
    }

    public static void SetBlacklist()
    {
        blacklist = "";
    }

    public static Joke GenerateJoke()
    {
        SetCategory();
        SetBlacklist();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/" + category + "?" + blacklist + "type=single");

        Debug.Log(category + " " + blacklist);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Joke>(json);
    }
}
