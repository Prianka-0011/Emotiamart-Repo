using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace EmotiaMart.Domain.Entities;
public class User : IAuditable
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    public string PasswordHash { get; set; } = null!;

    [ForeignKey("BillingAddress")]
    public Guid? BillingAddressId { get; set; }
    public Address? BillingAddress { get; set; }
    [ForeignKey("ShippingAddress")]
    public Guid? ShippingAddressId { get; set; }
    public Address? ShippingAddress { get; set; } 
    public bool IsActive { get; set; } = true;

    // Audit fields
    public DateTime CreatedDate { get; set; }
    public Guid CreatedById { get; set; }                      
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedById { get; set; }
}