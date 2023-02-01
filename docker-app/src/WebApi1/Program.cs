var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
    var kestrelSection = context.Configuration.GetSection("Kestrel");
    serverOptions.Configure(kestrelSection);
    //serverOptions.Configure(kestrelSection)
    //    .Endpoint("HTTPS", listenOptions =>
    //    {
    //        // ...
    //    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (false && UseHttps(app.Configuration))
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

bool UseHttps(IConfiguration configuration)
{
    return configuration.GetSection("Kestrel:Endpoints:Https").Exists();
}
