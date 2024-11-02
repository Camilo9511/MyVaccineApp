using Microsoft.EntityFrameworkCore;
using GrpcService1.Services;
using GrpcService1;
using GrpcService1.Configurations;

var builder = WebApplication.CreateBuilder(args);
// Add servicesvar builder = WebApplication.CreateBuilder(args); to the container.
builder.Services.AddControllers();



builder.Services.AddDbContext<MyVaccineAppDbContext>(options =>
options.UseSqlServer("Server=localhost,1433;Database=MyVaccineAppDb;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SetMyVaccineAuthConfiguration();

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Set this to serve the Swagger UI at the app's root
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();