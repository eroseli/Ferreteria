var builder = WebApplication.CreateBuilder(args);

//Configuracion 
var configuration = new ConfigurationBuilder();
configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
configuration.Build();


//obtener los datos del cliente
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
