using RideShare.DAL;
using RideShare.BLL;
using RideShare.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServicesApi();
builder.Services.RegisterServicesDal(builder.Configuration);
builder.Services.RegisterServicesBLL(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
