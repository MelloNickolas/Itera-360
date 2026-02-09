function calcularIMC(event) {
  event.preventDefault(); // impede o reload da pagina inteira
  console.log("Calculando IMC...");

  var peso = document.getElementById("peso").value;
  peso = peso.replace(",", ".");
  peso = Number(peso);
  // Fiz isso pq no brasil é comum colocar , em casas decimais!

  var altura = document.getElementById("altura").value;
  altura = altura / 100; //  Tratando para metros

  var IMC = peso / (altura * altura);


  var classificacao = "";
  if (IMC < 18.5) {
    classificacao = "Abaixo do peso";
  } else if (IMC < 24.9) {
    classificacao = "Peso normal";
  } else if (IMC < 29.9) {
    classificacao = "Sobrepeso";
  } else if (IMC < 34.9) {
    classificacao = "Obesidade I";
  } else if (IMC < 39.9) {
    classificacao = "Obesidade II";
  } else {
    classificacao = "Obesidade III";
  }

  document.getElementById("classificacao").innerHTML = classificacao;

}