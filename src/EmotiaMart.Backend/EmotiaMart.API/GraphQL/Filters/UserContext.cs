namespace EmotiaMart.API.GraphQL.Filters;

public class UserContext
{
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}

public class UserGlobalState : GlobalStateAttribute
{
    public UserGlobalState() : base("currentUser")
    {
    }
}