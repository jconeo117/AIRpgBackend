
using AiRpgBackend.Interfaces;
using AiRpgBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("LMStudioClient", client =>
{
    client.Timeout = TimeSpan.FromSeconds(60);
});
builder.Services.AddScoped<ILLMIntegrationService, LLMIntegrationService>();
builder.Services.AddScoped<IAnalyzerPrompt, AnalizerPrompt>();
builder.Services.AddScoped<IContextService, ContextService>();
builder.Services.AddScoped<NarrativeComposerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocal",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowLocal");


app.MapControllers();

app.Run();
