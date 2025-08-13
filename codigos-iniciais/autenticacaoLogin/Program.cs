
string loginDefinido = "nickolas_mello";
string senhaDefinida = "CristianoRonaldo";


Console.Write("\nInsira seu login : ");
string? login = Console.ReadLine();

Console.Write("Insira sua senha : ");
string? senha = Console.ReadLine();

if (login == loginDefinido && senha == senhaDefinida)
{
  Console.WriteLine("\nSeu login foi feito com sucesso!");
}
else
{
  Console.WriteLine("\nSenha ou Login incorretos!");
}