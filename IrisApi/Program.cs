using Iris.Domain.Options;
using Iris.Infraestructure.Context;
using Iris.Infraestructure.Extensions;
using IrisApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(AppExceptionFilter));
    options.Filters.Add(new AuthorizeFilter());
});
builder.Services.Configure<AuthOptions>(options => config.GetSection("AuthOptions").Bind(options));
builder.Services.Configure<JWTOptions>(options => config.GetSection("JWTOptions").Bind(options));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title="ToDoApi",Version="v1"});
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Inserte el token JWT en este formato: Bearer {token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
         {
             new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
             Array.Empty<string>()
         }
     });
});
builder.Services.AddDbContext<IrisContext>(
    (serviceProvider,options) =>
    {
        options.UseInMemoryDatabase("IrisDB");
    }, ServiceLifetime.Scoped);
var jwtOptions = builder.Configuration.GetSection("JWTOptions").Get<JWTOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddPersistence().AddServices();

builder.Services.AddAutoMapper(Assembly.Load("Iris.Application"));
builder.Services.AddMediatR(mtr => { mtr.RegisterServicesFromAssemblies(Assembly.Load("Iris.Application")); });

var app = builder.Build();
app.UseCors("AllowAllOrigins");

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
