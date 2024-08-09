using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using WebAppCookBook.API.Service;
using WebAppCookBook.DbContexts;
using WebAppCookBook.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    })
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlite("Data Source=CookingBookDB.db");
});

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler(opt =>
    {
        opt.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Oops, something went wrong");
        });
    });
}


app.UseRouting(); //   
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseStaticFiles();

//app.MapControllers(); 

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

