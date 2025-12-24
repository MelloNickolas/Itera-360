using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Services;


class Program
{
  static async Task Main()
  {
    Console.WriteLine("=== Chatbot Console com Groq ===\n");

    // 1️⃣ Solicita a API Key do usuário
    Console.Write("Informe sua GROQ API KEY: ");
    string apiKey = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(apiKey))
    {
      Console.WriteLine("API Key inválida.");
      return;
    }

    // 2️⃣ Menu de escolha do tipo de assistente
    Console.WriteLine("\nEscolha o tipo de assistente:");
    Console.WriteLine("1 - Assistente Geral (Português)");
    Console.WriteLine("2 - Assistente de Programação");
    Console.WriteLine("3 - Assistente de Inglês");
    Console.WriteLine("4 - Assistente de Organização Pessoal");
    Console.WriteLine("5 - Assistente de Videogames");

    Console.Write("\nOpção: ");
    string opcao = Console.ReadLine() ?? "";

    string systemMessage = opcao switch
    {
      "1" => "Você é um assistente amigável que responde perguntas gerais em português com clareza e objetividade.",
      "2" => "Você é um assistente de programação para iniciantes, explicando conceitos de forma simples e com exemplos.",
      "3" => "Você é um assistente de inglês que ajuda com vocabulário, frases e gramática básica.",
      "4" => "Você é um assistente de organização pessoal que ajuda a planejar tarefas e rotinas.",
      "5" => "Você é um assistente especialista em videogames, jogos, consoles e lançamentos.",
      _ => "Você é um assistente educacional que responde de forma clara e objetiva."
    };

    // 3️⃣ Cria o serviço da Groq
    var groqService = new GroqService(apiKey);

    // 4️⃣ Lista de mensagens (histórico do chat)
    var mensagens = new List<Message>
    {
      new Message
      {
        role = "system",
        content = systemMessage
      }
    };

    Console.WriteLine("\nDigite sua pergunta (ou 'sair' para encerrar):\n");

    // 5️⃣ Loop principal do chat
    while (true)
    {
      Console.Write("Você: ");
      string pergunta = Console.ReadLine() ?? "";

      if (string.IsNullOrWhiteSpace(pergunta))
        continue;

      if (pergunta.Trim().Equals("sair", StringComparison.OrdinalIgnoreCase))
        break;

      // Adiciona mensagem do usuário
      mensagens.Add(new Message
      {
        role = "user",
        content = pergunta
      });

      // Envia para a API
      string resposta = await groqService.EnviarAsync(mensagens);

      Console.WriteLine($"\nIA: {resposta}\n");

      // Adiciona resposta da IA ao histórico
      mensagens.Add(new Message
      {
        role = "assistant",
        content = resposta
      });
    }

    Console.WriteLine("\nChat encerrado. Até mais!");
  }
}
