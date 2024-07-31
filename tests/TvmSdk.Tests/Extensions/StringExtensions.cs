using System.Globalization;

namespace TvmSdk.Tests.Extensions;

public static class StringExtensions
{
    public static string HexToBase64(this string hexString)
    {
        return System.Convert.ToBase64String(ToBytes(hexString));
    }

    public static byte[] ToBytes(this string hexString)
    {
        byte[] byteArray = new byte[hexString.Length / 2];
    
        for (int index = 0; index < byteArray.Length; index++)
        {
            string byteValue = hexString.Substring(index * 2, 2);
            byteArray[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }
    
        return byteArray;
    }
    
    public static string ToBase64(this string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string FromBase64(this string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}