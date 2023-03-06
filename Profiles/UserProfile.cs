using APIDesafioIntrabank.Dto;
using APIDesafioIntrabank.Model;
using AutoMapper;

namespace APIDesafioIntrabank.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
