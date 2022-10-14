using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MessageProviders.Email.Common.Extension;
using MessageProviders.Email.Common.Interfaces;
using MessageProviders.Email.MailKit;
using MessagesSender.Infrastructure.Database.Extensions;
using Microsoft.Extensions.DependencyModel;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabasePostgreSql(builder.Configuration);

var assemblies = DependencyContext.Default.RuntimeLibraries
    .SelectMany(assembly => assembly.GetDefaultAssemblyNames(DependencyContext.Default)
    .Where(assemblyName => assemblyName.FullName.StartsWith(nameof(MessagesSender)))
    .Select(Assembly.Load))
    .ToArray();

builder.Services.AddMediatR(assemblies);
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblies(assemblies));

var mapper = new Mapper(new MapperConfiguration(ctx => ctx.AddMaps(assemblies)));
builder.Services.AddSingleton<IMapper>(mapper);

builder.Services.AddMailKitProvider(builder.Configuration);
builder.Services.AddScoped<IEmailMessageProvider, MailKitProvider>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

var app = builder.Build();

await app.Services.UseMigratiosAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
