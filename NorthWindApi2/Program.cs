using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NorthWindApi2.Services;
using NorthWindEFRepository.Contexts;
using NorthWindEFRepository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICategoriesService, CategoriesService>()
                .AddSingleton<ICategoriesRepository, CategoriesRepository>()
                .AddDbContext<NorthWindContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")), ServiceLifetime.Singleton);

builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NorthwindWebApp2", Version = "v1" });
                });

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000",
                        "http://192.168.50.186:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));

builder.Services.AddControllers();



var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthwindWebApps v1"));
}

app.UseRouting();

app.UseCors("MyPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
