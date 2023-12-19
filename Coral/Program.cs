using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Coral.Data;
using Microsoft.Data.SqlClient;
using Coral.Models;
using Coral.Mapper;
var builder = WebApplication.CreateBuilder(args);

//添加服务到容器
builder.Services.AddRazorPages();

//获取机密文件中的密码
var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CoralContext")) { Password = builder.Configuration["DbPassword"] };

//添加数据库上下文
builder.Services.AddDbContext<CoralContext>(options => options.UseSqlServer(conStrBuilder.ConnectionString ?? throw new InvalidOperationException("Connection string 'CoralContext' not found.")));

builder.Services.AddAutoMapper(typeof(CustomProfile));

var app = builder.Build();

//种子数据
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
SeedData.Initialize(services);


// 配置Http管道
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    //默认 HSTS 值为 30 天。你可能希望针对生产方案更改此设置，请参阅 https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
