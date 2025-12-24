using Microsoft.AspNetCore.Mvc;
using Dominio;

[Route("api/[controller]")]
[ApiController] //Attribute, um metadado avisando para o Dotnet que é uma API

public class JogoController : Controller
{
  private readonly IJogoRepository _jogos;

  public JogoController(IJogoRepository jogos)
  {
    _jogos = jogos;
  }

  [HttpGet]
  public IActionResult GetAllJogos()
  {
    return Ok(_jogos.Listar());
  }

  [HttpGet("{IDJogo}")]
  public IActionResult GetJogoByID([FromRoute] int IDJogo)
  {
    var jogo = _jogos.GetJogoByID(IDJogo);

    if (jogo == null)
      return NotFound();

    return Ok(jogo);
  }


  [HttpPost]
  public IActionResult PostJogo([FromBody] Jogo jogo)
  {
    // Antes: jogo.IDJogo = _jogos.Count() + 1;
    // Agora: o banco gera o ID
    jogo.IDJogo = _jogos.CreateJogo(jogo);

    // Antes: _jogos.Add(jogo);
    // Agora: já foi salvo no banco

    // Mesmo retorno simples que você usava
    return Ok(new Jogo { IDJogo = jogo.IDJogo });
  }



  [HttpPut("{IDJogo}")]
  public IActionResult UpdateJogo([FromRoute] int IDJogo, [FromBody] Jogo jogo)
  {
    var jogoExistente = _jogos.GetJogoByID(IDJogo);
    if (jogoExistente == null)
      return NotFound();

    jogo.IDJogo = IDJogo; // garante que atualiza o certo
    _jogos.UpdateJogo(jogo);

    return NoContent();
  }

  [HttpPut("{IDJogo}/Alugar")]
  public IActionResult UpdateJogoToAlugado([FromRoute] int IDJogo)
  {
    var jogoExistente = _jogos.GetJogoByID(IDJogo);
    if (jogoExistente == null)
      return NotFound();

    if (jogoExistente.Alugado)
      return BadRequest("O Jogo já está ALUGADO!");

    _jogos.UpdateJogoToAlugado(IDJogo);
    return NoContent();
  }

  [HttpPut("{IDJogo}/Devolver")]
  public IActionResult UpdateJogoToDisponivel([FromRoute] int IDJogo)
  {
    var jogoExistente = _jogos.GetJogoByID(IDJogo);
    if (jogoExistente == null)
      return NotFound();

    if (!jogoExistente.Alugado)
      return BadRequest("O Jogo já está DISPONIVEL!");

    _jogos.UpdateJogoToDisponivel(IDJogo);
    return NoContent();
  }


  [HttpDelete("{IDJogo}")]
  public IActionResult DeleteJogo([FromRoute] int IDJogo)
  {
    var jogoExistente = _jogos.GetJogoByID(IDJogo);
    if (jogoExistente == null)
      return NotFound();

    _jogos.DeleteJogo(IDJogo);
    return NoContent();
  }
}