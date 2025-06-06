using External.JokeAPI.Definitions;
using System;
using System.IO;
using System.Net;
using UnityEngine;

namespace External.JokeAPI
{
    public static class JokeAPI
    {
        /// <summary>
        /// Generate a srting of categories in API-appropriate form.
        /// </summary>
        /// <returns>A string of selected categories.</returns>
        private static string SetCategory()
        {
            string request = "";

            foreach (Category item in Enum.GetValues(typeof(Category)))
            {
                if (PlayerPrefs.GetInt(item.ToString(), 1) == 1)
                    request += item.ToString() + ",";
            }

            return string.IsNullOrEmpty(request) ? "Programming,Miscellaneous,Dark,Pun,Spooky" : request[..^1];
        }

        /// <summary>
        /// Generate a string of blacklisted topics in API-appropriate form.
        /// </summary>
        /// <returns>A string of topics to blacklist.</returns>
        private static string SetBlacklist()
        {
            string request = "";

            foreach (Blacklist item in Enum.GetValues(typeof(Blacklist)))
            {
                if (PlayerPrefs.GetInt(item.ToString(), 1) == 1)
                    request += item.ToString() + ",";
            }

            return string.IsNullOrEmpty(request) ? request : "blacklistFlags=" + request.ToLower()[..(request.Length - 1)] + "&";
        }

        /// <summary>
        /// Send web request to <see href="https://v2.jokeapi.dev/">JokeAPI</see> and generates response in form of a <see cref="Joke"/>.
        /// </summary>
        public static Joke GenerateJoke()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL.WebRequest + SetCategory() + "?" + SetBlacklist() + "type=single");
                
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
}
