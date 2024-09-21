using netflixProjectBackendDotNet.Api.Extensions;
using netflixProjectBackendDotNet.Api.Middlewares;
using Serilog;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseSerilog((context, builder) => {
            builder.WriteTo.Console();
            builder.WriteTo.File($"Logs/netflix-{DateTime.Now.ToShortDateString()}.txt");
            });

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCustomAuthentication(builder.Configuration);
        builder.Services.AddSwagger();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Services.AddApiServices(builder.Configuration);
        builder.Services.AddCors(o => o.AddPolicy("allow", b => b.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
                options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Web API");
            });
        }
        app.UseMiddleware<AuthenticationMiddleware>();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseCors("allow");
        app.UseAuthorization();
        app.MapControllers();
        app.MapHealthChecks("/health");
        

        try
        {
            Log.Information("Running app at : ", DateTime.Now.ToShortTimeString());
            await app.RunAsync();
        }
        catch(Exception ex)
        {
            Log.Error("Error during ruinning application : ", ex.Message);
            await app.StopAsync();
        }
    }
}