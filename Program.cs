using ApiDi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IKey, KeyService>(serviceProvider =>
    new KeyService(config: serviceProvider.GetRequiredService<IConfiguration>())
);

builder.Services.AddTransient<IBasicService, BasicService>(serviceProvider =>
    new BasicService(client: serviceProvider.GetRequiredService<HttpClient>(), keyService: serviceProvider.GetRequiredService<IKey>()));
builder.Services.AddHttpClient<BasicService>();

builder.Services.AddTransient<IAVService, AVService>(serviceProvider =>
    new AVService(client: serviceProvider.GetRequiredService<HttpClient>(), baseUri: "https://www.alphavantage.co/query?function={0}&symbol={1}&interval={2}&apikey={3}", apiKey: serviceProvider.GetRequiredService<IKey>().GetAlphaVantage() != null ? serviceProvider.GetRequiredService<IKey>().GetAlphaVantage() : throw new Exception("Config value 'AlphaVantageKey' not found on Service Initialization.")));
builder.Services.AddHttpClient<AVService>();

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
