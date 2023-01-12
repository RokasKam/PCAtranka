using System.ComponentModel.DataAnnotations;

namespace PCAtranka.Core.Requests.Person;

public class CreatePersonRequest
{
    [Required]
    public string? NameSurname { get; set; }
    [Required]
    [Range(0, 3)]
    public double Hight { get; set; }
    [Required]
    [Range(0, 150)]
    public int Age { get; set; }
    [Required]
    public string? Description { get; set; }
}