using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Tool
{
    delegate void CommandFunction(string? partes = null);

    class CommandProcessor
    {
        private Dictionary<string, CommandFunction> commands = new Dictionary<string, CommandFunction>();

        // Método para registrar um novo comando e associá-lo a uma função
        public void RegisterCommand(string command, CommandFunction function, string? partes = null)
        {
            commands[command] = function;
            if(partes == null) ProcessCommand(command);
            if (partes != null) ProcessCommand(command, partes);
        }

        // Método para processar um comando recebido
        public void ProcessCommand(string command, string? partes = null)
        {
            if (commands.ContainsKey(command))
            {
                if (partes == null) {
                    commands[command]();
                } else
                {
                    commands[command](partes);
                }
            }
            else
            {
                Console.WriteLine("Comando inválido");
            }
        }
        public static void Say(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public static void Help(string mensagem)
        {
            Console.WriteLine("[help] mostra esta mensagem: ");
            Console.WriteLine("[say {something}] mostra a mensagem que você escrever");
        }
        public static void Create(string mensagem)
        {
            string filePath = @"C:\Users\Luztek - Ezequiel\Desktop\teste.txt";
            try
            {
                Console.WriteLine("Escreva a mensagem que deseja dentro do arquivo: ");
                string registro = Console.ReadLine();
                File.WriteAllText(filePath, registro);

                Console.WriteLine("Mensagem fornecida: " + registro);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
