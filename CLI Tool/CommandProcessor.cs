using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static void CD()
        {
            Console.WriteLine(@"Digite o local para entrar ou criar o diretorio: Exemplo <\temp>");
            string path = Directory.GetCurrentDirectory();
            string target = Console.ReadLine();
            try
            {
                while (target != "exit")
                {
                    if (target == "cd ..")
                    {
                        Console.WriteLine($"Você esta no {path} ");
                    }
                    else
                    {
                        Environment.CurrentDirectory = (path + target);
                        string fullPath = Environment.CurrentDirectory;
                        if (!Directory.Exists(fullPath))
                        {
                            Directory.CreateDirectory(fullPath);
                        }
                        if (Environment.CurrentDirectory.Equals(Directory.GetCurrentDirectory()))
                        {
                            Console.WriteLine($"Você esta no {fullPath} ");
                            Console.WriteLine();
                            Console.WriteLine("Agora o nome do arquivo");
                            string arquivo = Console.ReadLine();
                            string pathToWrite = Environment.CurrentDirectory + @$"\{arquivo}.txt";
                            using (StreamWriter writer = new StreamWriter(pathToWrite, true))
                            {
                                Console.WriteLine("Escreva uma mensagem");
                                string mensagem = Console.ReadLine();
                                writer.WriteLine(mensagem);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Diretorio mismatch");
                        }
                    }
                    Console.WriteLine(@"Digite o local para entrar ou criar o diretorio: Exemplo <\temp> or <cd ..> to go back");
                    Console.WriteLine("To exit say <exit>");
                    target = Console.ReadLine();
                }
            }
            catch (Exception e)

            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
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
