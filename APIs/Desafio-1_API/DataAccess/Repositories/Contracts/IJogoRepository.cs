using Dominio;
using System.Collections.Generic;

public interface IJogoRepository
{
  // CREATE
  int CreateJogo(Jogo jogo);

  // READ
  IEnumerable<Jogo> Listar();
  Jogo GetJogoByID(int jogoId);

  // UPDATE
  void UpdateJogo(Jogo jogo);

  // DELETE
  void DeleteJogo(int jogoId);

  // AÇÕES ESPECÍFICAS
  void UpdateJogoToAlugado(int jogoId);
  void UpdateJogoToDisponivel(int jogoId);
}
