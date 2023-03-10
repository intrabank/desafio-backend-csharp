using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using AutoMapper;

namespace APIDesafioIntrabank.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<UpdateEnderecoDTO, Endereco>();
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
        }
    }
}
