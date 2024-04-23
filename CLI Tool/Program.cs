using Cocona;
using System.IO;
using System.Reflection;

namespace CLI_Tool
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = CoconaApp.CreateBuilder();
            var app = builder.Build();
            //para usar dotnet run teste --text "<text>"
            app.AddCommand("teste", (string text) => { CommandProcessor.TextRecord(text);  });
            app.AddCommand("help", () => {
                Console.WriteLine("Retorna esta mensagem");
            });
            Console.WriteLine("Nome do programa: " + CommandProcessor.GetProgramName());

            app.Run();
            Console.ReadLine();
        }
    }
}