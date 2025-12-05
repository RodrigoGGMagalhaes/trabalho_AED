using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System;
using System.Collections.Generic;
using System.IO;

public class Pessoa
{
    public int Index { get; set; }
    public string UserId { get; set; }
    public string FN { get; set; } // first name

    public string LN { get; set; } // Last name

    public string Sexo { get; set; }

    public string Email { get; set; }

    public string Telefone { get; set; }

    public string DDA { get; set; } // data de aniversario

    public string JB { get; set; } //empresa

    public Pessoa(string[] dados)
    {
        Index = int.Parse(dados[0]);
        UserId = dados[1];
        FN = dados[2];
        LN = dados[3];
        Sexo = dados[4];
        Email = dados[5];
        Telefone = dados[6];
        DDA = dados[7];
        JB = dados[8];
    }
}

public class LeitorDeArquivo
{
    // Método para ler o arquivo e retornar a lista de pessoas
    public static List<Pessoa> LerArquivoPessoas(string caminhoDoArquivo)
    {
        List<Pessoa> lista = new List<Pessoa>();

        try
        {
            using (FileStream entrada = File.OpenRead(caminhoDoArquivo))
            using (StreamReader leitor = new StreamReader(entrada))
            {
                string linha;

                Console.WriteLine("\nAguarde... Lendo o arquivo...");

                while ((linha = leitor.ReadLine()) != null)
                {
                    string[] linhaPessoa = linha.Split(',');
                    Pessoa pessoa = CriaPessoa(linhaPessoa);
                    lista.Add(pessoa);
                }
            }

            Console.WriteLine("Arquivo lido com sucesso!");
        }
        catch (Exception)
        {
            Console.WriteLine("\nERRO: Arquivo não existe");
        }

        return lista;
    }
    private static Pessoa CriaPessoa(string[] dados)
    {
        return new Pessoa(dados);
    }
}

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Qual arquivo você gostaria de abrir:");
        Console.WriteLine("1:arquivo com 100 pessoas");
        Console.WriteLine("2:arquivo com 1.000 pessoas");
        Console.WriteLine("3:arquivo com 10.000");
        Console.WriteLine("4:arquivo com 100.000");
        Console.WriteLine("5:arquivo com 500.000");
        Console.WriteLine("6:arquivo com 1.000.000");
        Console.WriteLine("7:arquivo com 5.000.000");
        int escolha = int.Parse(Console.ReadLine());

        if (escolha == 1)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 100 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);

            
            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 2)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 1.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);


            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 3)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 10.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);


            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 4)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 100.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);


            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 5)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 500.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);


            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 6)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 1.000.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);


            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 2.000.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);


            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
    }

        
        Console.Clear(); //Limpando a tela

        List<Pessoas> empresas = new List<Pessoas>();
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
                Pessoas cadastro = Pessoas.cadastroEmpresaManual(empresas.Count + 1);
                empresas.Add(cadastro);
                Console.WriteLine("Cadastro criado com sucesso!");
                Console.ReadKey();
                Console.Clear();
                break;

                case 2:
                Console.Clear();
                foreach (Pessoas info in empresas)
                    {
                        Console.WriteLine($"Nome da organização: {info.PessoasNome}");
                        Console.WriteLine($"ID da organização..: {info.PessoasID}");
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
