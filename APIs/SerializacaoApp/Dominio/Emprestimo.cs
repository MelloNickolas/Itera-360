namespace dominio
{
  public class Emprestimo
  {
    public int IDEmprestimo { get; set; }

    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucaoPrevista { get; set; }

    // Quando o item for devolvido, você pode preencher essa data
    public DateTime? DataDevolucaoReal { get; set; }

    // Relação via IDs (perfeito para JSON simples)
    public int IDUsuario { get; set; }
    public int IDItem { get; set; }

    public bool Devolvido { get; set; } = false;
  }
}
