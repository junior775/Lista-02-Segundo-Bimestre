using Microsoft.EntityFrameworkCore;
using Lista_01_Segundo_Bimestre.Data;
using Lista_01_Segundo_Bimestre.Repositores;
using Lista_01_Segundo_Bimestre.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// EF Core com SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=lista01.db"));

// Injeção de dependência
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
