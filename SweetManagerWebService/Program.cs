using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.IAM.Application.Internal.CommandServices.Assignments;
using SweetManagerWebService.IAM.Application.Internal.CommandServices.Credential;
using SweetManagerWebService.IAM.Application.Internal.CommandServices.Roles;
using SweetManagerWebService.IAM.Application.Internal.CommandServices.User;
using SweetManagerWebService.IAM.Application.Internal.OutboundServices;
using SweetManagerWebService.IAM.Application.Internal.QueryServices.Assignments;
using SweetManagerWebService.IAM.Application.Internal.QueryServices.Credential;
using SweetManagerWebService.IAM.Application.Internal.QueryServices.Roles;
using SweetManagerWebService.IAM.Application.Internal.QueryServices.User;
using SweetManagerWebService.IAM.Domain.Repositories.Assignments;
using SweetManagerWebService.IAM.Domain.Repositories.Credential;
using SweetManagerWebService.IAM.Domain.Repositories.Roles;
using SweetManagerWebService.IAM.Domain.Repositories.Users;
using SweetManagerWebService.IAM.Domain.Services.Assignments;
using SweetManagerWebService.IAM.Domain.Services.Credential.Admin;
using SweetManagerWebService.IAM.Domain.Services.Credential.Owner;
using SweetManagerWebService.IAM.Domain.Services.Credential.Worker;
using SweetManagerWebService.IAM.Domain.Services.Roles;
using SweetManagerWebService.IAM.Domain.Services.Users.Admin;
using SweetManagerWebService.IAM.Domain.Services.Users.Owner;
using SweetManagerWebService.IAM.Domain.Services.Users.Worker;
using SweetManagerWebService.IAM.Infrastructure.Hashing.Argon2Id.Services;
using SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Assignment;
using SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Credential;
using SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;
using SweetManagerWebService.IAM.Infrastructure.Persistence.EFC.Repositories.User;
using SweetManagerWebService.IAM.Infrastructure.Population.Roles;
using SweetManagerWebService.IAM.Infrastructure.Tokens.JWT.Configuration;
using SweetManagerWebService.IAM.Infrastructure.Tokens.JWT.Services;
using SweetManagerWebService.Shared.Infrastructure.Interfaces.ASP.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerWebService.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#region Database Configuration
// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("SweetManager");

var connectionStringFromEnvironment = Environment.GetEnvironmentVariable("SweetManagerDbConnection");

if (connectionStringFromEnvironment != null)
{
    connectionString = connectionStringFromEnvironment;
}

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<SweetManagerContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

#endregion

#region OPENAPI Configuration
// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Sweet Manager API",
                Version = "v1",
                Description = "Sweet Manager API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Sweet Manager Studios",
                    Email = "contact@swm.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    } 
                }, 
                Array.Empty<string>()
            }
        });
    });

#endregion

#region Dependency Injection
builder.Services.AddScoped<IAdminCommandService, AdminCommandService>();
builder.Services.AddScoped<IAdminQueryService, AdminQueryService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<IOwnerCommandService, OwnerCommandService>();
builder.Services.AddScoped<IOwnerQueryService, OwnerQueryService>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

builder.Services.AddScoped<IWorkerCommandService, WorkerCommandService>();
builder.Services.AddScoped<IWorkerQueryService, WorkerQueryService>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

builder.Services.AddScoped<IAdminCredentialCommandService, AdminCredentialCommandService>();
builder.Services.AddScoped<IAdminCredentialQueryService, AdminCredentialQueryService>();
builder.Services.AddScoped<IAdminCredentialRepository, AdminCredentialRepository>();

builder.Services.AddScoped<IOwnerCredentialCommandService, OwnerCredentialCommandService>();
builder.Services.AddScoped<IOwnerCredentialQueryService, OwnerCredentialQueryService>();
builder.Services.AddScoped<IOwnerCredentialRepository, OwnerCredentialRepository>();

builder.Services.AddScoped<IWorkerCredentialCommandService, WorkerCredentialCommandService>();
builder.Services.AddScoped<IWorkerCredentialQueryService, WorkerCredentialQueryService>();
builder.Services.AddScoped<IWorkerCredentialRepository, WorkerCredentialRepository>();

builder.Services.AddScoped<IRoleCommandService, RoleCommandService>();
builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IWorkerAreaCommandService, WorkerAreaCommandService>();
builder.Services.AddScoped<IWorkerAreaQueryService, WorkerAreaQueryService>();
builder.Services.AddScoped<IWorkerAreaRepository, WorkerAreaRepository>();

builder.Services.AddScoped<IAssignmentWorkerCommandService, AssignmentWorkerCommandService>();
builder.Services.AddScoped<IAssignmentWorkerQueryService, AssignmentWorkerQueryService>();
builder.Services.AddScoped<IAssignmentWorkerRepository, AssignmentWorkerRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<RolesInitializer>();
#endregion 

#region JWT Configuration

var tokenSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.Configure<TokenSettings>(tokenSettings);

var secretKey = tokenSettings["SecretKey"];

var audience = tokenSettings["Audience"];

var issuer = tokenSettings["Issuer"];

var securityKey = !string.IsNullOrEmpty(secretKey)
    ? new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey))
    : throw new ArgumentException("Secret key is null or empty");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = securityKey,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<IHashingService, HashingService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddTransient<TokenValidationHandler>();

builder.Services.AddAuthorization();

#endregion

var app = builder.Build();

#region Ensure Database Created (COMPILE AppDbContext)
// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SweetManagerContext>();
    context.Database.EnsureCreated();
}

#endregion

#region Run DatabaseInitializer
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<RolesInitializer>();

    initializer.InitializeAsync().Wait();
}
#endregion

// Configuration cors
app.UseCors(
    b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() 
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();