using Commify.TaxCalculator.Core.DataAccess.UnitOfWork;
using Commify.TaxCalculator.Core.Taxes;
using Commify.TaxCalculator.Infrastructure.Contexts;
using Commify.TaxCalculator.Infrastructure.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Commify.TaxCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITaxService, TaxService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddDbContext<TaxCalculatorContext>();

            var app = builder.Build();

            using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TaxCalculatorContext>();
                context.Database.Migrate();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}