using System.ComponentModel.DataAnnotations.Schema;

namespace PCAtranka.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreationDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime ModificationDate { get; }
}