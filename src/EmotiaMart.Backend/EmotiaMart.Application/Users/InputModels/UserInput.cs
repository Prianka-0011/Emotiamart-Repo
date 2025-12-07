using HotChocolate;
namespace EmotiaMart.Application.Users.InputModels;
public class UserInput
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}