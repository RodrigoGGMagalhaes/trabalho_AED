using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Pessoa
{
    public string Nome {get; set;}

    public string Código {get; private set;}

    public string Telefone {get; set;}

    public Pessoa(string _Nome, string _Telefone)
    {
        Nome = _Nome;
        Código = geraCódigo();
        Telefone = _Telefone;
    }

    public string geraCódigo()
    {
        string _Código = "";
        Random X = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        for (int i = 0; i < 4; i++)
            _Código += chars[X.Next(0, chars.Length)];
        
        return _Código;
    }

    public static Pessoa cadastroNovaPessoa()
    {
        Console.Clear(); //Limpando a tela

        Console.WriteLine($"===================");
        Console.WriteLine($"Cadastro de Usuário");
        Console.WriteLine($"===================\n");

        Console.Write($"Nome....: ");
        string _Nome = Console.ReadLine();

        Console.Write($"Telefone: ");
        string _Telefone = Console.ReadLine();

        return new Pessoa(_Nome, _Telefone);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); //Limpando a tela

        List<Pessoa> cadastros = new List<Pessoa>();
        int Def = 0;
        do
        {
            Console.WriteLine($"Aplicação AED");
            Console.WriteLine($"1 - Criar Cadastro");
            Console.WriteLine($"2 - Mostrar Cadastros");
            Console.WriteLine($"9 - Sair");

            Console.Write("Opção: ");
            Def = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (Def)
            {
                case 1:
                Pessoa cadastro = Pessoa.cadastroNovaPessoa();
                cadastros.Add(cadastro);
                Console.WriteLine("Cadastro criado com sucesso!");
                Console.ReadKey();
                Console.Clear();
                break;

                case 2:
                Console.Clear();
                foreach (Pessoa info in cadastros)
                    {
                        Console.WriteLine($"Pessoa: {info.Nome}");
                        Console.WriteLine($"Código: {info.Código}");
                        Console.WriteLine($"Telefone: {info.Telefone}");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                break;

                case 9:
                Console.WriteLine("Obrigado por utilizar nosso sistema!");
                break;
                
                default:
                Console.Clear();
                Console.WriteLine("Opção Inválida ou função não implementada");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
                Console.Clear();
                break;
            }

        } while (Def != 9);
    }
}