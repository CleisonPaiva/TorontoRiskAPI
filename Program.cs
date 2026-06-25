using TorontoRiskAPI.Data;
using TorontoRiskAPI.Services;
using TorontoRiskAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Lê a connection string da configuração
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Converte URI do formato postgresql:// para o formato Npgsql (Host=...;Port=...;)
// Necessário porque o Render pode quebrar a string com ponto e vírgula
if (connectionString != null && connectionString.StartsWith("postgresql://"))
{
    var uri = new Uri(connectionString);
    connectionString = $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={uri.UserInfo.Split(':')[0]};Password={uri.UserInfo.Split(':')[1]};SSL Mode=Require;Trust Server Certificate=true";
}

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new NetTopologySuite.IO.Converters.GeoJsonConverterFactory()
        );
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "http://localhost:5174"
        )
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<ISubwayService, SubwayService>();
builder.Services.AddScoped<IFloodZoneService, FloodZoneService>();
builder.Services.AddScoped<INeighborhoodService, NeighborhoodService>();

// Usa a connectionString já convertida (não o Configuration direto)
builder.Services.AddDbContext<TorontoRiskDbContext>(options =>
    options.UseNpgsql(
        connectionString,
        o => o.UseNetTopologySuite()
    )
);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
