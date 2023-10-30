using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20133_20144_ED
{
    /* 
     * Feito por: 
     * Frederico Scheffel Oliveira - RA: 20133
     * Lucas Coimbra da Silva      - RA: 20144
     */
    class Grafo
    {
        private const int NUM_VERTICES = 250;
        private Vertice[] vertices;
        private int[,] adjMatrix;
        private int[,] adjMatrixPreco; // Matriz responsável por mostrar o preço da trajetória
        // Na maior parte das vezes que adjMatrix é usado para pegar a distancia, se utiliza adjMatrixPreco pra pegar o preço

        public Vertice[] Vertices
        {
            get => vertices;
        }

        int numVerts;
        DataGridView dgv;   // para exibir a matriz de adjacência num formulário

        public int NumVerts
        {
            get => numVerts;
        }

        /// DJIKSTRA
        DistOriginal[] percurso;
        int infinity = 1000000;
        int verticeAtual;   // global usada para indicar o vértice atualmente sendo visitado 
        int doInicioAteAtual;   // global usada para ajustar menor caminho com Djikstra
        int precoInicialAteAtual; // global pra ver o preço
        int nTree;

        public Grafo()
        {
            this.dgv = null;
            vertices = new Vertice[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            adjMatrixPreco = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            nTree = 0;

            for (int j = 0; j < NUM_VERTICES; j++)      // zera toda a matriz
                for (int k = 0; k < NUM_VERTICES; k++)
                    adjMatrix[j, k] = infinity; // distância tão grande que não existe

            percurso = new DistOriginal[NUM_VERTICES];
        }

        /*public Grafo(DataGridView dgv)
        {
            this.dgv = dgv;
            vertices = new Vertice[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            nTree = 0;

            for (int j = 0; j < NUM_VERTICES; j++)      // zera toda a matriz
                for (int k = 0; k < NUM_VERTICES; k++)
                    adjMatrix[j, k] = infinity; // distância tão grande que não existe

            percurso = new DistOriginal[NUM_VERTICES];
        }*/

        public void NovoVertice(string label)
        {
            vertices[numVerts] = new Vertice(label);
            numVerts++;
            if (dgv != null)  // se foi passado como parâmetro um dataGridView para exibição
            {              // se realiza o seu ajuste para a quantidade de vértices
                dgv.RowCount = numVerts + 1;
                dgv.ColumnCount = numVerts + 1;
                dgv.Columns[numVerts].Width = 45;
            }
        }

        public void NovaAresta(int origem, int destino)
        {
            adjMatrix[origem, destino] = 1;
        }

        public void NovaAresta(string origem, string destino, int distancia, int preco)
        {
            int posicaoInicial = -1; // -1 pois esse valor é o retornado ao não existir
            int posicaoFinal = -1;

            for (int i = 0; i < numVerts; i++)
            {
                // Compara se a origem do parametro é a mesma do rótulo retornando 0 se forem iguais
                if (vertices[i].Rotulo.CompareTo(origem) == 0)
                    posicaoInicial = i;
                // Compara se o destino do parametro é o mesmo do rótulo retornando 0 se forem iguais
                if (vertices[i].Rotulo.CompareTo(destino) == 0)
                    posicaoFinal = i;
                // Se as duas posições não forem encontradas sai do for
                if (posicaoInicial != -1 && posicaoFinal != -1)
                    break;
            }
            if (posicaoInicial == -1 || posicaoFinal == -1)
                throw new Exception("Origem ou destino inexistentes");

            // Armazena distancia e preço nas respectivas variáveis
            adjMatrix[posicaoInicial, posicaoFinal] = distancia;
            adjMatrixPreco[posicaoInicial, posicaoFinal] = preco;

        }

        public void ExibirVertice(int v)
        {
            Console.Write(vertices[v].Rotulo + " ");
        }

        public void ExibirVertice(int v, TextBox txt)
        {
            txt.Text += vertices[v].Rotulo + " ";
        }

        public int SemSucessores()  // encontra e retorna a linha de um vértice sem sucessores
        {
            bool temAresta;
            for (int linha = 0; linha < numVerts; linha++)
            {
                temAresta = false;
                for (int col = 0; col < numVerts; col++)
                    if (adjMatrix[linha, col] != infinity)
                    {
                        temAresta = true;
                        break;
                    }
                if (!temAresta)
                    return linha;
            }
            return -1;
        }

        public void RemoverVertice(string rotulo)
        {
            int posicao = PesquisarPosicao(rotulo);

            if (posicao == -1)
                throw new Exception("O rótulo inserido não foi encontrado.");

            RemoverVertice(posicao);
        }

        public void RemoverVertice(int vert)
        {
            if (dgv != null)
            {
                MessageBox.Show("Matriz de Adjacências antes de remover vértice " +
                              Convert.ToString(vert));
                ExibirAdjacencias();
            }
            if (vert != numVerts - 1)
            {
                for (int j = vert; j < numVerts - 1; j++)   // remove vértice do vetor
                    vertices[j] = vertices[j + 1];

                for (int cont = 0; cont < numVerts; cont++)
                {
                    // Atribui infinity ao remover o vertice
                    adjMatrix[vert, cont] = infinity;
                    adjMatrix[cont, vert] = infinity;
                    adjMatrixPreco[vert, cont] = 0;
                    adjMatrixPreco[cont, vert] = 0;
                }


                // remove vértice da matriz
                for (int row = vert; row < numVerts; row++)
                    moverLinhas(row, numVerts - 1);
                for (int col = vert; col < numVerts; col++)
                    moverColunas(col, numVerts - 1);
            }
            numVerts--;
            if (dgv != null)
            {
                MessageBox.Show("Matriz de Adjacências após remover vértice " +
                       Convert.ToString(vert));
                ExibirAdjacencias();
                MessageBox.Show("Retornando à ordenação");
            }
        }
        private void moverLinhas(int row, int length)
        {
            if (row != numVerts - 1)
                for (int col = 0; col <= length; col++)
                {
                    adjMatrix[row, col] = adjMatrix[row + 1, col];  // desloca para excluir
                    adjMatrix[row + 1, col] = infinity;  // Infinity para evitar que ao adicionar uma cidade que foi deletada
                                                         // não criar caminhos aleatórios no grafo
                    adjMatrixPreco[row, col] = adjMatrixPreco[row + 1, col];  // desloca para excluir
                    adjMatrixPreco[row + 1, col] = 0;
                }
        }
        private void moverColunas(int col, int length)
        {
            if (col != numVerts - 1)
                for (int row = 0; row <= length; row++)
                {
                    adjMatrix[row, col] = adjMatrix[row, col + 1]; // desloca para excluir
                    adjMatrix[row, col + 1] = infinity; // Infinity para evitar que ao adicionar uma cidade que foi deletada
                                                        // não criar caminhos aleatórios no grafo
                    adjMatrixPreco[row, col] = adjMatrixPreco[row, col + 1]; // desloca para excluir
                    adjMatrixPreco[row, col + 1] = 0;
                }
        }
        public void ExibirAdjacencias()
        {
            dgv.RowCount = numVerts + 1;
            dgv.ColumnCount = numVerts + 1;
            for (int j = 0; j < numVerts; j++)
            {
                dgv[0, j + 1].Value = vertices[j].Rotulo;
                dgv[j + 1, 0].Value = vertices[j].Rotulo;
                for (int k = 0; k < numVerts; k++)
                {
                    if (adjMatrix[j, k] != infinity)
                    {
                        dgv[k + 1, j + 1].Style.BackColor = System.Drawing.Color.Yellow;
                        dgv[k + 1, j + 1].Value = Convert.ToString(adjMatrix[j, k]);
                    }
                    else
                    {
                        dgv[k + 1, j + 1].Value = "";
                        dgv[k + 1, j + 1].Style.BackColor = System.Drawing.Color.White;
                    }

                }
            }
        }

        public String OrdenacaoTopologica()
        {
            if (dgv != null)
                ExibirAdjacencias();
            Stack<String> gPilha = new Stack<String>(); // para guardar a sequência de vértices
            int origVerts = numVerts;
            while (numVerts > 0)
            {
                int currVertex = SemSucessores();
                if (currVertex == -1)
                    return "Erro: grafo possui ciclos.";
                gPilha.Push(vertices[currVertex].Rotulo);   // empilha vértice
                RemoverVertice(currVertex);
            }
            String resultado = "Sequência da Ordenação Topológica: ";
            while (gPilha.Count > 0)
                resultado += gPilha.Pop() + " ";    // desempilha para exibir
            return resultado;
        }

        private int ObterVerticeAdjacenteNaoVisitado(int v)
        {
            for (int j = 0; j <= numVerts - 1; j++)
                if ((adjMatrix[v, j] != infinity) && (!vertices[j].FoiVisitado))
                    return j;
            return -1;
        }

        public void PercursoEmProfundidade(TextBox txt)
        {
            txt.Clear();
            Stack<int> gPilha = new Stack<int>(); // para guardar a sequência de vértices
            for (int j = 0; j <= numVerts - 1; j++)
                vertices[j].FoiVisitado = false;
            vertices[0].FoiVisitado = true;
            ExibirVertice(0, txt);
            gPilha.Push(0);
            int v;
            while (gPilha.Count > 0)
            {
                v = ObterVerticeAdjacenteNaoVisitado(gPilha.Peek());
                if (v == -1)
                    gPilha.Pop();
                else
                {
                    vertices[v].FoiVisitado = true;
                    ExibirVertice(v, txt);
                    gPilha.Push(v);
                }
            }
            for (int j = 0; j <= numVerts - 1; j++)
                vertices[j].FoiVisitado = false;
        }

        void ProcessarNo(int i, TextBox txt)
        {
            txt.Text += vertices[i].Rotulo;
        }

        public void PercursoEmProfundidadeRec(int[,] adjMatrix, int numVerts, int part, TextBox txt)
        {
            int i;
            ProcessarNo(part, txt);
            vertices[part].FoiVisitado = true;
            for (i = 0; i < numVerts; ++i)
                if (adjMatrix[part, i] != infinity && !vertices[i].FoiVisitado)
                    PercursoEmProfundidadeRec(adjMatrix, numVerts, i, txt);
        }

        public void percursoPorLargura(TextBox txt)
        {
            txt.Clear();
            Queue<int> gQueue = new Queue<int>();
            vertices[0].FoiVisitado = true;
            ExibirVertice(0, txt);
            gQueue.Enqueue(0);
            int vert1, vert2;
            while (gQueue.Count > 0)
            {
                vert1 = gQueue.Dequeue();
                vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
                while (vert2 != -1)
                {
                    vertices[vert2].FoiVisitado = true;
                    ExibirVertice(vert2, txt);
                    gQueue.Enqueue(vert2);
                    vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
                }
            }
            for (int i = 0; i < numVerts; i++)
                vertices[i].FoiVisitado = false;
        }

        public void ArvoreGeradoraMinima(int primeiro, TextBox txt)
        {
            txt.Clear();
            Stack<int> gPilha = new Stack<int>(); // para guardar a sequência de vértices
            vertices[primeiro].FoiVisitado = true;
            gPilha.Push(primeiro);
            int currVertex, ver;
            while (gPilha.Count > 0)
            {
                currVertex = gPilha.Peek();
                ver = ObterVerticeAdjacenteNaoVisitado(currVertex);
                if (ver == -1)
                    gPilha.Pop();
                else
                {
                    vertices[ver].FoiVisitado = true;
                    gPilha.Push(ver);
                    ExibirVertice(currVertex, txt);
                    txt.Text += "-->";
                    ExibirVertice(ver, txt);
                    txt.Text += "  ";
                }
            }
            for (int j = 0; j <= numVerts - 1; j++)
                vertices[j].FoiVisitado = false;
        }

        public string Caminho(string origem, string destino)
        {
            int inicioDoPercurso = -1; // -1 pois é o valor caso nao exista um inicio ou fim ao percurso
            int finalDoPercurso = -1;

            for (int i = 0; i < numVerts; i++)
            {
                // Compara origem com o rótulo, retornando 0 caso isso ocorra
                if (vertices[i].Rotulo.CompareTo(origem) == 0)
                    inicioDoPercurso = i;
                // Compara destino com o rótulo, retornando 0 caso isso ocorra
                if (vertices[i].Rotulo.CompareTo(destino) == 0)
                    finalDoPercurso = i;
                // Se as duas posições não forem encontradas sai do for
                if (inicioDoPercurso != -1 && finalDoPercurso != -1)
                    break;
            }
            if (inicioDoPercurso == -1 || finalDoPercurso == -1)
                throw new Exception("Origem ou Destino inexistentes!");

            for (int j = 0; j < numVerts; j++)
                vertices[j].FoiVisitado = false;

            vertices[inicioDoPercurso].FoiVisitado = true;
            for (int j = 0; j < numVerts; j++)
            {
                // anotamos no vetor percurso a distância entre o inicioDoPercurso e cada vértice
                // se não há ligação direta, o valor da distância será infinity
                int tempDist = adjMatrix[inicioDoPercurso, j];
                int tempPreco = adjMatrixPreco[inicioDoPercurso, j];
                percurso[j] = new DistOriginal(inicioDoPercurso, tempDist, tempPreco);
            }

            for (int nTree = 0; nTree < numVerts; nTree++)
            {
                // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
                int indiceDoMenor = ObterMenor();

                // o vértice com a menor distância passa a ser o vértice atual
                // para compararmos com a distância calculada em AjustarMenorCaminho()
                verticeAtual = indiceDoMenor;
                doInicioAteAtual = percurso[indiceDoMenor].distancia;
                precoInicialAteAtual = percurso[indiceDoMenor].preco;

                // visitamos o vértice com a menor distância desde o inicioDoPercurso
                vertices[verticeAtual].FoiVisitado = true;
                AjustarMenorCaminho();
            }

            return ExibirPercursos(inicioDoPercurso, finalDoPercurso);
        }

        public int ObterMenor()
        {
            int distanciaMinima = infinity;
            int indiceDaMinima = 0;
            for (int j = 0; j < numVerts; j++)
                if (!(vertices[j].FoiVisitado) && (percurso[j].distancia < distanciaMinima))
                {
                    distanciaMinima = percurso[j].distancia;
                    indiceDaMinima = j;
                }
            return indiceDaMinima;
        }

        public void AjustarMenorCaminho()
        {
            for (int coluna = 0; coluna < numVerts; coluna++)
                if (!vertices[coluna].FoiVisitado)       // para cada vértice ainda não visitado
                {
                    // acessamos a distância desde o vértice atual (pode ser infinity)
                    int atualAteMargem = adjMatrix[verticeAtual, coluna];
                    int atualAteMargemPreco = adjMatrixPreco[verticeAtual, coluna];

                    // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                    // esta saída
                    int doInicioAteMargem = doInicioAteAtual + atualAteMargem;
                    int doInicioAteMargemPreco = precoInicialAteAtual + atualAteMargemPreco;

                    // quando encontra uma distância menor, marca o vértice a partir do
                    // qual chegamos no vértice de índice coluna, e a soma da distância
                    // percorrida para nele chegar
                    int distanciaDoCaminho = percurso[coluna].distancia;
                    if (doInicioAteMargem < distanciaDoCaminho)
                    {
                        percurso[coluna].verticePai = verticeAtual;
                        percurso[coluna].distancia = doInicioAteMargem;
                        percurso[coluna].preco = doInicioAteMargemPreco;
                        //ExibirTabela(lista);
                    }
                }
            //lista.Items.Add("==================Caminho ajustado==============");
        }

        /*public void ExibirTabela(ListBox lista)
        {
            string dist = "";
            lista.Items.Add("Vértice\tVisitado?\tPeso\tVindo de");
            for (int i = 0; i < numVerts; i++)
            {
                if (percurso[i].distancia == infinity)
                    dist = "inf";
                else
                    dist = Convert.ToString(percurso[i].distancia);

                lista.Items.Add(vertices[i].Rotulo + "\t" + vertices[i].FoiVisitado +
                      "\t\t" + dist + "\t" + vertices[percurso[i].verticePai].Rotulo);
            }
            lista.Items.Add("-----------------------------------------------------");
        }*/

        public string ExibirPercursos(int inicioDoPercurso, int finalDoPercurso)
        {
            ResetarSelecionados();

            string linha = "", resultado = "";
            for (int j = 0; j < numVerts; j++)
            {
                linha += vertices[j].Rotulo + "=";
                if (percurso[j].distancia == infinity)
                    linha += "inf";
                else
                    linha += percurso[j].distancia;
                string pai = vertices[percurso[j].verticePai].Rotulo;
                linha += "(" + pai + ") ";
            }
            /*lista.Items.Add(linha);
            lista.Items.Add("");
            lista.Items.Add("");
            lista.Items.Add("Caminho entre " + vertices[inicioDoPercurso].Rotulo +
                                       " e " + vertices[finalDoPercurso].Rotulo);
            lista.Items.Add("");*/

            int onde = finalDoPercurso;
            Stack<string> pilha = new Stack<string>();
            // Pega distancia e preco que será mostrado no TextBox
            int distancia = percurso[onde].distancia;
            int preco = percurso[onde].preco;
            int cont = 0;
            while (onde != inicioDoPercurso)
            {
                onde = percurso[onde].verticePai;
                vertices[onde].EstaSelecionado = true;
                pilha.Push(vertices[onde].Rotulo);
                cont++;
            }

            while (pilha.Count != 0)
            {
                resultado += pilha.Pop();
                if (pilha.Count != 0)
                    resultado += " --> ";
            }

            // Retorna no TextBox "não há caminho caso a distancia no fim seja Infinity
            if ((cont == 1) && (percurso[finalDoPercurso].distancia == infinity))
                resultado = "Não há caminho";
            else              
                resultado += " --> " + vertices[finalDoPercurso].Rotulo + Environment.NewLine
                + "Distância --> " + distancia + "Km" + Environment.NewLine + quantoTempo(distancia) + Environment.NewLine +
                "Preço: " + preco + "R$";

            vertices[finalDoPercurso].EstaSelecionado = true;

            return resultado;
        }

        // Calcula o tempo de viagem passando distancia como parametro e admitindo uma velocidade de 200km/h
        private string quantoTempo(int distancia)
        {
            int tempoHoras = 0;
            int tempoMinutos = 0;
            double x;
            string tempoTotal = "";
            // velocidade de 200km/h
            int velocidade = 200;

            // Pega o valor inteiro da divisao para ser as horas
            tempoHoras = distancia / velocidade;
            // Concatena com tempoTotal
            tempoTotal += tempoHoras + " horas e ";
            // Pega o resto da divisao e faz uma regra de três para descobrir os minutos concatenando com tempoTotal
            tempoMinutos = distancia % velocidade;
            tempoMinutos = (tempoMinutos * 60) / velocidade;
            tempoTotal += tempoMinutos + " minutos";

            // Retorna a string com o tempo, que é utilizada no resultado do ExibirCaminhos()
            return "Tempo: " + tempoTotal;
        }

        private int PesquisarPosicao(String rotulo) // Pesquisa a posição do vertice com esse rotulo no vetor vertices
        {
            for (int ret = numVerts - 1; ret >= 0; ret--)
            {
                if (vertices[ret].Rotulo == rotulo)
                    return ret;
            }

            return -1; // Não foi encontrado
        }

        // Verifica se os rótulos passados como parametro se conectam
        public bool SeConectam(String rotulo1, String rotulo2)
        {
            int localRotulo1 = PesquisarPosicao(rotulo1),
            localRotulo2 = PesquisarPosicao(rotulo2);

            if (localRotulo1 < 0 || localRotulo2 < 0)
                throw new Exception("Rotulo inserido não foi encontrado");

            return adjMatrix[localRotulo1, localRotulo2] != infinity || adjMatrix[localRotulo2, localRotulo1] != infinity;
        }

        // Verifica se o rotulo foi selecionado
        public bool isSelecionado(String rotulo)
        {
            int localRotulo = PesquisarPosicao(rotulo);

             if (localRotulo < 0)
                throw new Exception("Rotulo inserido não foi encontrado");
            
            return vertices[localRotulo].EstaSelecionado;
        }

        public byte SeConectamESaoSelecionados(String rotulo1, String rotulo2) // Evita gasto de memória pesquisando 2 vezes
        {
            int localRotulo1 = PesquisarPosicao(rotulo1);
            int localRotulo2 = PesquisarPosicao(rotulo2);

            if (localRotulo1 < 0 || localRotulo2 < 0)
                throw new Exception("Rotulo inserido não foi encontrado");

            if (adjMatrix[localRotulo1, localRotulo2] != infinity || adjMatrix[localRotulo2, localRotulo1] != infinity)
            {
                if (vertices[localRotulo1].EstaSelecionado && vertices[localRotulo2].EstaSelecionado)
                    return 2;

                return 1;
            }

            return 0;
            // Se se conectam e estão selecionados retorna 2. Se só estão conectados retorna 1. Se não retorna 0
        }

        public void ResetarSelecionados()
        {
            // Atribui estaSelcionado False para todos os vertices que tiverem True
            for (int i = numVerts - 1; i >= 0; i--)
                if (vertices[i].EstaSelecionado)
                    vertices[i].EstaSelecionado = false;
        }


        // Seleciona um vertice pelo rotulo passado como parametro
        public void SelecionarVertice(string rotulo)
        {
            int localRotulo = PesquisarPosicao(rotulo);

            if (localRotulo == -1)
                throw new Exception("Não foi encontrado nenhum vértice com esse nome");

            vertices[localRotulo].EstaSelecionado = true;
        }

        // Salva no arquivo passado como parametro todas as conexoes do grafo, fechando o arquivo no fim para evitar erros
        public void Salvar (StreamWriter arquivo)
        {
            if (arquivo == null)
                throw new Exception("Arquivo inexistente");

            for (int i = 0; i < numVerts; i++)
                for (int cont = i + 1; cont < numVerts; cont++)
                    if (cont != i && adjMatrix[i, cont] != infinity || adjMatrix[cont, i] != infinity)
                        arquivo.WriteLine(vertices[i].Rotulo.PadRight(15, ' ') + vertices[cont].Rotulo.PadRight(15, ' ')
                        + adjMatrix[cont, i].ToString().PadLeft(4, ' ') + adjMatrixPreco[cont, i].ToString().PadLeft(5, ' '));
            arquivo.Close();
        }
    }
}
