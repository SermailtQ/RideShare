using RideShare.DAL;
using RideShare.BLL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServicesDal(builder.Configuration);
builder.Services.RegisterServicesBLL();

builder.Services.AddControllers();
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
