using CleanArchMcv.Ioc;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJwt(builder.Configuration);

builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


