using System.Text;
using TvmSdk;
using TvmSdk.Modules.Crypto;

using var client = new TvmClient();
var text = "example of sha256";
var textBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
var result = await client.Crypto.Sha256(new ParamsOfHash
{
    Data = textBase64
});
var sha256 = result.Hash;

Console.WriteLine($"SHA256 of text '{text}' is: {sha256}");
// SHA256 of text 'example of sha256' is: 59357a7b134da94ac14e18fe2f20b0c1815786a15c4e840a29e32de1842a655b