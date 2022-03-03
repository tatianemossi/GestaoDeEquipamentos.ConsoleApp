using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menuDeOpcoes;
            int indiceDoEquipamento = 0;

            string[] listaNomeEquipamentos = new string[1000];
            decimal?[] listaPrecoEquipamentos = new decimal?[1000];
            string[] listaNumeroDeSerieEquipamentos = new string[1000];
            DateTime?[] listaDataDeFabricacaoEquipamentos = new DateTime?[1000];
            string[] listaFabricanteEquipamentos = new string[1000];

            string[] listaTitulosChamados = new string[1000];
            string[] listaDescricaoChamados = new string[1000];
            string[] listaEquipamentosChamados = new string[1000];
            DateTime?[] listaDataAberturaChamados = new DateTime?[1000];
            int indiceDoChamado = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Digite 1: para cadatrar um novo equipamento.\n" +
                    "Digite 2: Editar um produto do inventario\n" +
                    "Digite 3: Para Excluir um equipamento.\n" +
                    "Digite 4: Para visualizar o inventário de Equipamentos.\n" +
                    "Digite 5: Para gerenciar Chamados.\n" +
                    "Digite 6: Para encerrar");

                menuDeOpcoes = Console.ReadLine();

                switch (menuDeOpcoes)
                {
                    case "1":
                        indiceDoEquipamento = CriarEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaNumeroDeSerieEquipamentos, listaDataDeFabricacaoEquipamentos, listaFabricanteEquipamentos, indiceDoEquipamento);
                        break;

                    case "2":
                        EditarEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaNumeroDeSerieEquipamentos, listaDataDeFabricacaoEquipamentos, listaFabricanteEquipamentos);
                        break;

                    case "3":
                        ExcluirEquipamento(ref listaNomeEquipamentos, ref listaPrecoEquipamentos, ref listaNumeroDeSerieEquipamentos, ref listaDataDeFabricacaoEquipamentos, ref listaFabricanteEquipamentos);
                        break;

                    case "4":
                        VisualizarListaEquipamentos(listaNomeEquipamentos, listaNumeroDeSerieEquipamentos, listaFabricanteEquipamentos);
                        break;

                    case "5":
                        GerenciarChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentosChamados, listaNomeEquipamentos, listaDataAberturaChamados, indiceDoChamado);
                        break;

                    case "6":
                        break;
                }

            } while (menuDeOpcoes != "6");
        }

        static void GerenciarChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, DateTime?[] listaDataAberturaChamados, int indiceDoChamado)
        {
            string menuChamados;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Digite 1: para criar um chamado.\n" +
                    "Digite 2: para visualizar os chamados.\n" +
                    "Digite 3: Editar um chamado\n" +
                    "Digite 4: Para Excluir um chamado.\n" +
                    "Digite 5: Para encerrar.");

                menuChamados = Console.ReadLine();

                switch (menuChamados)
                {
                    case "1":
                        indiceDoChamado = CriarChamado(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaNomeEquipamentos, listaDataAberturaChamados, indiceDoChamado);
                        break;

                    case "2":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados);
                        break;

                    case "3":
                        EditarListaChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaNomeEquipamentos, listaDataAberturaChamados);
                        break;

                    case "4":
                        ExcluirListaChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaDataAberturaChamados);
                        break;

                    case "5":
                        break;
                }

            } while (menuChamados != "5");
        }

        static void ExcluirListaChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, DateTime?[] listaDataAberturaChamados)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o nome do chamado que será excluído: ");
            string chamadoParaExcluir = Console.ReadLine();

            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] == chamadoParaExcluir)
                {
                    listaTitulosChamados[i] = null;
                    listaDescricaoChamados[i] = null;
                    listaEquipamentoDoChamado[i] = null;
                    listaDataAberturaChamados[i] = null;
                }
            }
        }

        static void EditarListaChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, DateTime?[] listaDataAberturaChamados)
        {
            Console.WriteLine();
            Console.Write("Digite o título do Chamado que será editado: ");
            string chamadoAhSerAlterado = Console.ReadLine();

            var indiceDoChamado = BuscarIndiceChamado(listaTitulosChamados, chamadoAhSerAlterado);

            Console.WriteLine();
            Console.WriteLine("-Digite 1: Para editar o título do chamado\n" +
                    "-Digite 2: Para editar a descrição do chamado\n" +
                    "-Digite 3: Para editar o equipamento do chamado\n" +
                    "-Digite 4: Para editar a data de abertura do chamado\n" +
                    "-Digite 5: para encerrar a edição do equipamente.");
            string menuEdicao = Console.ReadLine();

            switch (menuEdicao)
            {
                case "1":
                    EditarPropriedadeChamado(listaTitulosChamados, Convert.ToInt32(indiceDoChamado), "título");
                    break;

                case "2":
                    EditarPropriedadeChamado(listaDescricaoChamados, Convert.ToInt32(indiceDoChamado), "descrição");
                    break;

                case "3":
                    EditarEquipamentoDoChamado(listaEquipamentoDoChamado, listaNomeEquipamentos, Convert.ToInt32(indiceDoChamado));
                    break;

                case "4":
                    EditarDataDeFabricacaoDoEquipamento(listaDataAberturaChamados, Convert.ToInt32(indiceDoChamado));
                    break;

                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }

        static void EditarEquipamentoDoChamado(string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, int indiceDoChamado)
        {
            bool equipamentoEncontrado = false;
            BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            while (equipamentoEncontrado == false)
            {
                Console.WriteLine("Nenhum equipamento com este nome foi encontrado.");
                BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            }
            Console.WriteLine();
        }

        static void VisualizarListaChamados(string[] listaTitulosChamados, string[] listaEquipamentoDoChamado, DateTime?[] listaDataAberturaChamados)
        {
            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] != null)
                {
                    var quantidadeDiasChamadoAberto = (DateTime.Now.Date - listaDataAberturaChamados[i].Value.Date).TotalDays;

                    Console.WriteLine($"Chamado: {listaTitulosChamados[i]} - Equipamento: {listaEquipamentoDoChamado[i]} - Data de Abertura do Chamado: {listaDataAberturaChamados[i]} - Dias Chamado em Aberto: {quantidadeDiasChamadoAberto}");
                    Console.WriteLine();
                }
            }
        }

        static int CriarChamado(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, DateTime?[] listaDataAberturaChamados, int indiceDoChamado)
        {
            Console.Write("Digite o título do Chamado:");
            string tituloDoChamado = Console.ReadLine();
            listaTitulosChamados[indiceDoChamado] = tituloDoChamado;
            Console.WriteLine();

            Console.Write("Digite a descrição do Chamado:");
            listaDescricaoChamados[indiceDoChamado] = Console.ReadLine();
            Console.WriteLine();

            bool equipamentoEncontrado;
            BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            while (equipamentoEncontrado == false)
            {
                Console.WriteLine("Nenhum equipamento com este nome foi encontrado.");
                BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            }
            Console.WriteLine();

            Console.Write("Digite a data de abertura do Chamado (formato: --/--/----):");
            listaDataAberturaChamados[indiceDoChamado] = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

            indiceDoChamado++;
            Console.WriteLine($"Chamado {indiceDoChamado} Registrado");

            return indiceDoChamado;
        }

        static void BuscarEValidarNomeEquipamento(string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, out bool equipamentoEncontrado, int indiceDoChamado)
        {
            Console.Write("Digite o nome do Equipamento que será atribuído ao chamado:");
            string nomeEquipamentoChamado = Console.ReadLine();
            equipamentoEncontrado = false;

            for (int i = 0; i < listaNomeEquipamentos.Length; i++)
            {
                if (listaNomeEquipamentos[i] == nomeEquipamentoChamado)
                {
                    listaEquipamentoDoChamado[indiceDoChamado] = nomeEquipamentoChamado;
                    equipamentoEncontrado = true;
                    break;
                }
            }
        }

        static void EditarPropriedadeChamado(string[] listaPropriedadeChamado, int indiceDoChamado, string nomePropriedade)
        {
            Console.WriteLine($"Digite o novo {nomePropriedade} do Chamado");
            string novaPropriedadeChamado = Console.ReadLine();

            listaPropriedadeChamado[indiceDoChamado] = novaPropriedadeChamado;
        }

        static int? BuscarIndiceChamado(string[] listaTitulosChamados, string chamadoAhSerAlterado)
        {
            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] == chamadoAhSerAlterado)
                {
                    return i;
                }
            }

            return null;
        }

        static void ExcluirEquipamento(ref string[] listaNomeDeEquipamentos, ref decimal?[] listaPrecoDeEquipamentos, ref string[] listaNumeroDeSerieDeEquipamentos, ref DateTime?[] listaDataDeFabricacaoDeEquipamentos, ref string[] listaFabricanteDeEquipamentos)
        {
            Console.WriteLine("Digite o nome do equipamento que será excluído: ");
            string equipamentoParaExcluir = Console.ReadLine();

            for (int i = 0; i < listaNomeDeEquipamentos.Length; i++)
            {
                if (listaNomeDeEquipamentos[i] == equipamentoParaExcluir)
                {
                    listaNomeDeEquipamentos[i] = null;
                    listaPrecoDeEquipamentos[i] = null;
                    listaNumeroDeSerieDeEquipamentos[i] = null;
                    listaDataDeFabricacaoDeEquipamentos[i] = null;
                    listaFabricanteDeEquipamentos[i] = null;
                }
            }
        }

        static void VisualizarListaEquipamentos(string[] listaNomeDoEquipamento, string[] listaNumeroDeSerieDeEquipamentos, string[] listaFabricanteDeEquipamentos)
        {
            for (int i = 0; i < listaNomeDoEquipamento.Length; i++)
            {
                if (listaNomeDoEquipamento[i] != null)
                {
                    Console.WriteLine($"Equipamento: {listaNomeDoEquipamento[i]} - Número de Série: {listaNumeroDeSerieDeEquipamentos[i]} - Fabricante: {listaFabricanteDeEquipamentos[i]}");
                    Console.WriteLine();
                }
            }
        }

        static void EditarEquipamento(string[] listaNomeDoEquipamento, decimal?[] listaPrecoDoEquipamento, string[] listaNumeroDeSerieDoEquipamento, DateTime?[] listaDataDeFabricacaoDoEquipamento, string[] listaFabricanteDoEquipamento)
        {
            Console.Write("Digite o nome do equipamento que sera editado: ");
            string equipamentoAhSerAlterado = Console.ReadLine();

            var indiceDoEquipamento = BuscarIndiceEquipamento(listaNomeDoEquipamento, equipamentoAhSerAlterado);

            Console.WriteLine();
            Console.WriteLine("-Digite 1: Para editar o nome do equipamento\n" +
                    "-Digite 2: Para editar o preço do equipamento\n" +
                    "-Digite 3: Para editar o numero de serie do equipamento\n" +
                    "-Digite 4: Para editar a data de fabricação do equipamento\n" +
                    "-Digite 5: Para editar o fabricante\n" +
                    "-Digite 6: para encerrar a edição do equipamente.");
            string menuEdicao = Console.ReadLine();

            switch (menuEdicao)
            {
                case "1":
                    EditarPropriedadeEquipamento(listaNomeDoEquipamento, Convert.ToInt32(indiceDoEquipamento), "nome");
                    break;

                case "2":
                    EditarPrecoEquipamento(listaPrecoDoEquipamento, Convert.ToInt32(indiceDoEquipamento));
                    break;

                case "3":
                    EditarPropriedadeEquipamento(listaNumeroDeSerieDoEquipamento, Convert.ToInt32(indiceDoEquipamento), "número de série");
                    break;

                case "4":
                    EditarDataDeFabricacaoDoEquipamento(listaDataDeFabricacaoDoEquipamento, Convert.ToInt32(indiceDoEquipamento));
                    break;

                case "5":
                    EditarPropriedadeEquipamento(listaFabricanteDoEquipamento, Convert.ToInt32(indiceDoEquipamento), "fabricante");
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }

        static void EditarDataDeFabricacaoDoEquipamento(DateTime?[] listaDataDeFabricacaoDoEquipamento, int indiceDoEquipamento)
        {
            Console.WriteLine("Digite a nova data de fabricação do Equipamento");
            DateTime novaDataDeFabricacao = Convert.ToDateTime(Console.ReadLine());

            listaDataDeFabricacaoDoEquipamento[indiceDoEquipamento] = novaDataDeFabricacao;
        }

        static void EditarPrecoEquipamento(decimal?[] listaPrecoDoEquipamento, int indiceDoEquipamento)
        {
            Console.WriteLine("Digite o novo preço do Equipamento");
            decimal novoPrecoDoEquipamento = Convert.ToDecimal(Console.ReadLine());

            listaPrecoDoEquipamento[indiceDoEquipamento] = novoPrecoDoEquipamento;
        }

        static void EditarPropriedadeEquipamento(string[] listaPropriedadeEquipamento, int indiceDoEquipamento, string nomePropriedade)
        {
            Console.WriteLine($"Digite o novo {nomePropriedade} do Equipamento");
            string novaPropriedadeEquipamento = Console.ReadLine();

            listaPropriedadeEquipamento[indiceDoEquipamento] = novaPropriedadeEquipamento;
        }

        static int? BuscarIndiceEquipamento(string[] nomeDoEquipamento, string equipamentoAhSerAlterado)
        {
            for (int i = 0; i < nomeDoEquipamento.Length; i++)
            {
                if (nomeDoEquipamento[i] == equipamentoAhSerAlterado)
                {
                    return i;
                }
            }

            return null;
        }

        static int CriarEquipamento(string[] listaNomeDoEquipamento, decimal?[] precoDoEquipamento, string[] numeroDeSerie, DateTime?[] dataDeFabricacao, string[] fabricante, int indiceDoEquipamento)
        {
            Console.Write("Digite o nome do Equipamento:");
            string nomeDoEquipamento = Console.ReadLine();
            while (nomeDoEquipamento.Length < 6)
            {
                Console.WriteLine("O nome do equipamento deve ter pelo menos 6 caracteres.");
                Console.Write("Digite o nome do Equipamento:");
                nomeDoEquipamento = Console.ReadLine();
            }
            listaNomeDoEquipamento[indiceDoEquipamento] = nomeDoEquipamento;
            Console.WriteLine();

            Console.Write("Digite o preço do Equipamento:");
            precoDoEquipamento[indiceDoEquipamento] = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o numero de série do Equipamento:");
            numeroDeSerie[indiceDoEquipamento] = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite a data de fabricação do Equipamento (formato: --/--/----):");
            dataDeFabricacao[indiceDoEquipamento] = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o nome do fabricante do Equipamento:");
            fabricante[indiceDoEquipamento] = Console.ReadLine();
            Console.WriteLine();

            indiceDoEquipamento++;
            Console.WriteLine($"Equipamento {indiceDoEquipamento} Registrado");

            return indiceDoEquipamento;

        }
    }
}
