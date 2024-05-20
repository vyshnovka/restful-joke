using System;
using System.IO;
using System.Net;
using UnityEngine;

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
    Political,
    Racist,
    Sexist,
    Explicit
}

public static class JokeAPI
{
    private static string SetCategory()
    {
        string request = "";

        foreach (Category item in Enum.GetValues(typeof(Category)))
        {
            if (PlayerPrefs.GetInt(item.ToString(), 1) == 1)
                request += item.ToString() + ",";
        }

        return string.IsNullOrEmpty(request) ? "Programming,Miscellaneous,Dark,Pun,Spooky" : request.Remove(request.Length - 1);
    }

    private static string SetBlacklist()
    {
        string request = "";

        foreach (Blacklist item in Enum.GetValues(typeof(Blacklist)))
        {
            if (PlayerPrefs.GetInt(item.ToString(), 1) == 1)
                request += item.ToString() + ",";
        }

        return string.IsNullOrEmpty(request) ? request : "blacklistFlags=" + request.ToLower().Remove(request.Length - 1) + "&";
    }

    /// <summary>Sends web request to <see href="https://sv443.net/jokeapi/v2/">JokeAPI</see> and generates response in form of a <see cref="Joke"/>.</summary>
    public static Joke GenerateJoke()
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://v2.jokeapi.dev/joke/" + SetCategory() + "?" + SetBlacklist() + "type=single");
            // Handling response disposal via 'using' block.
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                StreamReader reader = new(response.GetResponseStream());
                string json = reader.ReadToEnd();

                return JsonUtility.FromJson<Joke>(json);
            }
        }
        catch (WebException)
        {
            return new Joke();
        }
    }
}
