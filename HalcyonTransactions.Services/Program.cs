using HalcyonTransactions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Bind MySettings section to MySettings class
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("Settings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

//Dependency Injection
builder.Services.AddSingleton<ApplicationSettings>();
builder.Services.AddTransient<IServices, Services>();

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
