var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Defect_Identifier_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Defect_Identifier_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
