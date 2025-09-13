using EmotiaMart.Infrastructure;
using EmotiaMart.Application;
using EmotiaMart.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EmotiaMart.API.GraphQL.Queries;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);
static void UpdateDatabase(IApplicationBuilder app)
{
    using var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();

    using var context = serviceScope.ServiceProvider
        .GetService<AppDbContext>()
        ?? throw new Exception("LTRCDataContext service not found");

    context.Database.Migrate();
}
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:2029", "http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = System.IO.Path.Combine(builder.Environment.ContentRootPath, "..", "..", "Web-Spa", "dist", "web-spa", "browser");
});

var app = builder.Build();
UpdateDatabase(app);
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.MapGraphQL("/graphql");

app.UseSpaStaticFiles();
app.UseSpa(spa =>
{
    spa.Options.SourcePath = System.IO.Path.Combine("..", "..", "Web-Spa");
});

app.Run();
