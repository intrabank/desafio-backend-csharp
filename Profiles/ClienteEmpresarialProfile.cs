using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using AutoMapper;

namespace APIDesafioIntrabank.Profiles
{
    public class ClienteEmpresarialProfile : Profile
    {
        public ClienteEmpresarialProfile()
        {
            CreateMap<CreateClienteDTO, ClienteEmpresarial>();
            CreateMap<UpdateClienteDTO, ClienteEmpresarial>();
            CreateMap<ClienteEmpresarial, ReadClienteDTO>().ForMember(clienteDto => clienteDto.Endereco,
                opt => opt.MapFrom(cliente => cliente.Endereco));
        }
    }
}
