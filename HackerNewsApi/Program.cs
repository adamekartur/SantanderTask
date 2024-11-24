using HackerNewsDomain.Repository;
using HackerNewsDomain.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FirebaseioNewsRepository>();
builder.Services.AddScoped<INewsService, HackerNewsService>();
builder.Services.AddScoped<INewsRepository, RedisDecoratorRepository>(cnf => 
{
    var redisConStr = builder.Configuration["REDISCACHECONNSTR_Redis"] ?? throw new ArgumentException("No connection string set.");
    IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(redisConStr);
    return new RedisDecoratorRepository(cnf.GetRequiredService<FirebaseioNewsRepository>(), multiplexer.GetDatabase()); 
});

builder.Services.AddSingleton<HttpClient>();


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
