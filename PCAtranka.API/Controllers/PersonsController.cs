using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCAtranka.Core.Interfaces;
using PCAtranka.Core.Requests.Person;

namespace PCAtranka.API.Controllers;

public class PersonsController : BaseController
{
    private readonly IPersonService _personService;
    
    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }
    
    [HttpGet]
    public IActionResult GetAll([FromQuery] PersonParameters personParameters)
    {
        var persons = _personService.GetAll(personParameters);
        var metadata = new
        {
            TotalPages = (int)Math.Ceiling(_personService.GetAmount() / (double)personParameters.PageSize)
        };
        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(persons);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_personService.GetById(id));
    }

    [HttpPost]
    public IActionResult Create(CreatePersonRequest request)
    {
        var person = _personService.Create(request);
        if (person is null)
        {
            return BadRequest("Person with this name exist");
        }
        return Ok(_personService.Create(request));
    }
}