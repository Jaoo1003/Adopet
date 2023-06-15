using Adopet.Usuario.Data.EfCore;
using Adopet.Usuario.Data.InterfaceDao;
using Adopet.Usuario.Services;
using Adopet.Usuario.Services.Handler;
using AdopetUsuario.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsuarioDbContext>(opts => opts.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<UsuarioDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IAdminUserService, DefaultAdminUserService>();
builder.Services.AddTransient<ILoginDao, LoginDaoComEfCore>();
builder.Services.AddTransient<ISigninDao, SigninDaoComEfCore>();
builder.Services.AddScoped<TokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
