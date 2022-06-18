using Microsoft.EntityFrameworkCore;
using PlayCountTrackerAPI;
using PlayCountTrackerAPI.Routes;
using RepositoryLayer;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["SqlConnection:DefaultConnectionString"];
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSwagger();
builder.Services.AddJwtBearerAuthentication(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.ConfigureUserRoutes();
app.ConfigureArtistRoutes();
app.ConfigureTrackRoutes();

app.Run();