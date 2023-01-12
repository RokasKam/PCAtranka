using PCAtranka.Core.Interfaces;
using PCAtranka.Core.Requests.Person;
using PCAtranka.Core.Responses;
using PCAtranka.Domain.Entities;
using PCAtranka.Infrastructure.Data;

namespace PCAtranka.Infrastructure.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly PCAtrankaDbContext _dbContext;

    public PersonRepository(PCAtrankaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Person? GetById(Guid id)
    {
        var person = _dbContext.Persons.FirstOrDefault(x => x.Id == id);

        return person;
    }

    public Person? GetByName(string name)
    {
        var person = _dbContext.Persons.FirstOrDefault(x => x.NameSurname == name);

        return person;
    }

    public int GetAmount()
    {
        return _dbContext.Persons.Count();
    }

    public IEnumerable<Person> GetAll(PersonParameters personParameters)
    {
        var query = _dbContext.Persons.AsQueryable();
        if (!string.IsNullOrEmpty(personParameters.IdFilter))
        {
            query = query.Where(x => x.Id.ToString().ToLower().Contains(personParameters.IdFilter.ToLower()));
        }
        if (!string.IsNullOrEmpty(personParameters.NameFilter))
        {
            query = query.Where(x => x.NameSurname.ToLower().Contains(personParameters.NameFilter.ToLower()));
        }
        if (!string.IsNullOrEmpty(personParameters.AgeFilter))
        {
            query = query.Where(x => x.Age.ToString().ToLower().Contains(personParameters.AgeFilter.ToLower()));
        }
        if (!string.IsNullOrEmpty(personParameters.HeightFilter))
        {
            query = query.Where(x => x.Hight.ToString().ToLower().Contains(personParameters.HeightFilter.ToLower()));
        }

        if (personParameters.IsDescending && !string.IsNullOrEmpty(personParameters.SortingField))
        {
            switch (personParameters.SortingField)
            {
                case "name":
                    query = query.OrderByDescending(x => x.NameSurname);
                    break;
                case "height":
                    query = query.OrderByDescending(x => x.Hight);
                    break;
                case "age":
                    query = query.OrderByDescending(x => x.Age);
                    break;
                default:
                    query = query.OrderByDescending(x => x.Id);
                    break;
            }
        }
        else if (!personParameters.IsDescending && !string.IsNullOrEmpty(personParameters.SortingField))
        {
            switch (personParameters.SortingField)
            {
                case "name":
                    query = query.OrderBy(x => x.NameSurname);
                    break;
                case "height":
                    query = query.OrderBy(x => x.Hight);
                    break;
                case "age":
                    query = query.OrderBy(x => x.Age);
                    break;
                default:
                    query = query.OrderBy(x => x.Id);
                    break;
            }
        }

        return query.Skip((personParameters.PageNumber - 1) * personParameters.PageSize)
            .Take(personParameters.PageSize).ToList();
    }

    public Person? Create(Person person)
    {
        person.Id = Guid.NewGuid();
        _dbContext.Persons.Add(person);
        _dbContext.SaveChanges();

        return person;
    }
}