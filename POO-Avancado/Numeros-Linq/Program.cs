List<int> numeros = new List<int> { 5, 7, 2, 8, 6, 3, 10, 15, 18, 12, 17, 14 };

var numerosPares = numeros.Where(n => n % 2 == 0);
foreach (var numeroPar in numerosPares)
{
  Console.WriteLine($"Numero PAR - {numeroPar}");
}
Console.WriteLine();

var numerosImpares = numeros.Where(n => n % 2 != 0);
foreach (var numeroImpar in numerosImpares)
{
  Console.WriteLine($"Numero IMPAR - {numeroImpar}");
}
Console.WriteLine();

var numerosMaiorque10 = numeros.Where(n => n > 10);
foreach (var numeroMaiorque10 in numerosMaiorque10)
{
  Console.WriteLine($"Numero MAIOR QUE 10 - {numeroMaiorque10}");
}
Console.WriteLine();

var mediaNumeros = numeros.Average();
Console.WriteLine($"A média dos números é: {mediaNumeros}");
Console.WriteLine();

var primeiroNumero = numeros.FirstOrDefault();
Console.WriteLine($"O primeiro número é: {primeiroNumero}");
Console.WriteLine();

var ultimoNumero = numeros.LastOrDefault();
Console.WriteLine($"O ultimo número é: {ultimoNumero}");
Console.WriteLine();

var somaNumerosMaiorque10 = numerosMaiorque10.Sum();
Console.WriteLine($"A soma dos números maior que 10 é: {somaNumerosMaiorque10}");