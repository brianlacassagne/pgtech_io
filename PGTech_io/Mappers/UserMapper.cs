using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PGTech_io.DTO;

namespace PGTech_io.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserDTO, IdentityUser>();
        CreateMap<IdentityUser, UserDTO>();
    }
}