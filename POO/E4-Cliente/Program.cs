var primerioCliente = new Cliente("Nickolas", "Macatuba, Rua Uruguai", "(14)997091709");

Console.WriteLine($"{primerioCliente.Nome} | {primerioCliente.Endereco} | {primerioCliente.Telefone}");

primerioCliente.SetTelefone("(14)998161131");

Console.WriteLine($"{primerioCliente.Nome} | {primerioCliente.Endereco} | {primerioCliente.Telefone}");
