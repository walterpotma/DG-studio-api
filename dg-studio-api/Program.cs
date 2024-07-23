using dg_studio_api.Infraestrutura;
using dg_studio_api.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with dependency injection
builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<ICacheRepository, CacheRepository>();

var key = Encoding.ASCII.GetBytes(dg_studio_api.Key.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = true,
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Master", policy =>
        policy.RequireClaim("Categoria", "MASTER"));
    options.AddPolicy("Produtora", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "Categoria" && (c.Value == "MASTER" || c.Value == "scan"))));
    options.AddPolicy("Artista", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "Categoria" && (c.Value == "MASTER" || c.Value == "autor" ))));
    options.AddPolicy("User", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "Categoria" && (c.Value == "MASTER" || c.Value == "scan" || c.Value == "autor" || c.Value == "leitor"))));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
