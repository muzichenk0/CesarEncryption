
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


Console.Write("Type text: ");
string ChoosenText = Console.ReadLine();

Console.WriteLine("What do u want to do?\n 1 - Encrypt text\n 2 - DeCrypt text");
int vibor = Int32.Parse(Console.ReadLine());

ReadyComplect ToWork = new ReadyComplect("rus", ChoosenText);

CesarEncryption FirsAttempt = new CesarEncryption(ToWork, vibor);

class ReadyComplect
{
    public string? Alphavet { get; set; }
    public string? TextToCrypt { get; set; }

    public string[] Alphabets = new string[2] { "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛИНОПРСТУФХЦЧШЩЬЫЬЭЮЯ", ""};
    public ReadyComplect(string alpha, string text)
    {
        if (alpha == "rus")
        {
            Alphavet = Alphabets[1];
        }
        else if (alpha == "eng")
        {
            Alphavet = Alphabets[2];
        }
        TextToCrypt = text;
    }
}

class CesarEncryption : ReadyComplect
{
    private string Kirillica = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛИНОПРСТУФХЦЧШЩЬЫЬЭЮЯ";

    public CesarEncryption(ReadyComplect nabor, int vibor) : base(nabor.Alphavet, nabor.Alphavet )
    {
        switch (vibor)
        {
            case 1:
                Console.WriteLine(Encryption(nabor.TextToCrypt, nabor.Alphavet));
                break;
            case 2:
                Console.WriteLine(DeCryption(nabor.TextToCrypt, nabor.Alphavet));
                break;
        }

    }

    public static string Encryption(string text, string Alpha)
    {
        var result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < Alpha.Length; j++)
            {
                if (text[i] == Alpha[j])
                {
                    result.Append(Alpha[(j + 3) % Alpha.Length]);
                   
                }
            }
        }
        return result.ToString();
    }
    public static string DeCryption(string text, string Alpha)
    {
        var result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < Alpha.Length; j++)
            {
                result.Append(Alpha[(j - 3 + Alpha.Length) % Alpha.Length ]);
            }
        }
        return result.ToString();
        
    }
}