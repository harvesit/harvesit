namespace Harvesit.AdministratorServices.Api.Endpoints;

public abstract class EndpointBase
{
    public static async Task<IResult> ExecuteWithExceptionHandling(Func<Task<IResult>> func)
    {
        try
        {
            return await func();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
