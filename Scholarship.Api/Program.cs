using Scholarship.Application.Interfaces;
using Scholarship.Application.Services;
using Scholarship.Domain.Interfaces;
using Scholarship.Infrastructure.Persistence;
using Scholarship.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Jose;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using Scholarship.Infrastructure.Repositories.ProfileRepository;
using Microsoft.Exchange.WebServices.Data;
using AutoMapper;
using Scholarship.Application.AutoMapper;
using System.Text.Json.Serialization;
using Microsoft.Graph.Models;
using System;
using Microsoft.AspNetCore.Mvc;




var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot" // Or any custom folder
});
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IBiodataRepository, BiodataRepository>();
builder.Services.AddScoped<IParentInfoRepository, ParentInfoRepository>();
builder.Services.AddScoped<IParentInfoService, ParentInfoService>();
builder.Services.AddScoped<ILogoutService, LogoutService>();


builder.Services.AddScoped<GenerateJwtToken>();
builder.Services.AddScoped<ProfileService>();
builder.Services.AddScoped<ParentInfoService>();
builder.Services.AddScoped<LogoutService>();

//builder.WebHost.UseWebRoot("wwwroot");

builder.Services.AddScoped<ICertificateService>(provider =>
{
    var context = provider.GetRequiredService<ApplicationDbContext>();
    var env = provider.GetRequiredService<IWebHostEnvironment>();
    return new CertificateService(context, env.WebRootPath);
});

builder.Services.AddSingleton(provider =>
{
    var env = provider.GetRequiredService<IWebHostEnvironment>();
    return env.WebRootPath;
});


//builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();




JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();



    #region Add Authentication
    builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    
    options.SaveToken = false;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],

        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
    };
});

#endregion


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Scholarship API", Version = "v1" });

    c.UseInlineDefinitionsForEnums();
    // Add JWT Authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid JWT token.\n\nExample: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6..."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

 builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, RegistrationService>();


builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseMiddleware<Scholarship.Api.Middleware.ExceptionHandlingMiddleware>();
# region Config CORS
app.UseCors();
#endregion




app.UseAuthentication();

app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Needed to serve uploaded files


app.MapControllers();
app
    .MapGroup("/api");
    app.MapIdentityApi<IdentityUser>();



app.MapPost("/api/signup", async (
    UserManager<IdentityUser> userManager,
    [FromBody] UserRegistrationModel userRegistrationModel
    ) =>
  {
    IdentityUser user = new IdentityUser()
    {
        UserName = userRegistrationModel.Email,
        Email = userRegistrationModel.Email,
       // FullName = userRegistrationModel.FullName,
    };
    var result = await userManager.CreateAsync(
        user,
        userRegistrationModel.Password);

    if (result.Succeeded)
        return Results.Ok(result);
    else
        return Results.BadRequest(result);
   });

app.Run();
 
public class UserRegistrationModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}
