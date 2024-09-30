using ExpenseTracker;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Service;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<MongoDBSettings>(
            builder.Configuration.GetSection("MongoDB"));
        
        builder.Services.AddSingleton<CategoryService>();

        // Add services to the container.

        builder.Services.AddControllers();

        //Replaced with mongo when moved to mac for personal machine
        /*
        builder.Services.AddDbContext<DBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
        */

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseSwagger();
        //     app.UseSwaggerUI();
        // }

        ExpenseTrackerLoggerFactory.Initialize(app.Services.GetRequiredService<ILoggerFactory>());
        ILogger _logger = ExpenseTrackerLoggerFactory.GetStaticLogger<Program>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}