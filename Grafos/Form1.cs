using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Form1 : Form
    {
        Cidade cidades;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDe.Text.Equals(string.Empty) || txtPara.Text.Equals(string.Empty))
                    MessageBox.Show("Preencha todos os campos");
                else
                {
                    // Verifica se as cidades são iguais
                    if (txtDe.Text == txtPara.Text)
                        MessageBox.Show("Coloque duas cidades diferentes!");
                    else
                    {
                        string cidadeOrigem = txtDe.Text;
                        string cidadeDestino = txtPara.Text;

                        // Limpa a TextBox para aparecer um novoCaminho
                        txtCaminho.Clear();
                        txtCaminho.AppendText(cidades.Caminho(cidadeOrigem, cidadeDestino));
                        // Refresh para aparecer as mudancas feitas no paint
                        this.Refresh();
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tenta abrir os arquivos
            try
            {
                if (dlgAbrir.ShowDialog() == DialogResult.OK)
                {
                    if (dlgAbrir2.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string fileName = dlgAbrir.FileName;
                            StreamReader arquivoCidades = new StreamReader(fileName);
                            string fileName2 = dlgAbrir2.FileName;
                            StreamReader arquivoCaminhos = new StreamReader(fileName2);
                            // Instancia uma nova cidade como parametros os arquivos abertos
                            cidades = new Cidade(arquivoCidades, arquivoCaminhos);
                            //this.Refresh();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Responsável por desenhar as conexoes em nosso mapa
                Pen caneta = new Pen(Color.Black, (float)1.5);
                Pen canetaAzul = new Pen(Color.Blue, 2);
                cidades.DesenharTodasAsConexoes(pbMapa.Width, pbMapa.Height, caneta, canetaAzul, Brushes.Black, Brushes.Blue, e);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Quando troca de aba, certos eventos aconteceram em cada uma delas, por meio do nome da tabPage
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
                {
                    txtDe.Clear();
                    txtPara.Clear();
                    txtCaminho.Clear();
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
                {
                    txtNomeCidade.Clear();
                    nudXCidade.Value = 0;
                    nudYCidade.Value = 0;
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
                {
                    txtNomeCidade2.Clear();
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"])
                {
                    txtOrigem.Clear();
                    txtDestino.Clear();
                    nudDistancia.Value = 1;
                    nudPreco.Value = 1;
                }

                cidades.ResetarSelecionados();
                this.Refresh();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Responsavel por desenhar a arvore das cidades
        private void pnlArvore_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                cidades.DesenharArvoreDasCidades((int)pnlArvore.Width, pnlArvore.Height, e.Graphics);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdicionarCidade_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeCidade = txtNomeCidade.Text.TrimEnd(' ').TrimStart(' ');
                if (nomeCidade.Equals(string.Empty))
                    MessageBox.Show("Preencha todos os campos");
                else
                {
                    float xCidade = (float)nudXCidade.Value;
                    float yCidade = (float)nudYCidade.Value;

                    // Instancia uma nova infoCidade com os valores dados
                    InfoCidade cidadeAdicionar = new InfoCidade(nomeCidade, xCidade, yCidade);

                    // Adiciona essa cidade passando como parametro a variavel de InfoCidade
                    cidades.AdicionarCidade(cidadeAdicionar);
                    this.Refresh();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Responsável por desenhar as conexoes em nosso mapa
                Pen caneta = new Pen(Color.Black, (float)1.5);
                Pen canetaAzul = new Pen(Color.Blue, 2);
                cidades.DesenharTodasAsConexoes(pbMapaAdicionar.Width, pbMapaAdicionar.Height, caneta, canetaAzul, Brushes.Black, Brushes.Blue, e);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbMapaRemover_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Responsável por desenhar as conexoes em nosso mapa
                Pen caneta = new Pen(Color.Black, (float)1.5);
                Pen canetaAzul = new Pen(Color.Blue, 2);
                cidades.DesenharTodasAsConexoes(pbMapaRemover.Width, pbMapaRemover.Height, caneta, canetaAzul, Brushes.Black, Brushes.Blue, e);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemoverCidade_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeCidade2.Text.Equals(string.Empty))
                    MessageBox.Show("Preencha todos os campos");
                else
                {
                    string nomeCidade = txtNomeCidade2.Text;

                    // Remove a cidade por meio de seu nome
                    cidades.RemoverCidade(nomeCidade);
                    this.Refresh();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdicionarCaminho_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOrigem.Text.Equals(string.Empty) || txtDestino.Text.Equals(string.Empty))
                    MessageBox.Show("Preencha todos os campos!");
                else
                {
                    string nomeOrigem = txtOrigem.Text;
                    string nomeDestino = txtDestino.Text;
                    int distancia = (int)nudDistancia.Value;
                    int preco = (int)nudPreco.Value;
                    
                    // Adiciona um caminho entre duas cidades passando os dados do forms
                    cidades.AdicionarCaminho(nomeOrigem, nomeDestino, distancia, preco);
                    this.Refresh();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbMapaCaminhos_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Responsável por desenhar as conexoes em nosso mapa
                Pen caneta = new Pen(Color.Black, (float)1.5);
                Pen canetaAzul = new Pen(Color.Blue, 2);
                cidades.DesenharTodasAsConexoes(pbMapaCaminhos.Width, pbMapaCaminhos.Height, caneta, canetaAzul, Brushes.Black, Brushes.Blue, e);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Salva os dados ao sair do formulário
                StreamWriter arquivoCidades = new StreamWriter(dlgAbrir.FileName);
                StreamWriter arquivoCaminhos = new StreamWriter(dlgAbrir2.FileName);
                cidades.Salvar(arquivoCidades, arquivoCaminhos);                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
