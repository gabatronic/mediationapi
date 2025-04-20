using MediationWorker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<MediationWorker.MediationWorker>();

var host = builder.Build();
host.Run();