string repeat;

do
{
  Console.WriteLine("Digite o primeiro número inteiro :");
  int firstNumber = int.Parse(Console.ReadLine()!);

  Console.WriteLine("Digite o segundo número inteiro :");
  int secondNumber = int.Parse(Console.ReadLine()!);

  Console.WriteLine("\n-------------");
  Console.WriteLine("adição");
  Console.WriteLine("subtração");
  Console.WriteLine("multiplicação");
  Console.WriteLine("divisão");
  Console.WriteLine("-------------");
  Console.WriteLine("\nQual operação deseja fazer ?");
  string option = Console.ReadLine()!;

  Calcule(option, firstNumber, secondNumber);


  double Adicao(int firstNumber, int secondNumber)
  {
    return firstNumber + secondNumber;
  }
  double Subtracao(int firstNumber, int secondNumber)
  {
    return firstNumber - secondNumber;
  }
  double Multiplicacao(int firstNumber, int secondNumber)
  {
    return firstNumber * secondNumber;
  }
  double Divisao(int firstNumber, int secondNumber)
  {
    return firstNumber / secondNumber;
  }

  void Calcule(string option, int firstNumber, int secondNumber)
  {
    double result = 0;
    switch (option)
    {
      case "adição":
        result = Adicao(firstNumber, secondNumber);
        break;
      case "subtração":
        result = Subtracao(firstNumber, secondNumber);
        break;
      case "Multiplicação":
        result = Multiplicacao(firstNumber, secondNumber);
        break;
      case "Divisão":
        result = Divisao(firstNumber, secondNumber);
        break;
      default:
        Console.WriteLine("Opção Inválida!");
        break;
    }
    RetornarResultado(option, result);
  }

  void RetornarResultado(string option, double result)
  {
    Console.WriteLine($"O resultado da {option} é de : {result}");
  }

  Console.Write("\nDeseja realizar outra operação? (s para sim / n para não): ");
  repeat = Console.ReadLine()!;

} while (repeat != "n");
Console.Write("\n------------- PROGRAMA FINALIZADO -------------");