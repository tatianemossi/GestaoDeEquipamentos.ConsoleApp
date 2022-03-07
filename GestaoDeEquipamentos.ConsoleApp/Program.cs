using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        const string AbertoConst = "Aberto";
        const string FechadoConst = "Fechado";
        static void Main(string[] args)
        {
            string menuDeOpcoes;

            string[] listaNomeEquipamentos = new string[1000];
            decimal?[] listaPrecoEquipamentos = new decimal?[1000];
            string[] listaNumeroDeSerieEquipamentos = new string[1000];
            DateTime?[] listaDataDeFabricacaoEquipamentos = new DateTime?[1000];
            string[] listaFabricanteEquipamentos = new string[1000];
            int indiceDoEquipamento = 0;

            string[] listaTitulosChamados = new string[1000];
            string[] listaDescricaoChamados = new string[1000];
            string[] listaEquipamentosChamados = new string[1000];
            string[] listaSolicitantesChamados = new string[1000];
            DateTime?[] listaDataAberturaChamados = new DateTime?[1000];
            string[] listaStatusChamados = new string[1000];
            int indiceDoChamado = 0;

            string[] listaNomeSolicitante = new string[1000];
            string[] listaEmailSolicitante = new string[1000];
            string[] listaTelefoneSolicitante = new string[1000];
            int indiceDoSolicitante = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Digite 1: Para cadastrar um novo equipamento.\n" +
                    "Digite 2: Editar um produto do inventario\n" +
                    "Digite 3: Para Excluir um equipamento.\n" +
                    "Digite 4: Para visualizar o inventário de Equipamentos.\n" +
                    "Digite 5: Para gerenciar Chamados.\n" +
                    "Digite 6: Para gerenciar Solicitante.\n" +
                    "Digite 7: Para verificar equipamento com mais problema.\n" +
                    "Digite 8: Para encerrar");

                menuDeOpcoes = Console.ReadLine();

                switch (menuDeOpcoes)
                {
                    case "1":
                        indiceDoEquipamento = CriarEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaNumeroDeSerieEquipamentos,
                            listaDataDeFabricacaoEquipamentos, listaFabricanteEquipamentos, indiceDoEquipamento);
                        break;

                    case "2":
                        VisualizarListaEquipamentos(listaNomeEquipamentos, listaNumeroDeSerieEquipamentos, listaFabricanteEquipamentos);
                        EditarEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaNumeroDeSerieEquipamentos, listaDataDeFabricacaoEquipamentos, listaFabricanteEquipamentos);
                        break;

                    case "3":
                        VisualizarListaEquipamentos(listaNomeEquipamentos, listaNumeroDeSerieEquipamentos, listaFabricanteEquipamentos);
                        ExcluirEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaNumeroDeSerieEquipamentos,
                            listaDataDeFabricacaoEquipamentos, listaFabricanteEquipamentos, listaEquipamentosChamados);
                        break;

                    case "4":
                        VisualizarListaEquipamentos(listaNomeEquipamentos, listaNumeroDeSerieEquipamentos, listaFabricanteEquipamentos);
                        break;

                    case "5":
                        GerenciarChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentosChamados, listaNomeEquipamentos,
                            listaNomeSolicitante, listaSolicitantesChamados, listaDataAberturaChamados, indiceDoChamado, listaStatusChamados);
                        break;

                    case "6":
                        GerenciarSolicitante(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante, indiceDoSolicitante);
                        break;

                    case "7":
                        VerificarEquipamentoMaisProblema(listaEquipamentosChamados);
                        break;

                    case "8":
                        break;
                }

            } while (menuDeOpcoes != "8");
        }        

        #region Solicitantes
        static void GerenciarSolicitante(string[] listaNomeSolicitante, string[] listaEmailSolicitante, string[] listaTelefoneSolicitante, int indiceDoSolicitante)
        {
            string menuSolicitante;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Digite 1: Para cadastrar um solicitante.\n" +
                    "Digite 2: Para visualizar os solicitantes.\n" +
                    "Digite 3: Editar Solicitante\n" +
                    "Digite 4: Para Excluir Solicitante.\n" +
                    "Digite 5: Para encerrar.");

                menuSolicitante = Console.ReadLine();

                switch (menuSolicitante)
                {
                    case "1":
                        indiceDoSolicitante = CriarSolicitante(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante, indiceDoSolicitante);
                        break;

                    case "2":
                        VisualizarListaSolicitantes(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante, indiceDoSolicitante);
                        break;

                    case "3":
                        VisualizarListaSolicitantes(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante, indiceDoSolicitante);
                        EditarListaSolicitantes(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante);
                        break;

                    case "4":
                        VisualizarListaSolicitantes(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante, indiceDoSolicitante);
                        ExcluirListaSolicitantes(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante, indiceDoSolicitante);
                        break;

                    case "5":
                        break;
                }

            } while (menuSolicitante != "5");
            Console.Clear();
        }

        static void ExcluirListaSolicitantes(string[] listaNomeSolicitante, string[] listaEmailSolicitante, string[] listaTelefoneSolicitante, int indiceDoSolicitante)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o Nome do Solicitante que será excluído: ");
            VisualizarListaSolicitantes(listaNomeSolicitante, listaEmailSolicitante, listaTelefoneSolicitante, indiceDoSolicitante);
            string solicitanteParaExcluir = Console.ReadLine();

            for (int i = 0; i < listaNomeSolicitante.Length; i++)
            {
                if (listaNomeSolicitante[i] == solicitanteParaExcluir)
                {
                    listaNomeSolicitante[i] = null;
                    listaEmailSolicitante[i] = null;
                    listaTelefoneSolicitante[i] = null;
                }
            }
            Console.Clear();
        }

        static void EditarListaSolicitantes(string[] listaNomeSolicitante, string[] listaEmailSolicitante, string[] listaTelefoneSolicitante)
        {
            Console.WriteLine();
            Console.Write("Digite o Nome do Solicitante que será editado: ");
            string solicitanteAhSerAlterado = Console.ReadLine();

            var indiceDoSolicitante = BuscarIndiceSolicitante(listaNomeSolicitante, solicitanteAhSerAlterado);

            Console.WriteLine();
            Console.WriteLine("-Digite 1: Para editar o Nome do Solicitante\n" +
                    "-Digite 2: Para editar E-mail do Solicitante\n" +
                    "-Digite 3: Para editar o Telefone do Solicitante\n" +
                    "-Digite 4: para encerrar a edição do equipamente.");
            string menuEdicao = Console.ReadLine();

            switch (menuEdicao)
            {
                case "1":
                    EditarPropriedadeSolicitante(listaNomeSolicitante, Convert.ToInt32(indiceDoSolicitante), "Nome");
                    break;

                case "2":
                    EditarPropriedadeSolicitante(listaEmailSolicitante, Convert.ToInt32(indiceDoSolicitante), "E-mail");
                    break;

                case "3":
                    EditarPropriedadeSolicitante(listaTelefoneSolicitante, Convert.ToInt32(indiceDoSolicitante), "E-mail");
                    break;

                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
            Console.Clear();
        }

        static void EditarPropriedadeSolicitante(string[] listaPropriedadeSolicitante, int indiceDoSolicitante, string nomePropriedade)
        {
            Console.WriteLine();
            Console.WriteLine($"Digite o novo {nomePropriedade} do Solicitante");
            string novaPropriedadeSolicitante = Console.ReadLine();

            listaPropriedadeSolicitante[indiceDoSolicitante] = novaPropriedadeSolicitante;
            Console.Clear();
        }

        static void VisualizarListaSolicitantes(string[] listaNomeSolicitante, string[] listaEmailSolicitante, string[] listaTelefoneSolicitante, int indiceDoSolicitante)
        {
            for (int i = 0; i < listaNomeSolicitante.Length; i++)
            {
                if (listaNomeSolicitante[i] != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id: {indiceDoSolicitante} - Solicitante: {listaNomeSolicitante[i]} - E-mail: {listaEmailSolicitante[i]} - Telefone: {listaTelefoneSolicitante[i]}");
                    Console.WriteLine();
                }
            }
        }

        static int CriarSolicitante(string[] listaNomeSolicitante, string[] listaEmailSolicitante, string[] listaTelefoneSolicitante, int indiceDoSolicitante)
        {
            Console.WriteLine();
            VerificaEPreencheNomeSolicitante(listaNomeSolicitante, indiceDoSolicitante);

            Console.WriteLine();
            VerificaEPreencheEmailSolicitante(listaEmailSolicitante, indiceDoSolicitante);

            Console.WriteLine();
            VerificaEPreencheTelefoneSolicitante(listaTelefoneSolicitante, indiceDoSolicitante);

            indiceDoSolicitante++;
            Console.Clear();
            Console.WriteLine($"Solicitante {indiceDoSolicitante} Registrado");

            return indiceDoSolicitante;
        }

        static void VerificaEPreencheTelefoneSolicitante(string[] listaTelefoneSolicitante, int indiceDoSolicitante)
        {
            Console.Write("Digite o Telefone do Solicitante (Deve possuir 9 dígitos):");
            string telefoneDoSolicitante = Console.ReadLine();
            while (telefoneDoSolicitante.Length < 9)
            {
                Console.WriteLine("O Telefone do Solicitante deve ter pelo menos 9 dígitos.");
                Console.Write("Digite o Telefone do Solicitante (Deve possuir 9 dígitos):");
                telefoneDoSolicitante = Console.ReadLine();
            }
            while (telefoneDoSolicitante.Length > 9)
            {
                Console.WriteLine("O Telefone do Solicitante deve somente 9 dígitos.");
                Console.Write("Digite o Telefone do Solicitante (Deve possuir 9 dígitos):");
                telefoneDoSolicitante = Console.ReadLine();
            }

            listaTelefoneSolicitante[indiceDoSolicitante] = telefoneDoSolicitante;
        }

        static void VerificaEPreencheEmailSolicitante(string[] listaEmailSolicitante, int indiceDoSolicitante)
        {
            Console.Write("Digite o Email do Solicitante:");
            string emailDigitado = Console.ReadLine();
            while (emailDigitado == "")
            {
                Console.WriteLine("O número de série do Equipamento é obrigatório.");
                Console.Write("Digite o numero de série do Equipamento:");
                emailDigitado = Console.ReadLine();
            }
            listaEmailSolicitante[indiceDoSolicitante] = emailDigitado;
        }

        static void VerificaEPreencheNomeSolicitante(string[] listaNomeSolicitante, int indiceDoSolicitante)
        {
            Console.Write("Digite o Nome do Solicitante:");
            string nomeDoSolicitante = Console.ReadLine();
            while (nomeDoSolicitante.Length < 6)
            {
                Console.WriteLine("O Nome do Solicitante deve ter pelo menos 6 caracteres.");
                Console.Write("Digite o nome do Equipamento:");
                nomeDoSolicitante = Console.ReadLine();
            }
            listaNomeSolicitante[indiceDoSolicitante] = nomeDoSolicitante;
        }

        static int? BuscarIndiceSolicitante(string[] listaNomeSolicitante, string solicitanteAhSerAlterado)
        {
            for (int i = 0; i < listaNomeSolicitante.Length; i++)
            {
                if (listaNomeSolicitante[i] == solicitanteAhSerAlterado)
                {
                    return i;
                }
            }

            return null;
        }
        #endregion

        #region Chamados
        static void GerenciarChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos,
            string[] listaNomeSolicitantes, string[] listaSolicitanteDoChamado, DateTime?[] listaDataAberturaChamados, int indiceDoChamado, string[] listaStatusChamados)
        {
            string menuChamados;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Digite 1: Para Abrir um chamado.\n" +
                    "Digite 2: Para visualizar os chamados.\n" +
                    "Digite 3: Para visualizar os chamados agrupados.\n" +
                    "Digite 4: Editar um chamado\n" +
                    "Digite 5: Fechar um chamado\n" +
                    "Digite 6: Para Excluir um chamado.\n" +
                    "Digite 7: Para encerrar.");

                menuChamados = Console.ReadLine();


                switch (menuChamados)
                {
                    case "1":
                        indiceDoChamado = AbrirChamado(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaNomeEquipamentos,
                            listaNomeSolicitantes, listaSolicitanteDoChamado, listaDataAberturaChamados, indiceDoChamado, listaStatusChamados);
                        break;

                    case "2":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados, listaSolicitanteDoChamado);
                        break;

                    case "3":
                        VisualizarListaChamadosAgrupados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados, listaSolicitanteDoChamado, listaStatusChamados);
                        break;

                    case "4":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados, listaSolicitanteDoChamado);
                        EditarListaChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaNomeEquipamentos,
                            listaDataAberturaChamados, listaNomeSolicitantes, listaSolicitanteDoChamado);
                        break;

                    case "5":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados, listaSolicitanteDoChamado);
                        FecharChamado(listaTitulosChamados, listaStatusChamados);
                        break;

                    case "6":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados, listaSolicitanteDoChamado);
                        ExcluirListaChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaDataAberturaChamados, listaStatusChamados);
                        break;

                    case "7":
                        break;
                }

            } while (menuChamados != "7");
            Console.Clear();
        }

        static void VisualizarListaChamadosAgrupados(string[] listaTitulosChamados, string[] listaEquipamentoDoChamado, DateTime?[] listaDataAberturaChamados, string[] listaSolicitanteDoChamado, string[] listaStatusChamados)
        {
            string[] listaChamadosAbertos = new string[1000];
            string[] listaChamadosFechados = new string[1000];

            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] != null)
                {
                    string textoDoChamado = $"Chamado: {listaTitulosChamados[i]} - Equipamento: {listaEquipamentoDoChamado[i]} - Data de Abertura do Chamado: {listaDataAberturaChamados[i]} - Solicitante: {listaSolicitanteDoChamado[i]}";

                    if (listaStatusChamados[i] == AbertoConst)
                    {
                        listaChamadosAbertos[i] = textoDoChamado;
                    }
                    else
                    {
                        listaChamadosFechados[i] = textoDoChamado;
                    }
                }
            }
            Console.WriteLine("Chamados Abertos:");
            for (int i = 0; i < listaChamadosAbertos.Length; i++)
            {
                if (listaChamadosAbertos[i] != null)
                {
                    Console.WriteLine(listaChamadosAbertos[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Chamados Fechados:");
            for (int i = 0; i < listaChamadosFechados.Length; i++)
            {
                if (listaChamadosFechados[i] != null)
                {
                    Console.WriteLine(listaChamadosFechados[i]);
                }
            }
        }

        static void FecharChamado(string[] listaTitulosChamados, string[] listaStatusChamados)
        {
            Console.WriteLine();
            Console.Write("Digite o título do Chamado que será Fechado: ");
            string chamadoAhSerAlterado = Console.ReadLine();

            var indiceDoChamado = BuscarIndiceChamado(listaTitulosChamados, chamadoAhSerAlterado);
            if (indiceDoChamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }

            listaStatusChamados[Convert.ToInt32(indiceDoChamado)] = FechadoConst;
        }

        static void ExcluirListaChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, DateTime?[] listaDataAberturaChamados, string[] listaStatusChamados)
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
                    listaStatusChamados[i] = null;
                }
            }
        }

        static void EditarListaChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado,
            string[] listaNomeEquipamentos, DateTime?[] listaDataAberturaChamados, string[] listaNomeSolicitantes, string[] listaSolicitanteDoChamado)
        {
            Console.WriteLine();
            Console.Write("Digite o título do Chamado que será editado: ");
            string chamadoAhSerAlterado = Console.ReadLine();

            var indiceDoChamado = BuscarIndiceChamado(listaTitulosChamados, chamadoAhSerAlterado);
            if (indiceDoChamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-Digite 1: Para editar o título do chamado\n" +
                        "-Digite 2: Para editar a descrição do chamado\n" +
                        "-Digite 3: Para editar o equipamento do chamado\n" +
                        "-Digite 4: Para editar o solicitante do chamado\n" +
                        "-Digite 5: Para editar a data de abertura do chamado\n" +
                        "-Digite 6: para encerrar a edição do equipamente.");
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
                        EditarSolicitanteDoChamado(listaSolicitanteDoChamado, listaNomeSolicitantes, Convert.ToInt32(indiceDoChamado));
                        break;

                    case "5":
                        EditarDataDeFabricacaoDoEquipamento(listaDataAberturaChamados, Convert.ToInt32(indiceDoChamado));
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                Console.Clear();
            }
        }

        static void EditarSolicitanteDoChamado(string[] listaSolicitanteDoChamado, string[] listaNomeSolicitantes, int indiceDoChamado)
        {
            bool solicitanteEncontrado = false;
            BuscarEValidarSolicitanteChamado(listaSolicitanteDoChamado, listaNomeSolicitantes, out solicitanteEncontrado, indiceDoChamado);

            while (solicitanteEncontrado == false)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhum solicitante com este nome foi encontrado.");
                BuscarEValidarSolicitanteChamado(listaSolicitanteDoChamado, listaNomeSolicitantes, out solicitanteEncontrado, indiceDoChamado);
            }
            Console.WriteLine();
            Console.Clear();
        }

        static void EditarEquipamentoDoChamado(string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, int indiceDoChamado)
        {
            bool equipamentoEncontrado = false;
            BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);

            while (equipamentoEncontrado == false)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhum equipamento com este nome foi encontrado.");
                BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            }
            Console.WriteLine();
            Console.Clear();
        }

        static void VisualizarListaChamados(string[] listaTitulosChamados, string[] listaEquipamentoDoChamado, DateTime?[] listaDataAberturaChamados, string[] listaSolicitanteDoChamado)
        {
            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] != null)
                {
                    var quantidadeDiasChamadoAberto = (DateTime.Now.Date - listaDataAberturaChamados[i].Value.Date).TotalDays;

                    Console.WriteLine();
                    Console.WriteLine($"Chamado: {listaTitulosChamados[i]} - Equipamento: {listaEquipamentoDoChamado[i]} - Data de Abertura do Chamado: {listaDataAberturaChamados[i]} - Dias Chamado em Aberto: {quantidadeDiasChamadoAberto} - Solicitante: {listaSolicitanteDoChamado[i]}");
                    Console.WriteLine();
                }
            }
        }

        static int AbrirChamado(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos,
            string[] listaNomeSolicitante, string[] listaSolicitanteDoChamado, DateTime?[] listaDataAberturaChamados, int indiceDoChamado, string[] listaStatusChamados)
        {
            bool jaExisteEquipamentoLista = VerificarSeExisteEquipamentoLista(listaNomeEquipamentos);
            if (jaExisteEquipamentoLista == false)
            {
                Console.WriteLine("Não é possível criar um chamado, pois ainda não existem equipamentos na lista.");
                return indiceDoChamado;
            }

            bool jaExisteSolicitanteLista = VerificarSeExisteSolicitanteLista(listaNomeSolicitante);
            if (jaExisteSolicitanteLista == false)
            {
                Console.WriteLine("Não é possível criar um chamado, pois ainda não existem solicitantes na lista.");
                return indiceDoChamado;
            }

            VerificaEPreencheTituloDoChamado(listaTitulosChamados, indiceDoChamado);

            VerificaEPreencheDescricaoDoChamado(listaDescricaoChamados, indiceDoChamado);

            bool equipamentoEncontrado;
            BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            while (equipamentoEncontrado == false)
            {
                Console.WriteLine("Nenhum equipamento com este nome foi encontrado.");
                BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            }

            Console.WriteLine();
            bool solicitanteEncontrado;
            BuscarEValidarSolicitanteChamado(listaSolicitanteDoChamado, listaNomeSolicitante, out solicitanteEncontrado, indiceDoChamado);
            while (solicitanteEncontrado == false)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhum solicitante com este nome foi encontrado.");
                BuscarEValidarSolicitanteChamado(listaSolicitanteDoChamado, listaNomeSolicitante, out solicitanteEncontrado, indiceDoChamado);
            }

            Console.WriteLine();
            VerificaEPreencheDataDeAberturaChamado(listaDataAberturaChamados, indiceDoChamado);

            listaStatusChamados[indiceDoChamado] = AbertoConst;

            indiceDoChamado++;
            Console.WriteLine($"Chamado {indiceDoChamado} Registrado");
            Console.Clear();

            return indiceDoChamado;
        }

        static bool VerificarSeExisteSolicitanteLista(string[] listaNomeSolicitante)
        {
            for (int i = 0; i < listaNomeSolicitante.Length; i++)
            {
                if (listaNomeSolicitante[i] != null)
                {
                    return true;
                }
            }
            return false;
        }

        static void BuscarEValidarSolicitanteChamado(string[] listaSolicitanteDoChamado, string[] listaNomeSolicitante, out bool solicitanteEncontrado, int indiceDoChamado)
        {
            Console.Write("Digite o nome do Solicitante que será atribuído ao chamado:");
            string nomeSolicitanteChamado = Console.ReadLine();
            solicitanteEncontrado = false;

            for (int i = 0; i < listaNomeSolicitante.Length; i++)
            {
                if (listaNomeSolicitante[i] == nomeSolicitanteChamado)
                {
                    listaSolicitanteDoChamado[indiceDoChamado] = nomeSolicitanteChamado;
                    solicitanteEncontrado = true;
                    break;
                }
            }
        }

        static void VerificaEPreencheDataDeAberturaChamado(DateTime?[] listaDataAberturaChamados, int indiceDoChamado)
        {
            Console.Write("Digite a data de Abertura do Chamado (formato: --/--/----):");
            string dataDeAberturaDigitada = Console.ReadLine();

            DateTime dataConvertida;
            while (!DateTime.TryParse(dataDeAberturaDigitada, out dataConvertida))
            {
                Console.WriteLine("Insira uma data de fabricação válida.");
                Console.Write("Digite a data de fabricação do Equipamento (formato: --/--/----):");
                dataDeAberturaDigitada = Console.ReadLine();
            }

            listaDataAberturaChamados[indiceDoChamado] = dataConvertida;
        }

        static bool VerificarSeExisteEquipamentoLista(string[] listaNomeEquipamentos)
        {
            for (int i = 0; i < listaNomeEquipamentos.Length; i++)
            {
                if (listaNomeEquipamentos[i] != null)
                {
                    return true;
                }
            }
            return false;
        }

        static void VerificaEPreencheDescricaoDoChamado(string[] listaDescricaoChamados, int indiceDoChamado)
        {
            Console.Write("Digite a descrição do Chamado:");
            string descricaoChamado = Console.ReadLine();

            while (descricaoChamado == "")
            {
                Console.WriteLine("A descrição do Chamado é obrigatória.");
                Console.Write("Digite a descrição do Chamado::");
                descricaoChamado = Console.ReadLine();
            }

            listaDescricaoChamados[indiceDoChamado] = descricaoChamado;
            Console.WriteLine();
        }

        static void VerificaEPreencheTituloDoChamado(string[] listaTitulosChamados, int indiceDoChamado)
        {
            Console.Write("Digite o título do Chamado:");
            string tituloDoChamado = Console.ReadLine();
            while (tituloDoChamado == "")
            {
                Console.WriteLine("O título do Chamado é obrigatório.");
                Console.Write("Digite o título do Chamado:");
                tituloDoChamado = Console.ReadLine();
            }
            listaTitulosChamados[indiceDoChamado] = tituloDoChamado;
            Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine($"Digite o novo {nomePropriedade} do Chamado");
            string novaPropriedadeChamado = Console.ReadLine();

            listaPropriedadeChamado[indiceDoChamado] = novaPropriedadeChamado;
            Console.Clear();
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
        #endregion

        #region Equipamentos
        static void VerificarEquipamentoMaisProblema(string[] listaEquipamentosChamados)
        {
            string[] listaEquipamentosComProblema = new string[1000];
            
            for (int i = 0; i < listaEquipamentosChamados.Length; i++)
            {
                var equipamentoComProblema = listaEquipamentosChamados[i];
                if (equipamentoComProblema != null)
                {
                    var indiceEquipamentoComProblema = 0;
                    var equipamentoJaExiste = VerificaSeEquipamentoComProblemaJaExiste(listaEquipamentosComProblema, equipamentoComProblema, ref indiceEquipamentoComProblema);
                    if (equipamentoJaExiste)
                    {
                        int qtdRepeticao = Convert.ToInt32(listaEquipamentosComProblema[indiceEquipamentoComProblema].Split(',')[0]);
                        qtdRepeticao++;
                        listaEquipamentosComProblema[indiceEquipamentoComProblema] = $"{qtdRepeticao},{equipamentoComProblema}";
                    }
                    else
                    {
                        indiceEquipamentoComProblema = BuscarUltimoIndiceEquipamentoComProblema(listaEquipamentosComProblema);
                        listaEquipamentosComProblema[indiceEquipamentoComProblema] = $"1,{equipamentoComProblema}";
                    }
                }                
            }

            Array.Sort(listaEquipamentosComProblema);
            Array.Reverse(listaEquipamentosComProblema);

            for (int i = 0; i < listaEquipamentosComProblema.Length; i++)
            {
                if (listaEquipamentosComProblema[i] != null)
                {
                    var quantidade = Convert.ToInt32(listaEquipamentosComProblema[i].Split(",")[0]);
                    var equipamento = listaEquipamentosComProblema[i].Split(",")[1];                    
                    Console.WriteLine($"Foram abertos {quantidade} chamados para o equipamento {equipamento}.");
                }
            }
        }

        static int BuscarUltimoIndiceEquipamentoComProblema(string[] listaEquipamentosComProblema)
        {
            for (int j = 0; j < listaEquipamentosComProblema.Length; j++)
            {
                if (listaEquipamentosComProblema[j] == null)
                {
                    return j;
                }
            }

            return 0;
        }

        static bool VerificaSeEquipamentoComProblemaJaExiste(string[] listaEquipamentosComProblema, string equipamentoComProblema, ref int indiceEquipamentoComProblema)
        {
            for (int j = 0; j < listaEquipamentosComProblema.Length; j++)
            {
                if (listaEquipamentosComProblema[j] == null)
                {
                    return false;
                }
                if (listaEquipamentosComProblema[j].EndsWith(equipamentoComProblema))
                {
                    indiceEquipamentoComProblema = j;
                    return true;                    
                }                
            }

            return false;
        }

        static void ExcluirEquipamento(string[] listaNomeDeEquipamentos, decimal?[] listaPrecoDeEquipamentos, string[] listaNumeroDeSerieDeEquipamentos,
            DateTime?[] listaDataDeFabricacaoDeEquipamentos, string[] listaFabricanteDeEquipamentos, string[] listaEquipamentosChamados)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o nome do equipamento que será excluído: ");
            string equipamentoParaExcluir = Console.ReadLine();

            var indiceDoEquipamento = BuscarIndiceEquipamento(listaNomeDeEquipamentos, equipamentoParaExcluir);
            if (indiceDoEquipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            bool equipamentoEstaVinculadoChamado = VerificaSeEquipamentoVinculadoAoChamado(listaEquipamentosChamados, equipamentoParaExcluir);
            if (equipamentoEstaVinculadoChamado)
            {
                Console.WriteLine("O equipamento não pode ser excluído, pois está vinculado a um chamado aberto.");
                return;
            }
            else
            {
                listaNomeDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaPrecoDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaNumeroDeSerieDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaDataDeFabricacaoDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaFabricanteDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;

                Console.WriteLine($"Equipamento excluído.");
            }

        }

        static bool VerificaSeEquipamentoVinculadoAoChamado(string[] listaEquipamentosChamados, string equipamentoParaExcluir)
        {
            for (int i = 0; i < listaEquipamentosChamados.Length; i++)
            {
                if (equipamentoParaExcluir == listaEquipamentosChamados[i])
                {
                    Console.WriteLine("Este equipamento não pode ser excluído, pois possui um chamado aberto.");
                    return true;
                }
            }
            return false;
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

        static void EditarEquipamento(string[] listaNomeDoEquipamento, decimal?[] listaPrecoDoEquipamento, string[] listaNumeroDeSerieDoEquipamento,
            DateTime?[] listaDataDeFabricacaoDoEquipamento, string[] listaFabricanteDoEquipamento)
        {
            Console.WriteLine();
            Console.Write("Digite o nome do equipamento que sera editado: ");
            string equipamentoAhSerAlterado = Console.ReadLine();

            var indiceDoEquipamento = BuscarIndiceEquipamento(listaNomeDoEquipamento, equipamentoAhSerAlterado);
            if (indiceDoEquipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }
            else
            {
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
                Console.Clear();
            }
        }

        static void EditarDataDeFabricacaoDoEquipamento(DateTime?[] listaDataDeFabricacaoDoEquipamento, int indiceDoEquipamento)
        {
            Console.WriteLine();
            Console.WriteLine("Digite a nova data de fabricação do Equipamento");
            DateTime novaDataDeFabricacao = Convert.ToDateTime(Console.ReadLine());

            listaDataDeFabricacaoDoEquipamento[indiceDoEquipamento] = novaDataDeFabricacao;
            Console.Clear();
        }

        static void EditarPrecoEquipamento(decimal?[] listaPrecoDoEquipamento, int indiceDoEquipamento)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o novo preço do Equipamento");
            decimal novoPrecoDoEquipamento = Convert.ToDecimal(Console.ReadLine());

            listaPrecoDoEquipamento[indiceDoEquipamento] = novoPrecoDoEquipamento;
            Console.Clear();
        }

        static void EditarPropriedadeEquipamento(string[] listaPropriedadeEquipamento, int indiceDoEquipamento, string nomePropriedade)
        {
            Console.WriteLine();
            Console.WriteLine($"Digite o novo {nomePropriedade} do Equipamento");
            string novaPropriedadeEquipamento = Console.ReadLine();

            listaPropriedadeEquipamento[indiceDoEquipamento] = novaPropriedadeEquipamento;
            Console.Clear();
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

        static int CriarEquipamento(string[] listaNomeDoEquipamento, decimal?[] listaPrecoDoEquipamento, string[] listaNumeroDeSerie,
            DateTime?[] listaDataDeFabricacao, string[] listaFabricante, int indiceDoEquipamento)
        {
            VerificaEPreencheNomeEquipamento(listaNomeDoEquipamento, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreenchePrecoEquipamento(listaPrecoDoEquipamento, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreencheNumeroDeSerieEquipamento(listaNumeroDeSerie, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreencheDataDeFabricacaoEquipamento(listaDataDeFabricacao, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreencheFabricanteEquipamento(listaFabricante, indiceDoEquipamento);
            Console.WriteLine();

            indiceDoEquipamento++;
            Console.Clear();
            Console.WriteLine($"Equipamento {indiceDoEquipamento} Registrado");

            return indiceDoEquipamento;
        }

        static void VerificaEPreencheFabricanteEquipamento(string[] listaFabricante, int indiceDoEquipamento)
        {
            Console.Write("Digite o nome do fabricante do Equipamento:");
            string fabricanteDigitado = Console.ReadLine();
            while (fabricanteDigitado == "")
            {
                Console.WriteLine("O fabricante do Equipamento é obrigatório.");
                Console.Write("Digite o nome do fabricante do Equipamento:");
                fabricanteDigitado = Console.ReadLine();
            }
            listaFabricante[indiceDoEquipamento] = fabricanteDigitado;
        }

        static void VerificaEPreencheDataDeFabricacaoEquipamento(DateTime?[] listaDataDeFabricacao, int indiceDoEquipamento)
        {
            Console.Write("Digite a data de fabricação do Equipamento (formato: --/--/----):");
            string dataDigitada = Console.ReadLine();

            DateTime dataConvertida;
            while (!DateTime.TryParse(dataDigitada, out dataConvertida))
            {
                Console.WriteLine("Insira uma data de fabricação válida.");
                Console.Write("Digite a data de fabricação do Equipamento (formato: --/--/----):");
                dataDigitada = Console.ReadLine();
            }

            listaDataDeFabricacao[indiceDoEquipamento] = dataConvertida;
        }

        static void VerificaEPreencheNumeroDeSerieEquipamento(string[] listaNumeroDeSerie, int indiceDoEquipamento)
        {
            Console.Write("Digite o número de série do Equipamento:");
            string numeroDeSerieDigitado = Console.ReadLine();
            while (numeroDeSerieDigitado == "")
            {
                Console.WriteLine("O número de série do Equipamento é obrigatório.");
                Console.Write("Digite o numero de série do Equipamento:");
                numeroDeSerieDigitado = Console.ReadLine();
            }

            bool numeroDeSerieJaExiste = VerificarSeNumeroDeSerieJaExiste(listaNumeroDeSerie, numeroDeSerieDigitado);

            while (numeroDeSerieJaExiste)
            {
                Console.WriteLine("O número de Série já existe, por favor, digite outro número.");
                Console.Write("Digite o numero de série do Equipamento:");
                numeroDeSerieDigitado = Console.ReadLine();
                numeroDeSerieJaExiste = VerificarSeNumeroDeSerieJaExiste(listaNumeroDeSerie, numeroDeSerieDigitado);
            }
            listaNumeroDeSerie[indiceDoEquipamento] = numeroDeSerieDigitado;
        }

        static void VerificaEPreenchePrecoEquipamento(decimal?[] listaPrecoDoEquipamento, int indiceDoEquipamento)
        {
            Console.Write("Digite o preço do Equipamento:");
            listaPrecoDoEquipamento[indiceDoEquipamento] = Convert.ToDecimal(Console.ReadLine());
            while (listaPrecoDoEquipamento[indiceDoEquipamento] == 0)
            {
                Console.WriteLine("O preço do equipamento não pode ser Zero.");
                Console.Write("Digite o preço do Equipamento:");
                listaPrecoDoEquipamento[indiceDoEquipamento] = Convert.ToDecimal(Console.ReadLine());
            }
            while (listaPrecoDoEquipamento[indiceDoEquipamento] < 0)
            {
                Console.WriteLine("O preço do equipamento não pode ser um número negativo.");
                Console.Write("Digite o preço do Equipamento:");
                listaPrecoDoEquipamento[indiceDoEquipamento] = Convert.ToDecimal(Console.ReadLine());
            }
        }

        static void VerificaEPreencheNomeEquipamento(string[] listaNomeDoEquipamento, int indiceDoEquipamento)
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
        }

        static bool VerificarSeNumeroDeSerieJaExiste(string[] listaNumeroDeSerie, string numeroDeSerieDigitado)
        {
            for (int i = 0; i < listaNumeroDeSerie.Length; i++)
            {
                if (listaNumeroDeSerie[i] == numeroDeSerieDigitado)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
