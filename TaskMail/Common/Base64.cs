using System.Text;

public static class Base64Helper
{
    public static string Encode(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return string.Empty;
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainBytes);
    }

    public static string Decode(string base64Encoded)
    {
        if (string.IsNullOrEmpty(base64Encoded)) return string.Empty;
        var bytes = Convert.FromBase64String(base64Encoded);
        return Encoding.UTF8.GetString(bytes);
    }
}
