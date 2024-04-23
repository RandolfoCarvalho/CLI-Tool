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
            string filePath = @$"C:\Users\{array[0]}\{array[1]}\gravacao.txt";
            try
            {
                Console.WriteLine();
                File.WriteAllText(filePath, array[2]);

                Console.WriteLine("Mensagem fornecida: " + array[2]);
                Console.WriteLine("Mensagem gravada com sucesso");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
