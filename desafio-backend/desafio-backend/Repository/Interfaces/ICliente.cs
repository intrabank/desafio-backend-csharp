using desafio_backend.Models;

namespace desafio_backend.Repository.Interface
{
    public interface ICliente
    {
        Task<List<ClienteEmpresarialModel>> BuscarTodosClientes();
        Task<ClienteEmpresarialModel> BuscarPorId(int id);
        Task<ClienteEmpresarialModel> BuscarPorCnpj(string cnpj);
        Task<ClienteEmpresarialModel> Adicionar(ClienteEmpresarialModel cliente);
        Task<ClienteEmpresarialModel> Atualizar(ClienteEmpresarialModel cliente, int id);
        Task<bool> Apagar(int id);
    }
}
