
using HotChocolate;
namespace EmotiaMart.Application.Users.InputModels;

public class LoginInput
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}