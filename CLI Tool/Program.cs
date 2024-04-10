namespace CLI_Tool
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            }
        }
    }
}