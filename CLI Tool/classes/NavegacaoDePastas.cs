using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Classe responsavel pela navegacao entre pastas e criação de diretorios
namespace CLI_Tool.classes
{
    static class NavegacaoDePastas
    {

        public static void cd()
        {
            retrocedeDiretorio();
        }
        public static void criaDiretorio(string path, string target)
        {
            path = Environment.CurrentDirectory;
            string fullPath = path + (@"\" + target);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            Environment.CurrentDirectory = fullPath;
            Console.WriteLine("Diretorio " + target + " Criado");
            Console.WriteLine("Digite <create> para criar um arquivo");
            Console.WriteLine(@"Ou exit para voltar para a configuracao de pastas:");
            Console.WriteLine();
            string resposta = Console.ReadLine();
            if (resposta == "create") {
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
            } else
            {
                retrocedeDiretorio();
            }
        }

        public static void retrocedeDiretorio()
        {
            Console.WriteLine(@"Digite o local para entrar ou criar o diretorio: Exemplo <temp> or <cd ..> to go back");
            try
            {
                string path = Environment.CurrentDirectory;
                string target = Console.ReadLine();
                while (target != "exit")
                {
                    if (target == "cd ..")
                    {
                        string[] cdPath = path.Split('\\');
                        Array.Resize(ref cdPath, cdPath.Length - 1);
                        string newCdPath = String.Join("\\", cdPath);
                        Environment.CurrentDirectory = newCdPath + "\\";
                        path = Environment.CurrentDirectory;
                        Console.WriteLine($"Você esta no {Environment.CurrentDirectory}");
                    }
                    else if (target == "whereami")
                    {
                        Console.WriteLine($"Você esta no {Environment.CurrentDirectory}");
                    }
                    else
                    {
                        criaDiretorio(path, target);
                        
                    }
                    Console.WriteLine();
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
    }
}
