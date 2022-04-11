using AutoMapper;
using Challenge.MinimalApi.Extensions;
using Challenge.MinimalApi.Infraestructure;
using Challenge.MinimalApi.Models;
using Challenge.Services.Implementations;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service = Challenge.Services.Models;
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
// Add services to the container.
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

app.MapGet("/Product/GetById", ( (int productId, IProductService _productService, IMapper _mapper) =>
{

    var result = _productService.GetProductById(productId);
    return Results.Ok(_mapper.Map<ProductResponse>(result));
}));

app.MapPost("/Product/Insert", (([FromBody] ProductInsertRequest request,IMapper _mapper, IProductService _productService) =>
{

    var productParams = _mapper.Map<Service.ProductInsertParams>(request);

    var result = _productService.InsertProduct(productParams);
    return Results.Ok(_mapper.Map<ProductResponse>(result));
}));

app.MapPut("/Product/Update", (([FromBody] ProductUpdateRequest request, IMapper _mapper, IProductService _productService) =>
{

    var productParams = _mapper.Map<Service.ProductUpdateParams>(request);

    var result = _productService.UpdateProduct(productParams);

    return Results.Ok(_mapper.Map<ProductResponse>(result));
}));
app.Run();