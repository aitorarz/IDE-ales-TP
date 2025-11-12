using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Music.Config;
using Music.Repositories;
using Music.Services;
using Music.Utils;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
        .Where(x => x.Value?.Errors.Count > 0)
        .ToDictionary(
            kvp => kvp.Key,
            kvp =>
                kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                ?? Array.Empty<string>()
        );
        return new BadRequestObjectResult(new ValidationErrorResponse(errors));
    };
});
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Auth API",
        Description = "An ASP.NET Core Web Api for managing Auth"
    });

    options.AddSecurityDefinition("Token", new OpenApiSecurityScheme()
    {
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer Scheme.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Name = "Authorization",
        Scheme = "bearer"
    });

    options.OperationFilter<AuthOperationFilter>();
});

// Services
builder.Services.AddScoped<GenreServices>();
builder.Services.AddScoped<ArtistServices>();
builder.Services.AddScoped<AlbumServices>();
builder.Services.AddScoped<SongServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddScoped<IEncoderServices, EncoderServices>();
builder.Services.AddScoped<RoleServices>();

//Repositories
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();


// Mapper
builder.Services.AddAutoMapper(opts => { }, typeof(Mapping));



// DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("devConnection"));
});

// JWT
var secret = builder.Configuration.GetSection("Secrets:JWT")?.Value?.ToString() ?? string.Empty;
var key = Encoding.UTF8.GetBytes(secret);

builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opts =>
    {
        opts.SaveToken = true;
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,

        };
    })
    .AddCookie(opts =>
    {
        opts.Cookie.HttpOnly = true;
        opts.Cookie.SameSite = SameSiteMode.None;
        opts.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        opts.ExpireTimeSpan = TimeSpan.FromDays(1);
    });


var app = builder.Build();

app.UseCors(opts =>
{
    opts.AllowAnyMethod();
    opts.AllowAnyOrigin();
    opts.AllowAnyHeader();
    opts.WithOrigins("http://localhost:5173");
});

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
