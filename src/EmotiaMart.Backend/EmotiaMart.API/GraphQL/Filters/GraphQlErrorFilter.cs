namespace EmotiaMart.API.GraphQL.Filters;
public class GraphQlErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        // Log the error details (you can use any logging framework)
        Console.WriteLine($"GraphQL Error: {error.Message}");
        if (error.Exception != null)
        {
            Console.WriteLine($"Exception: {error.Exception}");
        }

        // Customize the error message sent to the client
        return error.WithMessage("An unexpected error occurred. Please try again later.");
    }
}