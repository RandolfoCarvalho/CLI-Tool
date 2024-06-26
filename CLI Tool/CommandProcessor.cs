﻿using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using CLI_Tool.classes;

namespace CLI_Tool
{
    class CommandProcessor
    {
        public static string GetProgramName()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        }
        public static void CD()
        {
            NavegacaoDePastas.cd();
        }

        public static void TextRecord(string txt)
        {
            string[] array = txt.Split(' ');
            List<string> mensagem = new List<string>();
            for (int i = 3; i < array.Length; i++)
            {
                mensagem.Add(array[i]);
            }
            string mensagemCombinada = string.Join(" ", mensagem);
            string filePath = @$"C:\Users\{array[0]}\{array[1]}\{array[2]}.txt";
            try
            {
                Console.WriteLine();
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(mensagemCombinada);
                }
                Console.WriteLine("Mensagem fornecida: " + mensagemCombinada);
                Console.WriteLine("Mensagem gravada com sucesso");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
