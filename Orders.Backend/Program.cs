var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); // options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentación de la API")
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

/**
 * Vamos agregar estas instrucciones para que no me de problema
 * el proyecto al consumir los endpoint desde la aplicación Blazor.
 * Con esto, nos habilita las peticiones. Si yo quiero colocarle
 * más seguridad al sistema u otro tipo de seguridad... aquí podría
 * empezar a bloquear las IPs que me recibe, etc.
 */
app.UseCors(policyName => policyName
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(isOriginAllowed => true)
    .AllowCredentials());

app.Run();
