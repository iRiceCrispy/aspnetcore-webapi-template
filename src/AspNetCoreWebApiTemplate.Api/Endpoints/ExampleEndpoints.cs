namespace AspNetCoreWebApiTemplate.Api.Endpoints;

public class ExampleEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello, World!");
    }
}
