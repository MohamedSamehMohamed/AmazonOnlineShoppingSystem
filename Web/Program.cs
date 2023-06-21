using System.Reflection;
using Application.Data;
using Application.Data.Repositories;
using Application.Products.Create;
using Domain.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers().AddApplicationPart(presentationAssembly);

// add mediator Handlers 
builder.Services.AddMediatR
    (cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));

// add dependency injections 
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();