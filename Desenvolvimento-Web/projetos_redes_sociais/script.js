function abrirWhatsApp() {
  var resposta = confirm("Deseja realmente abrir o WhatsApp?");

  if (resposta) {
    window.open("https://wa.me/", "_blank");
  }
}