using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
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
                    Pessoa pessoa = ToString(linhaPessoa);
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
    private static Pessoa ToString(string[] dados)
    {
        return new Pessoa(dados);
    }
}


class program
{
    public static void Main(string[] args)
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

            Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
            Console.WriteLine("1:Sim");
            Console.WriteLine("2:Não");
            int opcao = int.Parse(Console.ReadLine());

            while (opcao == 1)
            {

                Console.Clear(); //Limpando a tela

                int Def = 0;
                do
                {
                    Console.WriteLine($"Escolha a mudança que deseja que seja feita na lista atual");
                    Console.WriteLine($"1 - Criar Cadastro");
                    Console.WriteLine($"2 - Remover Cadastro");
                    Console.WriteLine($"3 - Pesquisar cadastro");
                    Console.WriteLine($"4 - Mostrar Cadastros");
                    Console.WriteLine($"5 - Sair");

                    Console.Write("Opção: ");
                    Def = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (Def)
                    {
                        case 1: //Apenas para testes, não necessário para a versão final
                            Pessoa cadastro = new Pessoa(empresas.Count + 1);
                            listaDePessoas.Add(cadastro);
                            Console.WriteLine("Cadastro criado com sucesso!");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("digite o nome da pessoa que vc deseja excluir:");
                             string nome = Console.ReadLine();
                            foreach (var n in listaDePessoas)
                            {
                                listaDePessoas.Remove(n);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            break;

                        case 4:
                            Console.Clear();
                            foreach (Pessoa info in listaDePessoas)
                            {
                                Console.WriteLine($"Nome da organização: {info.Index},ID: {info.UserId},Nome{info.FN},sobrenome{info.LN},Sexo: {info.Sexo},Email:{info.Email},Telefone: {info.Telefone},Data de aniversario{info.DDA} e empresa onde trabalha{info.JB}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
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

                } while (Def != 5);


                Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
                opcao = int.Parse(Console.ReadLine());
            }

            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 2)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 1.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);

            Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
            Console.WriteLine("1:Sim");
            Console.WriteLine("2:Não");
            int opcao = int.Parse(Console.ReadLine());

            while (opcao == 1)
            {

                Console.Clear(); //Limpando a tela

                int Def = 0;
                do
                {
                    Console.WriteLine($"Escolha a mudança que deseja que seja feita na lista atual");
                    Console.WriteLine($"1 - Criar Cadastro");
                    Console.WriteLine($"2 - Remover Cadastro");
                    Console.WriteLine($"3 - Pesquisar cadastro");
                    Console.WriteLine($"4 - Mostrar Cadastros");
                    Console.WriteLine($"5 - Sair");

                    Console.Write("Opção: ");
                    Def = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (Def)
                    {
                        case 1: //Apenas para testes, não necessário para a versão final
                            Pessoa cadastro = new Pessoa(empresas.Count + 1);
                            listaDePessoas.Add(cadastro);
                            Console.WriteLine("Cadastro criado com sucesso!");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("digite o nome da pessoa que vc deseja excluir:");
                            string nome = Console.ReadLine();
                            foreach (var n in listaDePessoas)
                            {
                                listaDePessoas.Remove(n);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            break;

                        case 4:
                            Console.Clear();
                            foreach (Pessoa info in listaDePessoas)
                            {
                                Console.WriteLine($"Nome da organização: {info.Index},ID: {info.UserId},Nome{info.FN},sobrenome{info.LN},Sexo: {info.Sexo},Email:{info.Email},Telefone: {info.Telefone},Data de aniversario{info.DDA} e empresa onde trabalha{info.JB}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
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

                } while (Def != 5);


                Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
                opcao = int.Parse(Console.ReadLine());
            }

            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 3)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 10.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);

            Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
            Console.WriteLine("1:Sim");
            Console.WriteLine("2:Não");
            int opcao = int.Parse(Console.ReadLine());

            while (opcao == 1)
            {

                Console.Clear(); //Limpando a tela

                int Def = 0;
                do
                {
                    Console.WriteLine($"Escolha a mudança que deseja que seja feita na lista atual");
                    Console.WriteLine($"1 - Criar Cadastro");
                    Console.WriteLine($"2 - Remover Cadastro");
                    Console.WriteLine($"3 - Pesquisar cadastro");
                    Console.WriteLine($"4 - Mostrar Cadastros");
                    Console.WriteLine($"5 - Sair");

                    Console.Write("Opção: ");
                    Def = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (Def)
                    {
                        case 1: //Apenas para testes, não necessário para a versão final
                            Pessoa cadastro = new Pessoa(empresas.Count + 1);
                            listaDePessoas.Add(cadastro);
                            Console.WriteLine("Cadastro criado com sucesso!");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("digite o nome da pessoa que vc deseja excluir:");
                            string nome = Console.ReadLine();
                            foreach (var n in listaDePessoas)
                            {
                                listaDePessoas.Remove(n);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            break;

                        case 4:
                            Console.Clear();
                            foreach (Pessoa info in listaDePessoas)
                            {
                                Console.WriteLine($"Nome da organização: {info.Index},ID: {info.UserId},Nome{info.FN},sobrenome{info.LN},Sexo: {info.Sexo},Email:{info.Email},Telefone: {info.Telefone},Data de aniversario{info.DDA} e empresa onde trabalha{info.JB}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
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

                } while (Def != 5);


                Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
                opcao = int.Parse(Console.ReadLine());
            }

            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 4)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 100.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);

            Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
            Console.WriteLine("1:Sim");
            Console.WriteLine("2:Não");
            int opcao = int.Parse(Console.ReadLine());

            while (opcao == 1)
            {

                Console.Clear(); //Limpando a tela

                int Def = 0;
                do
                {
                    Console.WriteLine($"Escolha a mudança que deseja que seja feita na lista atual");
                    Console.WriteLine($"1 - Criar Cadastro");
                    Console.WriteLine($"2 - Remover Cadastro");
                    Console.WriteLine($"3 - Pesquisar cadastro");
                    Console.WriteLine($"4 - Mostrar Cadastros");
                    Console.WriteLine($"5 - Sair");

                    Console.Write("Opção: ");
                    Def = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (Def)
                    {
                        case 1: //Apenas para testes, não necessário para a versão final
                            Pessoa cadastro = new Pessoa(empresas.Count + 1);
                            listaDePessoas.Add(cadastro);
                            Console.WriteLine("Cadastro criado com sucesso!");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("digite o nome da pessoa que vc deseja excluir:");
                            string nome = Console.ReadLine();
                            foreach (var n in listaDePessoas)
                            {
                                listaDePessoas.Remove(n);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            break;

                        case 4:
                            Console.Clear();
                            foreach (Pessoa info in listaDePessoas)
                            {
                                Console.WriteLine($"Nome da organização: {info.Index},ID: {info.UserId},Nome{info.FN},sobrenome{info.LN},Sexo: {info.Sexo},Email:{info.Email},Telefone: {info.Telefone},Data de aniversario{info.DDA} e empresa onde trabalha{info.JB}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
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

                } while (Def != 5);


                Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
                opcao = int.Parse(Console.ReadLine());
            }

            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 5)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 500.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);

            Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
            Console.WriteLine("1:Sim");
            Console.WriteLine("2:Não");
            int opcao = int.Parse(Console.ReadLine());

            while (opcao == 1)
            {

                Console.Clear(); //Limpando a tela

                int Def = 0;
                do
                {
                    Console.WriteLine($"Escolha a mudança que deseja que seja feita na lista atual");
                    Console.WriteLine($"1 - Criar Cadastro");
                    Console.WriteLine($"2 - Remover Cadastro");
                    Console.WriteLine($"3 - Pesquisar cadastro");
                    Console.WriteLine($"4 - Mostrar Cadastros");
                    Console.WriteLine($"5 - Sair");

                    Console.Write("Opção: ");
                    Def = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (Def)
                    {
                        case 1: //Apenas para testes, não necessário para a versão final
                            Pessoa cadastro = new Pessoa(empresas.Count + 1);
                            listaDePessoas.Add(cadastro);
                            Console.WriteLine("Cadastro criado com sucesso!");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("digite o nome da pessoa que vc deseja excluir:");
                            string nome = Console.ReadLine();
                            foreach (var n in listaDePessoas)
                            {
                                listaDePessoas.Remove(n);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            break;

                        case 4:
                            Console.Clear();
                            foreach (Pessoa info in listaDePessoas)
                            {
                                Console.WriteLine($"Nome da organização: {info.Index},ID: {info.UserId},Nome{info.FN},sobrenome{info.LN},Sexo: {info.Sexo},Email:{info.Email},Telefone: {info.Telefone},Data de aniversario{info.DDA} e empresa onde trabalha{info.JB}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
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

                } while (Def != 5);


                Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
                opcao = int.Parse(Console.ReadLine());
            }

            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else if (escolha == 6)
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 1.000.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);

            Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
            Console.WriteLine("1:Sim");
            Console.WriteLine("2:Não");
            int opcao = int.Parse(Console.ReadLine());

            while (opcao == 1)
            {

                Console.Clear(); //Limpando a tela

                int Def = 0;
                do
                {
                    Console.WriteLine($"Escolha a mudança que deseja que seja feita na lista atual");
                    Console.WriteLine($"1 - Criar Cadastro");
                    Console.WriteLine($"2 - Remover Cadastro");
                    Console.WriteLine($"3 - Pesquisar cadastro");
                    Console.WriteLine($"4 - Mostrar Cadastros");
                    Console.WriteLine($"5 - Sair");

                    Console.Write("Opção: ");
                    Def = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (Def)
                    {
                        case 1: //Apenas para testes, não necessário para a versão final
                            Pessoa cadastro = new Pessoa(empresas.Count + 1);
                            listaDePessoas.Add(cadastro);
                            Console.WriteLine("Cadastro criado com sucesso!");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("digite o nome da pessoa que vc deseja excluir:");
                            string nome = Console.ReadLine();
                            foreach (var n in listaDePessoas)
                            {
                                listaDePessoas.Remove(n);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            break;

                        case 4:
                            Console.Clear();
                            foreach (Pessoa info in listaDePessoas)
                            {
                                Console.WriteLine($"Nome da organização: {info.Index},ID: {info.UserId},Nome{info.FN},sobrenome{info.LN},Sexo: {info.Sexo},Email:{info.Email},Telefone: {info.Telefone},Data de aniversario{info.DDA} e empresa onde trabalha{info.JB}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
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

                } while (Def != 5);


                Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
                opcao = int.Parse(Console.ReadLine());
            }

            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
        else
        {
            string caminhoDoArquivo = @"";//caminho do arquivo com 2.000.000 pessoas
            List<Pessoa> listaDePessoas = LeitorDeArquivo.LerArquivoPessoas(caminhoDoArquivo);

            Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
            Console.WriteLine("1:Sim");
            Console.WriteLine("2:Não");
            int opcao = int.Parse(Console.ReadLine());

            while (opcao == 1)
            {

                Console.Clear(); //Limpando a tela

                int Def = 0;
                do
                {
                    Console.WriteLine($"Escolha a mudança que deseja que seja feita na lista atual");
                    Console.WriteLine($"1 - Criar Cadastro");
                    Console.WriteLine($"2 - Remover Cadastro");
                    Console.WriteLine($"3 - Pesquisar cadastro");
                    Console.WriteLine($"4 - Mostrar Cadastros");
                    Console.WriteLine($"5 - Sair");

                    Console.Write("Opção: ");
                    Def = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (Def)
                    {
                        case 1: //Apenas para testes, não necessário para a versão final
                            Pessoa cadastro = new Pessoa(empresas.Count + 1);
                            listaDePessoas.Add(cadastro);
                            Console.WriteLine("Cadastro criado com sucesso!");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("digite o nome da pessoa que vc deseja excluir:");
                            string nome = Console.ReadLine();
                            foreach (var n in listaDePessoas)
                            {
                                listaDePessoas.Remove(n);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            break;

                        case 4:
                            Console.Clear();
                            foreach (Pessoa info in listaDePessoas)
                            {
                                Console.WriteLine($"Nome da organização: {info.Index},ID: {info.UserId},Nome{info.FN},sobrenome{info.LN},Sexo: {info.Sexo},Email:{info.Email},Telefone: {info.Telefone},Data de aniversario{info.DDA} e empresa onde trabalha{info.JB}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
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

                } while (Def != 5);


                Console.WriteLine("Deseja fazer algum tipo de alteração na lista");
                opcao = int.Parse(Console.ReadLine());
            }

            foreach (Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine($"index:{pessoa.Index},ID:{pessoa.UserId},primeiro nome:{pessoa.FN},segundo nome:{pessoa.LN},sexo:{pessoa.Sexo},email:{pessoa.Email},telefone:{pessoa.Telefone},Data de aniversario:{pessoa.DDA},emprego:{pessoa.JB}");
            }
        }
    }
} 

    
  
