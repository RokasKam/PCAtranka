using AutoMapper;
using PCAtranka.Core.Requests.Person;
using PCAtranka.Core.Responses;
using PCAtranka.Domain.Entities;

namespace PCAtranka.Core.Mappings;

public class PersonMappingProfile : Profile
{
    public PersonMappingProfile()
    {
        CreateMap<CreatePersonRequest, Person>();
        CreateMap<Person, PersonResponse>();
    }
}