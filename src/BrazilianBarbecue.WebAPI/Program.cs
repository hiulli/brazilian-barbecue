using BrazilianBarbecue.Core.Model;
using BrazilianBarbecue.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IoCServiceRegister.Register(builder.Services);
builder.Services.Configure<SqlServerConfiguration>(builder.Configuration.GetSection("ConnectionStrings"));

// Create Cors Polices
var corsPolicies = "CorsPolicies";
builder.Services.AddCors(options =>
{
    options
    .AddPolicy(corsPolicies,
                  policy =>
                  {
                      policy.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                  });
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseCors(corsPolicies);

app.UseAuthorization();

app.MapControllers();

app.Run();
