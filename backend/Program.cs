
using Microsoft.EntityFrameworkCore;
using backend.Services;
using backend.Services.Students;
using backend.Schema;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Encrypt=True;TrustServerCertificate=True;";
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddScoped<StudentsRepository>();
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

using (IServiceScope scope = app.Services.CreateScope())
{
    IDbContextFactory<SchoolDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDbContext>>();
    using (SchoolDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

app.MapGet("/", () => "Hello World!");

app.Run();
