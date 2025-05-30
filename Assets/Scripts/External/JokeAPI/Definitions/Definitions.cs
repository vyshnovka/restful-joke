namespace External.JokeAPI.Definitions
{
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

    public static class URL
    {
        public static string WebRequest = "https://v2.jokeapi.dev/joke/";
    }
}
