
int valorInt = 5;
byte valorByte = 12;
short valorShort = 300;


long intParaLong = valorInt;
int shortParaInt = valorShort;
short byteParaShort = valorByte;

Console.WriteLine("VALORES DAS VARIAVEIS ANTES DA CONVERSÃO : \n");
Console.WriteLine($"Byte: {valorByte}");
Console.WriteLine($"Short: {valorShort}");
Console.WriteLine($"Int: {valorInt}");

Console.WriteLine("VALORES DAS VARIAVEIS DEPOIS DA CONVERSÃO : \n");
Console.WriteLine($"Int para Long: {intParaLong}");
Console.WriteLine($"Short para Int: {shortParaInt}");
Console.WriteLine($"Byte para Short: {byteParaShort}");