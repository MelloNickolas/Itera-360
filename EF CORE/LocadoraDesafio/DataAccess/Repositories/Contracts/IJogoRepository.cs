using Dominio;

public interface IJogoRepository
{
  int CreateJogo(Jogo jogo);
  void UpdateJogo(Jogo jogo);
  Jogo GetJogoByID(int idJogo);
  void DeleteJogoByID(int idJogo);
}