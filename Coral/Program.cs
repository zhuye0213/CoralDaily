using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Coral.Data;
using Microsoft.Data.SqlClient;
using Coral.Models;
using Coral.Mapper;
var builder = WebApplication.CreateBuilder(args);

//��ӷ�������
builder.Services.AddRazorPages();

//��ȡ�����ļ��е�����
var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CoralContext")) { Password = builder.Configuration["DbPassword"] };

//������ݿ�������
builder.Services.AddDbContext<CoralContext>(options => options.UseSqlServer(conStrBuilder.ConnectionString ?? throw new InvalidOperationException("Connection string 'CoralContext' not found.")));

builder.Services.AddAutoMapper(typeof(CustomProfile));

var app = builder.Build();

//��������
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
SeedData.Initialize(services);


// ����Http�ܵ�
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    //Ĭ�� HSTS ֵΪ 30 �졣�����ϣ����������������Ĵ����ã������ https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
