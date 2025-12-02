using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Organizations
{
    public int indexador {get; private set;}
    public string organizaçãoID {get; private set;}
    public string organizaçãoNome {get; set;}
    public string website {get; set;}
    public string país {get; set;}
    public string descrição {get; set;}
    public string dataFundação {get; set;}
    public string indústria {get; set;}
    public int númeroFuncionários {get; set;}

    public Organizations(int _index, string _organizaçãoID, string _organizaçãoNome, string _website, string _país, string _descrição, string _dataFundação, string _indústria, int _númeroFuncionários)
    {
        indexador = _index;
        organizaçãoID = _organizaçãoID;
        organizaçãoNome = _organizaçãoNome;
        website = _website;
        país = _país;
        descrição = _descrição;
        dataFundação = _dataFundação;
        indústria = _indústria;
        númeroFuncionários = _númeroFuncionários;
    }

    public static Organizations cadastroEmpresaManual(int _index) //Apenas para testes, não necessário para a versão final
    {
        Console.Clear(); //Limpando a tela

        Console.WriteLine($"ATENÇÃO! ATENÇÃO! ATENÇÃO!");
        Console.WriteLine($"Essa página serve apenas para teste de implementação e visualização!\n");
        Console.ReadKey();

        Console.WriteLine($"===================");
        Console.WriteLine($"Cadastro de Empresa");
        Console.WriteLine($"===================\n");

        Console.WriteLine($"Indexação..........: {_index}");

        Console.Write($"ID da organização..: ");
        string _organizaçãoID = Console.ReadLine();

        Console.Write($"Nome da organização: ");
        string _organizaçãoNome = Console.ReadLine();

        Console.Write($"Website............: ");
        string _website = Console.ReadLine();

        Console.Write($"País de origem.....: ");
        string _país = Console.ReadLine();

        Console.Write($"Descrição..........: ");
        string _descrição = Console.ReadLine();

        Console.Write($"Data de Fundação...: ");
        string _dataFundação = Console.ReadLine();

        Console.Write($"Indústria..........: ");
        string _indústria = Console.ReadLine();

        Console.Write($"Nº de funcionários.: ");
        int _númeroFuncionários = int.Parse(Console.ReadLine());

        return new Organizations(_index, _organizaçãoID, _organizaçãoNome, _website, _país, _descrição, _dataFundação, _indústria, _númeroFuncionários);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); //Limpando a tela

        List<Organizations> empresas = new List<Organizations>();
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
                case 1: //Apenas para testes, não necessário para a versão final
                Organizations cadastro = Organizations.cadastroEmpresaManual(empresas.Count + 1);
                empresas.Add(cadastro);
                Console.WriteLine("Cadastro criado com sucesso!");
                Console.ReadKey();
                Console.Clear();
                break;

                case 2:
                Console.Clear();
                foreach (Organizations info in empresas)
                    {
                        Console.WriteLine($"Nome da organização: {info.organizaçãoNome}");
                        Console.WriteLine($"ID da organização..: {info.organizaçãoID}");
                        Console.WriteLine($"Descrição..........: {info.descrição}");
                        Console.WriteLine($"Indústria..........: {info.indústria}");
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