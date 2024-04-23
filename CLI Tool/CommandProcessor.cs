using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Tool
{
    class CommandProcessor
    {
        public static string GetProgramName()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        }
        public static void TextRecord(string mensagem)
        {
            string[] array = mensagem.Split(' ');
            Console.WriteLine(array[1]);
            string filePath = @"C:\Users\Luztek - Ezequiel\Desktop\gravacao.txt";
            try
            {
                Console.WriteLine();
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
