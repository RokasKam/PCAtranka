using PCAtranka.Core.Requests.Person;
using PCAtranka.Core.Responses;
using PCAtranka.Domain.Entities;

namespace PCAtranka.Core.Interfaces;

public interface IPersonRepository
{
    Person? GetById(Guid id);
    
    Person? GetByName(string name);
    
    int GetAmount();
    
    IEnumerable<Person> GetAll(PersonParameters personParameters);

    Person? Create(Person person);
}