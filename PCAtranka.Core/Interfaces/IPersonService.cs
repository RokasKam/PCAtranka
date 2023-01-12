using PCAtranka.Core.Requests.Person;
using PCAtranka.Core.Responses;

namespace PCAtranka.Core.Interfaces;

public interface IPersonService
{
    List<PersonResponse> GetAll(PersonParameters personParameters);

    int GetAmount();

    PersonResponse? GetById(Guid id);

    PersonResponse? Create(CreatePersonRequest person);
}