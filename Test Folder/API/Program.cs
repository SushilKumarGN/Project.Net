using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Cors.Infrastructure;



var builder = WebApplication.CreateBuilder(args);


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

//app.UseCors(policy => policy
//    .WithOrigins("http://localhost:4200") // You can restrict origins here if needed
//    .AllowAnyMethod()
//    .AllowAnyHeader())
//    .WithExposedHeaders("Access-Control-Allow-Origin"));

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()

    .WithExposedHeaders("Access-Control-Allow-Origin"));



app.UseAuthorization();

app.MapControllers();


app.Run();

