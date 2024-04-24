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
            string target = Console.ReadLine();
            try
            {
                string path = Directory.GetCurrentDirectory();
                Environment.CurrentDirectory = (path + target);

                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }
                if (Environment.CurrentDirectory.Equals(Directory.GetCurrentDirectory()))
                {
                    Console.WriteLine($"Você esta no {target} ");
                    Console.WriteLine(Environment.CurrentDirectory);
                    Console.WriteLine();
                    Console.WriteLine("Agora o nome do arquivo");
                    string arquivo = Console.ReadLine();
                    Environment.CurrentDirectory = Environment.CurrentDirectory + @$"\{arquivo}.txt";
                    using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory, true))
                    {
                        Console.WriteLine("Escreva uma mensagem");
                        string mensagem = Console.ReadLine();
                        writer.WriteLine(mensagem);
                    }
                }
                else
                {
                   
                }
            }
            catch (Exception e)

            {
                    Console.WriteLine("The process failed: {0}", e.ToString());
            }
            /* Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            
            while (true)
            {

                string comando = Console.ReadLine();
                process.StandardInput.WriteLine($"{comando}");
            } 
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            */
        }

        public static void TextRecord(string txt)
        {
            string[] array = txt.Split(' ');
            List<string> mensagem = new List<string>();
            for (int i = 3; i <  array.Length; i++)
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
