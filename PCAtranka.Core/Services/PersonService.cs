using AutoMapper;
using PCAtranka.Core.Interfaces;
using PCAtranka.Core.Requests.Person;
using PCAtranka.Core.Responses;
using PCAtranka.Domain.Entities;

namespace PCAtranka.Core.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    
    public List<PersonResponse> GetAll(PersonParameters personParameters)
    {
        var persons = _personRepository.GetAll(personParameters);
        var personResponseList = persons.Select(x => _mapper.Map<PersonResponse>(x)).ToList();

        return personResponseList;
    }

    public int GetAmount()
    {
        return _personRepository.GetAmount();
    }

    public PersonResponse? GetById(Guid id)
    {
        var person = _personRepository.GetById(id);
        var personResponse = _mapper.Map<PersonResponse>(person);

        return personResponse;
    }

    public PersonResponse? Create(CreatePersonRequest person)
    {
        var requestPerson = _mapper.Map<Person>(person);
        if (_personRepository.GetByName(person.NameSurname) != null)
        {
            return null;
        }
        var createdPerson = _personRepository.Create(requestPerson);
        var response = _mapper.Map<PersonResponse>(createdPerson);
        return response;
    }
}