using Dominio;

public interface IAluguelRepository
{
  int CreateAluguel(Aluguel aluguel);
  void UpdateAluguel(Aluguel aluguel);
  Aluguel GetAluguelByID(int idAluguel);
  void DeleteAluguelByID(int idAluguel);
}