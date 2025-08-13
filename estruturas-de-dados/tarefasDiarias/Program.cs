string[] tarefas = new string[5];
int indice = 0;

void Push(string tarefa)
{
  if (indice < 5)
  {
    tarefas[indice] = tarefa;
    indice++;
    Console.WriteLine(tarefa + " foi adicionada!");
  }
  else
  {
    Console.WriteLine("=== Não é possivel adicionar, a pilha está LOTADA! ===\n");
  }
}

void Pop()
{
  if (indice > 0)
  {
    indice--;
    Console.WriteLine(tarefas[indice] + " foi removida ou concluida!");
    tarefas[indice] = null;
  }
  else
  {
    Console.WriteLine("=== A pilha está VAZIA! ===\n");
  }
}

Push("Tomar um banho");
Push("Ir para a academia");
Push("Passear com o cachorro");
Push("Abrir E-mail");
Push("Escovar os dentes");


Push("Reunião com o chefe"); // lotada

Pop();
Pop();
Pop();
Pop();
Pop();

Pop(); // vazia


