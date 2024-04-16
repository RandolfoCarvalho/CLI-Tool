using Cocona;
using System.IO;
using System.Reflection;

namespace CLI_Tool
{
    class Program
    {
        static void Main(string[] args)
        {

            var app = CoconaApp.Create();
            app.AddCommand("teste", () => { Console.WriteLine("Teste");  });


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
    }
}