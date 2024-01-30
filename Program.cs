var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IKey, KeyService>(serviceProvider =>
    new KeyService(config: serviceProvider.GetRequiredService<IConfiguration>())
);
builder.Services.AddTransient<IBasicService, BasicService>(serviceProvider =>
    new BasicService(client: serviceProvider.GetRequiredService<HttpClient>(), keyService: serviceProvider.GetRequiredService<IKey>()));
builder.Services.AddHttpClient<BasicService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
