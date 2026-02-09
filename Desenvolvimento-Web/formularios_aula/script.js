function enviarInformacoes() {
  var nome = document.getElementById("nome").value;
  var idade = document.getElementById("idade").value;
  var email = document.getElementById("email").value;

  document.getElementById("nomeExibicao").innerHTML = nome;
  document.getElementById("idadeExibicao").innerHTML = idade;
  document.getElementById("emailExibicao").innerHTML = email;

}