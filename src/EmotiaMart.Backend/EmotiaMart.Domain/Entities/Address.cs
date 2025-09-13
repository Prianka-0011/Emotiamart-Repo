
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace EmotiaMart.Domain.Entities;

public class Address : IAuditable
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(200)]
    public string Street { get; set; } = null!;

    [Required, MaxLength(100)]
    public string City { get; set; } = null!;

    [Required, MaxLength(100)]
    public string State { get; set; } = null!;

    [Required, MaxLength(20)]
    public string PostalCode { get; set; } = null!;

    [Required, MaxLength(100)]
    public string Country { get; set; } = null!;

    public bool IsDefault { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public Guid CreatedById { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedById { get; set; }
}