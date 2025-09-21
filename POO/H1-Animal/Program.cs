var primeiroAnimal = new Animal("Pedrinho", 10);
var segundoAnimal = new Cachorro("Livinho", 12);



Console.Write($"\n{primeiroAnimal.Nome} | {primeiroAnimal.Idade}\n");
primeiroAnimal.EmitirSom();
Console.Write($"\n{segundoAnimal.Nome} | {segundoAnimal.Idade}\n");
segundoAnimal.EmitirSom();