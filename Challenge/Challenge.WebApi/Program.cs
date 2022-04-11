using Challenge.WebApi.Infraestructure;
using Challenge.Services.Implementations;
using Challenge.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
string myAllowAllCors = "AllowAllCORS";
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
// Add services to the container.
builder.Services.AddServices(configuration);
builder.Services.AddAutoMapper(typeof(Program), typeof(ProductService));
builder.Services.AddCORS();
builder.Services.AddControllers();
builder.Services.SetInvalidModel();
builder.Services.SetCache();
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
app.ConfigureExceptionHandler();
app.UseCors(myAllowAllCors);
app.UseAuthorization();

app.MapControllers();

app.Run();
