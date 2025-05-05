using Microsoft.EntityFrameworkCore;
using Web.Api.Configuration;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Application.Services;
using Web.Application.Validation;
using Web.Infrastructure.Database;
using Web.Infrastructure.Database.Context;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureApplication();

var app = builder.Build();
app.Configure().Run();
