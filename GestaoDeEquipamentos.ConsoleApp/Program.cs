using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menuDeOpcoes;
            string menuEdicao = "";
            int indiceDoEquipamento = 0;

            //Criação do Equipamento:
            string[] nomeDoEquipamento = new string[1000];
            decimal[] precoDoEquipamento = new decimal[1000];
            string[] numeroDeSerie = new string[1000];
            string[] dataDeFabricacao = new string[1000];
            string[] fabricante = new string[1000];


            do
            {
                Console.WriteLine("-Digite 1: para cadatrar um novo equipamento.\n" +
                    "-Digite 2: Editar um produto do inventario\n" +
                    "-Digite 3: Para Excluir um equipamento.\n" +
                    "-Digite 4: Para encerrar.");

                menuDeOpcoes = Console.ReadLine();

                #region Adicionar novo Equipamento:

                if (menuDeOpcoes == "1")
                {
                    CriarEquipamento(nomeDoEquipamento, precoDoEquipamento, numeroDeSerie, dataDeFabricacao, fabricante, indiceDoEquipamento);
                }
                Console.WriteLine(indiceDoEquipamento);
                Console.WriteLine($"{nomeDoEquipamento[0]} - {precoDoEquipamento[0]} - {numeroDeSerie[0]} - {dataDeFabricacao[0]} - {fabricante[0]}");

                #endregion

                #region Editar Equipamento:
                if (menuDeOpcoes == "2")
                {
                    Console.Write("Digite o nome do equipamento que sera editado: ");
                    string edicaoDeEquipamento = Console.ReadLine();

                    if (edicaoDeEquipamento == menuDeOpcoes)
                    {
                        Console.WriteLine("-Digite 1: Para editar o nome do equipamento\n" +
                            "-Digite 2: Para editar o preço do equipamento\n" +
                            "-Digite 3: Para editar o numero de serie do equipamento\n" +
                            "-Digite 4: Para editar a data de fabricação do equipamento\n" +
                            "-Digite 5: Para editar o fabricante\n" +
                            "-Digite 6: para encerrar a edição do equipamente.");
                        do
                        {
                            if (menuEdicao == "1")

                            {
                                AlterarNomeEquipamento(nomeDoEquipamento);                                
                            }
                            else if (menuEdicao == "2")
                            {

                            }
                            else if (menuEdicao == "3")
                            {

                            }
                            else if (menuEdicao == "4")
                            {

                            }
                            else if (menuEdicao == "5")
                            {

                            }

                        } while (menuEdicao != "6");
                    }
                }
                #endregion

                #region Excluir Equipamento:

                if (menuDeOpcoes == "3")
                {
                    Console.WriteLine("Digite o nome do equipamento que será excluído: ");
                    string equipamentoParaRemover = Console.ReadLine();
                    RemoverEquipamento(ref nomeDoEquipamento, equipamentoParaRemover);                    
                }
                #endregion

            } while (menuDeOpcoes != "4");

        }

        static void AlterarNomeEquipamento(string[] nomeDoEquipamento)
        {
            string novoNomeDoEquipamento;
            string equipamentoAhSerAlterado;

            Console.WriteLine("Digite o nome do equipamento que será alterado: ");
            equipamentoAhSerAlterado = Console.ReadLine();

            for (int i = 0; i < nomeDoEquipamento.Length; i++)
            {
                if (nomeDoEquipamento[i] == equipamentoAhSerAlterado)
                {
                    Console.WriteLine("Digite o novo nome do Equipamento: ");
                    novoNomeDoEquipamento = Console.ReadLine();
                    nomeDoEquipamento[i] = novoNomeDoEquipamento;
                }
            }
        }

        static void RemoverEquipamento(ref string[] nomeDoEquipamento, string equipamentoParaRemover)
        {
            int qtdParaRemover = 0;

            for (int i = 0; i < nomeDoEquipamento.Length; i++)
            {
                if (nomeDoEquipamento[i] == equipamentoParaRemover)
                    qtdParaRemover++;
            }

            //criar um novo array subtraindo a quantidade de ocorrencias do equipamento desejado
            string[] novaListaNomeEquipamentos = new string[nomeDoEquipamento.Length - qtdParaRemover];
            int j = 0;
            for (int i = 0; i < nomeDoEquipamento.Length; i++)
            {
                if (nomeDoEquipamento[i] != equipamentoParaRemover)
                {
                    novaListaNomeEquipamentos[j] = nomeDoEquipamento[i];
                    j++;
                }
            }
        }

        static void CriarEquipamento(string[] nomeDoEquipamento, decimal[] precoDoEquipamento, string[] numeroDeSerie, string[] dataDeFabricacao, string[] fabricante, int indiceDoEquipamento)
        {
            //nome do Equipamento:

            Console.Write("-Digite o nome do Equipamento:");
            nomeDoEquipamento[indiceDoEquipamento] = Console.ReadLine();
            Console.WriteLine();

            //Preço do Equipamento:

            Console.Write("-Digite o preço do Equipamento:");
            precoDoEquipamento[indiceDoEquipamento] = decimal.Parse(Console.ReadLine());
            Console.WriteLine();

            //O numero de serie do equipamento:

            Console.Write("-Digite o numero de série do Equipamento:");
            numeroDeSerie[indiceDoEquipamento] = Console.ReadLine();
            Console.WriteLine();

            //A data de fabricação:

            Console.Write("-Digite a data de fabricação do Equipamento:");
            dataDeFabricacao[indiceDoEquipamento] = Console.ReadLine();
            Console.WriteLine();

            //O nome do fabricante;

            Console.Write("-Digite o nome do fabricante do Equipamento:");
            fabricante[indiceDoEquipamento] = Console.ReadLine();
            Console.WriteLine();

            indiceDoEquipamento++;
        }

    }
}
