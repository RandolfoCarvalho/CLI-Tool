using System.Reflection;

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
                        Console.WriteLine("New cd Path: " + newCdPath);
                        Console.WriteLine("Environment: " + Environment.CurrentDirectory);
                        Console.WriteLine("Path: " + path);
                        Console.WriteLine($"Você esta no {Environment.CurrentDirectory}");
                    }
                    else
                    {
                        path = Environment.CurrentDirectory;
                        string fullPath = path + (@"\" + target);
                        if (!Directory.Exists(fullPath))
                        {
                            Directory.CreateDirectory(fullPath);
                        }
                        Environment.CurrentDirectory = fullPath;
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
