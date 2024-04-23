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
            //para usar dotnet run teste --text <text>
            app.AddCommand("teste", (string text) => { TextRecord(text);  });
            app.AddCommand("help", () => {
                Console.WriteLine("Retorna esta mensagem");
            });
            Console.WriteLine("Nome do programa: " + GetProgramName());

            app.Run();
            Console.ReadLine();


            /* string filePath = @"C:\Users\Luztek - Ezequiel\Desktop\teste.txt";

            Console.WriteLine("Bem-vindo à minha CLI!");
            Console.WriteLine("Digite 'help' para ver os comandos disponíveis.");

            while (true)
            {
                Console.Write("> ");
                var entrada = Console.ReadLine();

                if(entrada.ToLower() == "help")
                {
                    Console.WriteLine("[help] mostra esta mensagem: ");
                    Console.WriteLine("[say {something}] mostra a mensagem que você escrever");
                }
                else if (entrada.ToLower().StartsWith("say"))
                {
                    string[] partes = entrada.Split(new char[] { ' ' }, 2);

                    if (partes.Length == 2)
                    {
                        Console.WriteLine(partes[1]);
                    }
                    else
                    {
                        Console.WriteLine("Uso: say [mensagem]");
                    }
                }
                else if (entrada.ToLower() == "create")
                {
                    try
                    {
                        Console.WriteLine("Escreva a mensagem que deseja dentro do arquivo: ");
                        string mensagem = Console.ReadLine();
                        File.WriteAllText(filePath, mensagem);

                        Console.WriteLine("Mensagem fornecida: " + mensagem);

                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            */
        }
        static string GetProgramName()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        } 
        static void TextRecord(string mensagem)
        {
            string filePath = @"C:\Users\rando\Desktop\gravacao.txt";
            try
            {
                Console.WriteLine("Escreva a mensagem que deseja dentro do arquivo: ");
                File.WriteAllText(filePath, mensagem);

                Console.WriteLine("Mensagem fornecida: " + mensagem);
                Console.WriteLine("Mensagem gravada com sucesso");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}