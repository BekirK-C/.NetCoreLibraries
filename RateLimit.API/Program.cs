using AspNetCoreRateLimit;

namespace RateLimit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //https://github.com/stefanprodan/AspNetCoreRateLimit/wiki/IpRateLimitMiddleware#setup

            builder.Services.AddOptions(); //appsetting.json içerisindeki key-value çiftlerini bir class üzerinden okumayý saðlar.
            builder.Services.AddMemoryCache(); //Limit deðerini ve istek sayýlarýný memory'de tutmayý saðlar.
            builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting")); //IP adresi ile ilgili izin
            builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies")); //IP adresi ile ilgili policy
            builder.Services.AddInMemoryRateLimiting(); //inject counter and rules stores
            builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}