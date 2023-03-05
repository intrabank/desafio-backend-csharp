using APIDesafioIntrabank.Model;

namespace APIDesafioIntrabank.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<APIDbContext>();

                if (!context.ClientesEmpresariais.Any() && !context.Enderecos.Any())
                {
                    context.Users.Add(new User("intrabank", "intrabank"));

                    context.Enderecos.AddRange(
                    new Endereco("Rua dos Andradas", "Porto Alegre", "RS", "Brasil"),
                    new Endereco("Avenida Paulista", "São Paulo", "SP", "Brasil"),
                    new Endereco("Rua Augusta", "Lisboa", "Lisboa", "Portugal"),
                    new Endereco("Calle Ocho", "Miami", "FL", "Estados Unidos"),
                    new Endereco("Via Condotti", "Roma", "RM", "Itália"),
                    new Endereco("Champs-Élysées", "Paris", "Île-de-France", "França"),
                    new Endereco("Broadway", "Nova York", "NY", "Estados Unidos"),
                    new Endereco("Rua das Flores", "Coimbra", "Coimbra", "Portugal"),
                    new Endereco("Orchard Road", "Singapura", "Singapura", "Singapura"),
                    new Endereco("Oxford Street", "Londres", "Inglaterra", "Reino Unido")
                );

                    context.SaveChanges();

                    context.ClientesEmpresariais.AddRange(
                        new ClienteEmpresarial("ABC Comércio Ltda", "ABC", "11.111.111/0001-01", "(51) 1234-5678", "abc@abc.com.br", 1),
                        new ClienteEmpresarial("Fictícia S.A.", "Fictícia", "22.222.222/0001-02", "(11) 9876-5432", "ficticia@ficticia.com.br", 2),
                        new ClienteEmpresarial("Empresa X Ltda", "Empresa X", "33.333.333/0001-03", "(21) 2468-1357", "empresaX@empresaX.com.br", 3),
                        new ClienteEmpresarial("Zeta Indústria e Comércio Ltda", "Zeta", "44.444.444/0001-04", "(305) 555-1212", "zeta@zeta.com.br", 4),
                        new ClienteEmpresarial("Empresa Y S.A.", "Empresa Y", "55.555.555/0001-05", "(39) 9999-9999", "empresaY@empresaY.com.br", 5),
                        new ClienteEmpresarial("Empresa W Ltda", "Empresa W", "66.666.666/0001-06", "(33) 3333-3333", "empresaW@empresaW.com.br", 6),
                        new ClienteEmpresarial("Gamma Distribuidora Ltda", "Gamma", "77.777.777/0001-07", "(212) 555-1212", "gamma@gamma.com.br", 7),
                        new ClienteEmpresarial("Empresa Z Ltda", "Empresa Z", "88.888.888/0001-08", "(239) 876-5432", "empresaZ@empresaZ.com.br", 8),
                        new ClienteEmpresarial("Alpha Serviços Ltda", "Alpha", "99.999.999/0001-09", "(65) 5555-5555", "alpha@alpha.com.br", 9),
                        new ClienteEmpresarial("Delta Comércio e Indústria Ltda", "Delta", "10.000.000/0001-10", "(44) 4444-4444", "delta@delta.com.br", 10)
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
