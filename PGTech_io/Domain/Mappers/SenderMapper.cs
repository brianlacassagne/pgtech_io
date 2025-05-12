using AutoMapper;
using PGTech_io.DTO;
using PGTech_io.Models;

namespace PGTech_io.Mappers;

public class SenderMapper : Profile
{
    public SenderMapper()
    {
        CreateMap<Sender, SenderDTO>();
        CreateMap<SenderDTO, Sender>();
    }
}