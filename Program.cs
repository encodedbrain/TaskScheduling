<<<<<<< HEAD
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Logging;
using TaskScheduling.Data;


=======
>>>>>>> 8579532650d2373614da0834b8b14e561adf6a9c
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
<<<<<<< HEAD

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<TaskSchedulingDb>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "Open",
        builder =>
            builder
                .SetIsOriginAllowed(_ => true)
                .WithOrigins("http://localhost:5117")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
    );
});

// solving JsonException object cycle problem
builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
IdentityModelEventSource.ShowPII = true;

=======
>>>>>>> 8579532650d2373614da0834b8b14e561adf6a9c
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD
app.UseCors("Open");

app.UseHttpsRedirection();

app.UseAuthentication();

=======
app.UseHttpsRedirection();

>>>>>>> 8579532650d2373614da0834b8b14e561adf6a9c
app.UseAuthorization();

app.MapControllers();

<<<<<<< HEAD
app.Run();
=======
app.Run();
>>>>>>> 8579532650d2373614da0834b8b14e561adf6a9c
