using ComCax.API.Repositories;
using ComCax.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSingleton<ILancamentoRepository, LancamentoRepositoryEmMemoria>(); // Adiciona o repositório de lançamentos em memória como um serviço singleton para que seja compartilhado em toda a aplicação
builder.Services.AddScoped<LancamentoService>(); // Adiciona o serviço de lançamentos como um serviço com escopo para que seja criado uma nova instância a cada requisição
builder.Services.AddOpenApi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opcoes =>
    {
        opcoes.SwaggerEndpoint("/openapi/v1.json", "ComCax API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
