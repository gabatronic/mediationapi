using System.Threading.Channels;
using FastEndpoints;
using FastEndpoints.Swagger;
using  mediation.mediations.Infrastructure;
using MediationWorker;
using Mediation.Plans.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddEndpointsApiExplorer();
var chnBoundedChannelOptions = new BoundedChannelOptions(2000)
{
    SingleWriter = true,
    SingleReader = true
};
builder.Services.AddSingleton(Channel.CreateBounded<NewMediationItem>(chnBoundedChannelOptions));
builder.Services.AddMediationServices(builder.Configuration);
builder.Services.AddPlansServices(builder.Configuration);
builder.Services.AddHostedService<MediationWorker.MediationWorker>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseFastEndpoints().UseSwaggerGen();
app.Run();
