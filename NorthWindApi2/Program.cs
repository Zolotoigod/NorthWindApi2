using Microsoft.OpenApi.Models;
using NorthWindApi2;
using NorthWindApi2.AppBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigurateApp();

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

app.Logger.LogInformation(string.Format(Defines.LogMessage.AppStart, app.Configuration.GetSection("ASPNETCORE_URLS").Value.ToString()));
//app.Lifetime.ApplicationStopped.Register(() => app.Logger.LogInformation(string.Format(Defines.LogMessage.AppStop)));    

app.Run();

