namespace PCAtranka.Core.Responses;

public class PersonResponse
{
    public Guid Id { get; set; }
    public string? NameSurname { get; set; }
    public double Hight { get; set; }
    public int Age { get; set; }
    public string? Description { get; set; }
}