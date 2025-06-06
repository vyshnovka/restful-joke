using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Utility.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Wrap string <paramref name="str"/> with <paramref name="prefix"/> and <paramref name="postfix"/>.
        /// </summary>
        public static string Wrap(this string str, string prefix = "", string postfix = "") => $"{prefix}{str}{postfix}";

        /// <summary>
        /// Strip character <paramref name="ch"/> from string <paramref name="str"/>.
        /// </summary>
        public static string Strip(this string str, char ch)
        {
            if (string.IsNullOrEmpty(str)) 
                return str;

            var index = str.IndexOf(ch);
            if (index < 0) 
                return str;

            var sb = new StringBuilder();
            do
            {
                sb.Append(str[..index]);
                str = str[(index + 1)..];
                index = str.IndexOf(ch);
            } while (index >= 0);

            sb.Append(str);
            return sb.ToString();
        }
    }

    public static class GameObjectExtensions
    {
        /// <summary>
        /// Toggle <paramref name="gameObject"/> active state after given <paramref name="delay"/> in seconds.
        /// </summary>
        public static async Task ToggleActiveAfterDelay(this GameObject gameObject, float delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }

    public static class ActionExtensions
    {
        /// <summary>
        /// Invoke <paramref name="action"/> after given <paramref name="delay"/> in seconds.
        /// </summary>
        public static async Task TimedEvent(this Action targetAction, float delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            targetAction.Invoke();
        }
    }
}
