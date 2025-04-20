using System.Threading.Channels;
using FastEndpoints;
using mediation.mediations.Infrastructure;
using MediationWorker;

var builder = WebApplication.CreateSlimBuilder(args);

var newMediationItemChannelOptions = new BoundedChannelOptions(capacity: 1000)
{
    FullMode = BoundedChannelFullMode.Wait,
    SingleReader = true,
    SingleWriter = false
};

builder.Services.AddSingleton(Channel.CreateBounded<NewMediationItem>(options: newMediationItemChannelOptions));
builder.Services.AddMediationServices(builder.Configuration);
builder.Services.AddFastEndpoints();
var app = builder.Build();
app.UseFastEndpoints();
app.Run();
