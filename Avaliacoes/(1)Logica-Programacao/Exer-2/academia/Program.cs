Console.WriteLine("Qual o nome do usuário ? ");
string nomeusuario = Console.ReadLine()!;

Console.WriteLine($"Qual a idade do/da {nomeusuario} ? ");
int idadeUsuario = int.Parse(Console.ReadLine()!);

Console.WriteLine($"Qual o valor da mensalidade do/da {nomeusuario} ? ");
double mensalidadeUsuario = double.Parse(Console.ReadLine()!);

double desconto10 = 0.1;
double desconto20 = 0.2;

double mensalidadeComDesconto = mensalidadeUsuario;

if (idadeUsuario >= 40 && idadeUsuario <= 50)
{
  mensalidadeComDesconto = mensalidadeUsuario - (mensalidadeUsuario * desconto10);
}
else if (idadeUsuario > 50)
{
  mensalidadeComDesconto = mensalidadeUsuario - (mensalidadeUsuario * desconto20);
}

Console.WriteLine($"O valor da mensalidade do/da {nomeusuario} será de : R${mensalidadeComDesconto}");