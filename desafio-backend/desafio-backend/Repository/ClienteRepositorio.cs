using desafio_backend.Data;
using desafio_backend.Models;
using desafio_backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace desafio_backend.Repository
{
    public class ClienteRepositorio : ICliente
    {
        private readonly SistemaClientesDbContext _dbContext;
        public ClienteRepositorio(SistemaClientesDbContext sistemaClientesDbContext)
        {
            _dbContext = sistemaClientesDbContext;
        }

        public async Task<ClienteEmpresarialModel> BuscarPorId(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ClienteEmpresarialModel>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<ClienteEmpresarialModel> Adicionar(ClienteEmpresarialModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<ClienteEmpresarialModel> Atualizar(ClienteEmpresarialModel cliente, int id)
        {
            ClienteEmpresarialModel clientePorId = await BuscarPorId(id);

            if(clientePorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.RazaoSocial = cliente.RazaoSocial;
            clientePorId.Endereco = cliente.Endereco;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteEmpresarialModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }

            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }



    }
}
