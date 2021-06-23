using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Volvo.Data;
using Volvo.Models;

namespace Volvo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Criando Banco de dados
            using (var context = new VolvoContext(new DbContextOptions<VolvoContext>()))
            {
                //Criar Banco de dados e suas tabelas
                context.Database.Migrate();                
            }
                                    
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
