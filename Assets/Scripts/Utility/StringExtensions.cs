using System.Text;

public static class StringExtensions
{
    /// <summary>Wrap string <paramref name="str"/> with <paramref name="prefix"/> and <paramref name="postfix"/>.</summary>
    public static string Wrap(this string str, string prefix = "", string postfix = "") => $"{prefix}{str}{postfix}";

    /// <summary>Strip character <paramref name="ch"/> from string <paramref name="str"/>.</summary>
    public static string Strip(this string str, char ch)
    {
        if (string.IsNullOrEmpty(str)) return str;

        var index = str.IndexOf(ch);
        if (index < 0) return str;

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
