using ApiDi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IKey, KeyService>(serviceProvider =>
    new KeyService(config: serviceProvider.GetRequiredService<IConfiguration>())
);
builder.Services.AddTransient<IBasicService, BasicService>(serviceProvider =>
    new BasicService(client: serviceProvider.GetRequiredService<HttpClient>(), keyService: serviceProvider.GetRequiredService<IKey>()));
builder.Services.AddHttpClient<BasicService>();
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
