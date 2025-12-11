using System;
using System.IO;
using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    public string númeroFuncionários {get; set;}

    public Organizations(int _index, string _organizaçãoID, string _organizaçãoNome, string _website, string _país, string _descrição, string _dataFundação, string _indústria, string _númeroFuncionários)
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

    public Organizations () {} //Construtor vazio apenas para poder instanciar objetos sem todos os requisitos

    public static Organizations cadastroEmpresaManual(List<Organizations> empresas) //Função para cadastrar a empresa manualmente
    {
        Console.Clear(); //Limpando a tela
        Console.WriteLine(); //Corrigir um erro onde uma das linhas é pulada no terminal, por algum motivo...

        Console.WriteLine($"=======================");
        Console.WriteLine($"= Cadastro de Empresa =");
        Console.WriteLine($"=======================\n");

        int _index = 0;

        if (empresas.Count == 0)
            _index = 1;
        
        else
            _index = empresas[empresas.Count - 1].indexador + 1;
        

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
        string _númeroFuncionários = Console.ReadLine();

        return new Organizations(_index, _organizaçãoID, _organizaçãoNome, _website, _país, _descrição, _dataFundação, _indústria, _númeroFuncionários);
    }

    public static List<Organizations> salvarLista(string caminho, List<Organizations> empresas) //Função para ler o arquivo .CSV 
    {
        
        string[] linhas = File.ReadAllLines(caminho);

         for (int i = 1; i < linhas.Length; i++)
        {
            Organizations cadastro  = new Organizations();
            string linha = linhas[i]; //Colocar todas as informações da linha em uma variável
            string[] p = linha.Split(','); //Separar as informações em um vetor para atribuir a cada elemento

            if (empresas.Count == 0)
                cadastro.indexador = 1;
        
            else
                cadastro.indexador = empresas[empresas.Count - 1].indexador + 1;
            
            cadastro.organizaçãoID = p[1];
            cadastro.organizaçãoNome = p[2];
            cadastro.website = p[3];
            cadastro.país = p[4];
            cadastro.descrição = p[5];
            cadastro.dataFundação = p[6];
            cadastro.indústria = p[7];
            cadastro.númeroFuncionários = p[8];

            empresas.Add(cadastro);
        }
        return empresas;
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
            Console.Clear(); //Limpando a tela
            Console.WriteLine(); //Corrigir um erro onde uma das linhas é pulada no terminal, por algum motivo...
            Console.WriteLine("==================");
            Console.WriteLine("= Menu Principal =");
            Console.WriteLine($"==================\n");

            Console.WriteLine($"1 - Criar Cadastro");
            Console.WriteLine($"2 - Listar Cadastros");
            Console.WriteLine($"3 - Pesquisar Cadastro");
            Console.WriteLine($"4 - Excluir Cadastro");
            Console.WriteLine($"5 - Ler arquivo");
            Console.WriteLine($"9 - Sair");

            Console.Write("Opção: ");
            Def = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (Def)
            {
                case 1: //Cadastro de informações
                Organizations cadastro = Organizations.cadastroEmpresaManual(empresas);
                empresas.Add(cadastro);
                Console.WriteLine("Cadastro criado com sucesso!");
                Console.ReadKey();
                break;

                case 2: //Listando todos os cadastros
                Console.Clear(); //Limpando a tela
                Console.WriteLine(); //Corrigir um erro onde uma das linhas é pulada no terminal, por algum motivo...
                Console.WriteLine("====================");
                Console.WriteLine("= Listar Cadastros =");
                Console.WriteLine($"====================\n");

                foreach (Organizations info in empresas)
                    {
                        Console.WriteLine($"Indexador..........: {info.indexador}");
                        Console.WriteLine($"Nome da organização: {info.organizaçãoNome}");
                        Console.WriteLine($"ID da organização..: {info.organizaçãoID}");
                        Console.WriteLine($"Descrição..........: {info.descrição}");
                        Console.WriteLine($"Indústria..........: {info.indústria}");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                break;

                case 3: //Procurando um cadastro específico, providenciando todas as informações dele
                Console.Clear();
                Console.WriteLine(); //Corrigir um erro onde uma das linhas é pulada no terminal, por algum motivo...
                Console.WriteLine("=====================");
                Console.WriteLine("= Procurar Cadastro =");
                Console.WriteLine($"=====================\n");

                Console.WriteLine($"Insira um ID para ser procurado: ");
                Console.Write("ID: ");
                string escolhaProcura = Console.ReadLine();

                foreach (Organizations info in empresas)
                    {
                        if (escolhaProcura == info.organizaçãoID)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Nome: {info.organizaçãoNome}");
                            Console.WriteLine($"Website: {info.website}");
                            Console.WriteLine($"País: {info.país}");
                            Console.WriteLine($"Descrição: {info.descrição}");
                            Console.WriteLine($"Fundação: {info.dataFundação}");
                            Console.WriteLine($"Indústria: {info.indústria}");
                            Console.WriteLine($"Nº de Funcionários: {info.númeroFuncionários}");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                break;

                case 4: //Excluir um cadastro
                Console.Clear();
                Console.WriteLine(); //Corrigir um erro onde uma das linhas é pulada no terminal, por algum motivo...
                Console.WriteLine("====================");
                Console.WriteLine("= Excluir Cadastro =");
                Console.WriteLine($"====================\n");

                Console.WriteLine($"Insira um ID para ser excluído: ");
                Console.Write($"ID: ");
                string escolhaExcluir = Console.ReadLine();
                Organizations alvo = null;

                foreach (Organizations info in empresas)
                {
                    if (escolhaExcluir == info.organizaçãoID)
                        {
                            Console.WriteLine($"ID encontrado!");
                            Console.WriteLine($"Deseja excluir a empresa: {info.organizaçãoNome} (Y/N)?");
                            Console.Write("Opção: ");
                            char verificador = char.Parse(Console.ReadLine());

                            if ((verificador == 'y') || (verificador == 'Y'))
                            {
                                alvo = info;
                                break;
                            }
                        }
                }

                if (alvo != null)
                {
                    empresas.Remove(alvo);
                    Console.WriteLine();
                    Console.WriteLine($"Cadastro excluído com sucesso!");
                    Console.ReadKey();
                    Console.Clear();
                }
                break;

                case 5: //Ler um arquivo e salvar na lista
                int escolhaArquivo = 0;
                do
                {
                Console.Clear(); //Limpando a tela
                Console.WriteLine(); //Corrigir um erro onde uma das linhas é pulada no terminal, por algum motivo...
                Console.WriteLine("================");
                Console.WriteLine("= Ler arquivos =");
                Console.WriteLine($"================\n");

                Console.WriteLine("Escolha o tamanho do arquivo: ");
                Console.WriteLine("1 - 100 linhas");
                Console.WriteLine("2 - 1000 linhas");
                Console.WriteLine("3 - 10000 linhas");
                Console.WriteLine("4 - 100000 linhas");
                Console.WriteLine("5 - Voltar ao menu");
                Console.Write("Opção: ");
                escolhaArquivo = int.Parse(Console.ReadLine());

                switch (escolhaArquivo)
                    {
                        case 1:
                        string path_100 = "organizations-100.csv";
                        string full_100 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path_100);
                        empresas = Organizations.salvarLista(full_100, empresas);
                        Console.WriteLine("Arquivo lido com sucesso!");
                        Console.ReadKey();
                        escolhaArquivo = 5;
                        break;

                        case 2:
                        string path_1000 = "organizations-1000.csv";
                        string full_1000 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path_1000);
                        empresas = Organizations.salvarLista(full_1000, empresas);
                        Console.WriteLine("Arquivo lido com sucesso!");
                        Console.ReadKey();
                        escolhaArquivo = 5;
                        break;

                        case 3:
                        string path_10000 = "organizations-10000.csv";
                        string full_10000 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path_10000);
                        empresas = Organizations.salvarLista(full_10000, empresas);
                        Console.WriteLine("Arquivo lido com sucesso!");
                        Console.ReadKey();
                        escolhaArquivo = 5;
                        break;

                        case 4:
                        string path_100000 = "organizations-100000.csv";
                        string full_100000 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path_100000);
                        empresas = Organizations.salvarLista(full_100000, empresas);
                        Console.WriteLine("Arquivo lido com sucesso!");
                        Console.ReadKey();
                        escolhaArquivo = 5;
                        break;

                        case 5:
                        Console.Clear();
                        Console.WriteLine("Voltando ao menu principal...");
                        Console.ReadKey();
                        break;

                        default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                    }
                } while (escolhaArquivo != 5);
                break;

                case 9: //Sair do programa
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