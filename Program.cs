using examen3Contabilidad;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddCors(options =>
{
    options.AddPolicy("myApp", polibuilder =>
    {
        polibuilder.AllowAnyOrigin();
        polibuilder.AllowAnyHeader();
        polibuilder.AllowAnyMethod();
    });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddHttpClient<Pago>(c =>
{
    c.BaseAddress = new Uri("https://programacionweb2examen3-production.up.railway.app/");
});

builder.Services.AddHttpClient<Factura>(c =>
{
    c.BaseAddress = new Uri("https://programacionweb2examen3-production.up.railway.app/");
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<IContabilidadService, ContabilidadService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("myApp");
app.Run();
