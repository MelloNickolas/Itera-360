// 1* ano de uso = 3 anos de uso intensivo
// 2* ano de uso = 2 anos de uso intensivo

// Se eu usar o equipamento durante 2 anos vou ter usado ele como se fosse 5 anos de uso intensivo

// 3* ano de uso = 1 ano de uso intensivo
// 4* ano de uso = 1 ano de uso intensivo
// 5* ano de uso = 1 ano de uso intensivo

// se eu usar 5 anos = 8 anos de uso intensivo

int calcularVidaUtil(int idadeEquipamento)
{
  if (idadeEquipamento == 1)
  {
    return 3;
  }
  else if (idadeEquipamento == 2)
  {
    return 3 + 2; // 3 do primeiro ano e 2 do segundo
  }
  else
  {
    return 3 + 2 + (idadeEquipamento - 2);
    // como os dois primeiros anos diferentes, os subsequente vao vale como 1, entao se for 5 anos
    // 3 vao valer 1, 5 - 2 = 3, entendeu a lógica?
  }
}

Console.WriteLine("Qual o nome do euqipamento ? ");
string nomeEquipamento = Console.ReadLine()!;

Console.WriteLine($"Qual o idade da {nomeEquipamento} ? ");
int idadeEquipamento = int.Parse(Console.ReadLine()!);

int vidaUtil = calcularVidaUtil(idadeEquipamento);

Console.WriteLine($"O equipamento {nomeEquipamento} tem aproximadamente {vidaUtil} anos de uso intensivo.");