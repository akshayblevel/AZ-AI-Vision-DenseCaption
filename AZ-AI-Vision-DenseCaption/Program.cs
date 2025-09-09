using AZ_AI_Vision_DenseCaption.Interfaces;
using AZ_AI_Vision_DenseCaption.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IVisionService, VisionService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AzureVision:Endpoint"]);
});
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
