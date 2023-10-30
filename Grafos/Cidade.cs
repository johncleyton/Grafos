using System;
using System.Collections.Generic;
using System.Drawing;
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
    class Cidade
    {

        Grafo grafoCidades;
        ArvoreDeBusca<InfoCidade> arvoreCidades;
        InfoCidade[] vetor;

        public Cidade(StreamReader arquivoCidades, StreamReader arquivoCaminhos)
        {
            grafoCidades = new Grafo();
            arvoreCidades = new ArvoreDeBusca<InfoCidade>();
            vetor = new InfoCidade[250];
            int qtdVetor = 0;

            // Formação da árvore com a leitura do arquivo "arquivoCidades"
            while (!arquivoCidades.EndOfStream)
            {
                string linha = arquivoCidades.ReadLine();
                grafoCidades.NovoVertice(linha.Substring(0, 15).TrimEnd(' '));

                InfoCidade info = new InfoCidade(linha.Substring(0, 15).TrimEnd(' '), float.Parse(linha.Substring(16, 5)), float.Parse(linha.Substring(22, 5)));
                vetor[qtdVetor++] = info;
            }

            arquivoCidades.Close();

            InfoCidade[] vetorOrganizado = new InfoCidade[250];

            for (int i = qtdVetor - 1; i >= 0; i--)
            {
                InfoCidade infoAtual = vetor[i];
                int quantosMaior = 0;

                for (int cont = qtdVetor - 1; cont >= 0; cont--)
                {
                    if (infoAtual.CompareTo(vetor[cont]) > 0)
                        quantosMaior++;
                }

                vetorOrganizado[quantosMaior] = infoAtual;
            }

            arvoreCidades.Adicionar(vetorOrganizado, 0, qtdVetor - 1);

            // Formação do Grafo com a leitura do arquivo "arquivoCaminhos"
            while (!arquivoCaminhos.EndOfStream)
            {
                string caminho = arquivoCaminhos.ReadLine();
                // Como é de guia dupla, cidade 1 liga com cidade 2 e vice versa
                grafoCidades.NovaAresta(caminho.Substring(0, 15).TrimEnd(' '), caminho.Substring(15, 15).TrimEnd(' '),
                    int.Parse(caminho.Substring(30, 4)), int.Parse(caminho.Substring(34, 5)));
                grafoCidades.NovaAresta(caminho.Substring(15, 15).TrimEnd(' '), caminho.Substring(0, 15).TrimEnd(' '),
                    int.Parse(caminho.Substring(30, 4)), int.Parse(caminho.Substring(34, 5)));
            }
            arquivoCaminhos.Close();
        }

        // Retorna informações da cidade inseriada
        public InfoCidade InfoDaCidade(string cidade)
        {
            NoArvore<InfoCidade> atual = arvoreCidades.Raiz;


            while (atual != null) // Loop de pesquisa
            {
                int compareTo = cidade.CompareTo(atual.Info.NomeCidade);

                if (compareTo == 0)
                    break; // Se achou para o loop
                else if (compareTo > 0)
                    atual = atual.Dir;
                else
                    atual = atual.Esq;
            }

            if (atual == null)
                throw new Exception("A cidade não existe");

            return atual.Info;
        }

        
        // Retorna um PointF que representa o ponto da cidade inserida na foto representada pelos parâmetros "widthFoto" e "heightFoto"
        public PointF PontoDaCidadeNaFoto(string cidade, float widthFoto, float heightFoto)
        {
            InfoCidade infoCidade = InfoDaCidade(cidade);

            return new PointF(infoCidade.Longitude * widthFoto, infoCidade.Latitude * heightFoto);
        }

        // Desenha todas as conexões da cidade inserida, pintando com outra caneta e com outro pincel as partes selecionadas.
        public void DesenharTodasAsConexoesDaCidade(string cidade, float widthFoto, float heightFoto, Pen caneta, Pen canetaSelecionada, Brush corDoPonto, Brush corDoPontoSelecionado, PaintEventArgs e)
        {
            PointF pontoCidadeCentral = PontoDaCidadeNaFoto(cidade, widthFoto, heightFoto);
            float raio = (float)2.5; // Tamanho do ponto

            if (this.grafoCidades.isSelecionado(cidade))
            {
                // Cria um ponto com outra cor se selecionada
                e.Graphics.DrawEllipse(canetaSelecionada, pontoCidadeCentral.X - raio, pontoCidadeCentral.Y - raio, raio * 2, raio * 2);
                e.Graphics.FillEllipse(corDoPontoSelecionado, pontoCidadeCentral.X - raio, pontoCidadeCentral.Y - raio, raio * 2, raio * 2);
            }
            else
            {
                e.Graphics.DrawEllipse(caneta, pontoCidadeCentral.X - raio, pontoCidadeCentral.Y - raio, raio * 2, raio * 2);
                e.Graphics.FillEllipse(corDoPonto, pontoCidadeCentral.X - raio, pontoCidadeCentral.Y - raio, raio * 2, raio * 2);
            }


            // Passa por todas as cidades e verifica se estão conectadas para formar a linha
            for (int i = this.grafoCidades.NumVerts - 1; i >= 0; i--)
            {
                string cidadeAtual = this.grafoCidades.Vertices[i].Rotulo;
                PointF pontoCidadeAtual = PontoDaCidadeNaFoto(cidadeAtual, widthFoto, heightFoto);


                switch (grafoCidades.SeConectamESaoSelecionados(cidade, cidadeAtual))
                {
                    case 1: // Se conectam, caneta sem selecionar;
                        e.Graphics.DrawLine(caneta, pontoCidadeCentral, pontoCidadeAtual);
                        break;

                    case 2: // Se conectam e estão selecionados, caneta selecionada
                        e.Graphics.DrawLine(canetaSelecionada, pontoCidadeCentral, pontoCidadeAtual);
                        break;

                    default: break;
                }
            }
        }

        //  Desenha todas as conexões de todas as cidades com base nas canetas, pinceis inseridos e baseando-se na altura e largura do local à ser desenhado
        public void DesenharTodasAsConexoes(float widthFoto, float heightFoto, Pen caneta, Pen canetaSelecionada, Brush corDoPonto, Brush corDoPontoSelecionado, PaintEventArgs e)
        {
            for (int i = this.grafoCidades.NumVerts - 1; i >= 0; i--)
                DesenharTodasAsConexoesDaCidade(this.grafoCidades.Vertices[i].Rotulo, widthFoto, heightFoto, caneta, canetaSelecionada, corDoPonto, corDoPontoSelecionado, e);
        }

        // Desenha uma linha de uma cidade à outra com base em uma caneta, na largura e na altura do local à desenhar
        public void DesenharLinha(string cidade1, string cidade2, float widthFoto, float heightFoto, Pen caneta, PaintEventArgs e)
        {
            if (!grafoCidades.SeConectam(cidade1, cidade2))
                throw new Exception("As cidades não se conectam, logo, não é possível desenhar a linha");

            PointF pontoCidade1 = PontoDaCidadeNaFoto(cidade1, widthFoto, heightFoto);
            PointF pontoCidade2 = PontoDaCidadeNaFoto(cidade2, widthFoto, heightFoto);

            e.Graphics.DrawLine(caneta, pontoCidade1, pontoCidade2);
        }


        // Verifica se as cidades inseridas se conectam.
        public bool CidadesSeConectam(string cidade1, string cidade2) => grafoCidades.SeConectam(cidade1, cidade2);

        // Retorna uma string com o caminho de uma cidade à outra, além de atualizar os selecionados para o caminho específico
        public string Caminho(string cidadeOrigem, string cidadeDestino) => this.grafoCidades.Caminho(cidadeOrigem, cidadeDestino);

        // Desenha a árvore das cidades com base na altura e largura de um local.
        public void DesenharArvoreDasCidades(double widthLocal, double heightLocal, Graphics g) => this.arvoreCidades.DesenharArvore(true, this.arvoreCidades.Raiz, (int)Math.Round(widthLocal / 2), 0, 0, widthLocal, heightLocal, this.arvoreCidades.Altura(), g);

        // Reseta todos as cidades selecionadas no grafo, deixando todas sem selecionar
        public void ResetarSelecionados() => this.grafoCidades.ResetarSelecionados();

        // Adiciona uma nova cidade no grafo e na árvore
        public void AdicionarCidade(InfoCidade cidade)
        {
            if (this.arvoreCidades.Existe(cidade))
                throw new Exception("Essa cidade já existe!");

            this.arvoreCidades.Inserir(cidade);
            this.grafoCidades.NovoVertice(cidade.NomeCidade);
        }

        // Remove uma nova cidade do grafo e da árvore
        public void RemoverCidade(string nomeCidade)
        {
            InfoCidade infoCidade = new InfoCidade(nomeCidade, 0, 0); // Localização desnecessária

            if (!this.arvoreCidades.Existe(infoCidade))
                throw new Exception("Essa cidade não existe!");

            this.arvoreCidades.Excluir(infoCidade);

            this.grafoCidades.RemoverVertice(nomeCidade);

        }

        // Adciona um caminho de uma cidade à outra, com seus devidos preços e distância
        public void AdicionarCaminho(string nomeCidade1, string nomeCidade2, int distancia, int preco)
        {    
            if (this.grafoCidades.SeConectam(nomeCidade1, nomeCidade2))
                throw new Exception("Cidades inseridas já estão conectadas.");

            this.grafoCidades.NovaAresta(nomeCidade1, nomeCidade2, distancia, preco);
            this.grafoCidades.NovaAresta(nomeCidade2, nomeCidade1, distancia, preco);
        }

        // Seleciona a cidade especificada
        public void SelecionarCidade(string nomeCidade) => this.grafoCidades.SelecionarVertice(nomeCidade);

        // Salva a àrvore e o grafo em 2 arquivos textos separados
        public void Salvar(StreamWriter arquivoCidades, StreamWriter arquivoCaminhos)
        {
            SalvarArvore(this.arvoreCidades.Raiz, arquivoCidades);

            this.grafoCidades.Salvar(arquivoCaminhos);

        }

        // Funcao recursiva para salvar a árvore no arquivo texto de cidades
        private void SalvarArvore (NoArvore<InfoCidade> galho, StreamWriter arquivo)
        {
            SalvarGalho(galho);
            arquivo.Close();
            void SalvarGalho(NoArvore<InfoCidade> atual)
            {
                if (atual != null)
                {
                    SalvarGalho(atual.Esq);
                    arquivo.WriteLine(atual.Info.NomeCidade.PadRight(15, ' ') + atual.Info.Longitude.ToString().PadLeft(6, ' ')
                        + atual.Info.Latitude.ToString().PadLeft(6, ' '));
                    SalvarGalho(atual.Dir);
                }
            }            
        }
    }
}