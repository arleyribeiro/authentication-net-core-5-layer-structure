using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
namespace Core.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}