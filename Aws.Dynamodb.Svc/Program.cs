using Aws.Dynamodb.Svc.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.DynamoDbSettings();
builder.Services.DependencyInjectionSettings();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/healthcheck");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
