
using System.Runtime.Loader;

namespace Todo.Service;
class Program
{
    static void Main(string[] args)
    {
        var files = Directory.GetFiles(
                AppDomain.CurrentDomain.BaseDirectory,
                "Todo*.dll");

        var assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen();
        builder.Services.AddAdvancedDependencyInjection();
        
        builder.Services.Scan(p => p.FromAssemblies(assemblies)
            .AddClasses()
            .AsMatchingInterface());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.UseAdvancedDependencyInjection();


        app.Run();
    }
}
