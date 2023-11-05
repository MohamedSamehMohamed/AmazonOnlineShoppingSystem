using System.Text;
using Application;
using Application.Common.Interfaces;
using Application.Data;
using Application.Data.MockRepositories;
using Application.Products.Create;
using Application.Services.Authentication;
using Application.Services.IdentityAuthentication;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);
// add the database context 
builder.Services.AddDbContext<ApplicationContext>(
    options=>
        options.
            UseSqlServer(
                builder.Configuration.GetConnectionString("DataBaseConnection")!)
    );


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options=>
    {
        options.Password.RequireDigit = false;
    }
    ).AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

// add mediator Handlers 
builder.Services.AddMediatR
    (cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));

// add dependency injections 
builder.Services.AddScoped<IUnitOfWork, MockUnitOfwork>();
builder.Services.AddScoped<IIdentityAuthentication, IdentityAuthentication>();
builder.Services.
    AddAuthentication(
        auth=>
        {
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).
    AddJwtBearer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();