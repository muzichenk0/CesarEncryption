using System.Text.RegularExpressions;
using System.Text;


Console.Write("Type text: ");
string ChoosenText = Console.ReadLine();


Console.WriteLine("What do u want to do?\n 1 - Encrypt text\n 2 - DeCrypt text");
int vibor = Int32.Parse(Console.ReadLine());

ReadyComplect ToWork = new ReadyComplect(ChoosenText);

CesarEncryption FirsAttempt = new CesarEncryption(ToWork, vibor);

class ReadyComplect
{
    public string? Alphavet { get; set; }
    public string? TextToCrypt { get; set; }

    private string Kirillica = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛИНОПРСТУФХЦЧШЩЬЫЬЭЮЯ";
    private string Latin = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    public ReadyComplect(string text)
    {
       
            Regex russian = new Regex("абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛИНОПРСТУФХЦЧШЩЬЫЬЭЮЯ");
            Match mr = russian.Match(text);

            Regex english = new Regex("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
            Match me = english.Match(text);
            if (mr.Success)
            {
            Alphavet = Kirillica;
            }
            else if (me.Success)
            {
            Alphavet = Latin;
            }
            else
            {
                Alphavet = Kirillica + Latin;
            }

       
        
        TextToCrypt = text;
    }
}

class CesarEncryption : ReadyComplect
{
    public CesarEncryption(ReadyComplect nabor, int vibor) : base(nabor.TextToCrypt)
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