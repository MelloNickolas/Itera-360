var usuario = new Usuario("Nick", "1234");
var admin = new Administrador("Ana", "admin123");

Console.WriteLine($"Usuário autenticado? {usuario.Autenticar("1234")}");
Console.WriteLine($"Administrador autenticado? {admin.Autenticar("errada")}");