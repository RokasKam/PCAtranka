namespace PCAtranka.Domain.Entities;

public class Person : BaseEntity
{
    public string? NameSurname { get; set; }
    public double Hight { get; set; }
    public int Age { get; set; }
    public string? Description { get; set; }
}