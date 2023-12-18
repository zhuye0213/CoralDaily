using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Coral.Data;
using Microsoft.Data.SqlClient;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CoralContext")) {
    Password = builder.Configuration["DbPassword"]
};

builder.Services.AddDbContext<CoralContext>(
    options => options.UseSqlServer(conStrBuilder.ConnectionString ?? throw new InvalidOperationException("Connection string 'CoralContext' not found."))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
