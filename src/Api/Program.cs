using Api.Configuration;
using Application.AutoMapper;
using Domain.CoreModels;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

builder.Services.AddApiConfig();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerConfig();

builder.Services.SetConnectionData(builder.Configuration);

builder.Services.ResolveDependencies();

builder.Services.AddOptions<ApplicationSettings>().Configure<IConfiguration>((settings, configuration) => configuration.GetSection("ApplicationSettings").Bind(settings));

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfig(app.Environment);

app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.Run();
