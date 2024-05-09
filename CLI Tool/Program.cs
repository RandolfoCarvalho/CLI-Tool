using Cocona;
using System.Diagnostics;
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
            //para usar dotnet run teste --text "<1 user | 2 local | 3 text>"
            //1 user | 2 local | 3 text
            app.AddCommand("record", (string text) => { CommandProcessor.TextRecord(text);  });
            app.AddCommand("cd", () => { CommandProcessor.CD();});
            app.AddCommand("help", () => {
                Console.WriteLine("Retorna esta mensagem");
            });
            Console.WriteLine("Nome do programa: " + CommandProcessor.GetProgramName());

            app.Run();
            Console.ReadLine();
        }
    }
}