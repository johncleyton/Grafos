
namespace _20133_20144_ED
{
    /* 
     * Feito por: 
     * Frederico Scheffel Oliveira - RA: 20133
     * Lucas Coimbra da Silva      - RA: 20144
     */
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblPara = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.TextBox();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nudYCidade = new System.Windows.Forms.NumericUpDown();
            this.nudXCidade = new System.Windows.Forms.NumericUpDown();
            this.btnAdicionarCidade = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeCidade = new System.Windows.Forms.TextBox();
            this.pbMapaAdicionar = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRemoverCidade = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomeCidade2 = new System.Windows.Forms.TextBox();
            this.pbMapaRemover = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.nudPreco = new System.Windows.Forms.NumericUpDown();
            this.nudDistancia = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbMapaCaminhos = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdicionarCaminho = new System.Windows.Forms.Button();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pnlArvore = new System.Windows.Forms.Panel();
            this.dlgAbrir2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYCidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaAdicionar)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaRemover)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaCaminhos)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.Image = global::_20133_20144_ED.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapa.Location = new System.Drawing.Point(-1, 68);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(483, 300);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 0;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(3, 12);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(24, 13);
            this.lblDe.TabIndex = 1;
            this.lblDe.Text = "De:";
            // 
            // lblPara
            // 
            this.lblPara.AutoSize = true;
            this.lblPara.Location = new System.Drawing.Point(3, 36);
            this.lblPara.Name = "lblPara";
            this.lblPara.Size = new System.Drawing.Size(32, 13);
            this.lblPara.TabIndex = 2;
            this.lblPara.Text = "Para:";
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(55, 10);
            this.txtDe.MaxLength = 15;
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(100, 20);
            this.txtDe.TabIndex = 3;
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(55, 36);
            this.txtPara.MaxLength = 15;
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(100, 20);
            this.txtPara.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(179, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblCaminho
            // 
            this.lblCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Location = new System.Drawing.Point(-1, 375);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(48, 13);
            this.lblCaminho.TabIndex = 6;
            this.lblCaminho.Text = "Caminho";
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 515);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCaminho);
            this.tabPage1.Controls.Add(this.lblDe);
            this.tabPage1.Controls.Add(this.pbMapa);
            this.tabPage1.Controls.Add(this.lblCaminho);
            this.tabPage1.Controls.Add(this.lblPara);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtDe);
            this.tabPage1.Controls.Add(this.txtPara);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(488, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ver caminhos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCaminho
            // 
            this.txtCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaminho.Enabled = false;
            this.txtCaminho.Location = new System.Drawing.Point(2, 392);
            this.txtCaminho.Multiline = true;
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCaminho.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCaminho.Size = new System.Drawing.Size(480, 91);
            this.txtCaminho.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nudYCidade);
            this.tabPage2.Controls.Add(this.nudXCidade);
            this.tabPage2.Controls.Add(this.btnAdicionarCidade);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtNomeCidade);
            this.tabPage2.Controls.Add(this.pbMapaAdicionar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(488, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adicionar cidades";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nudYCidade
            // 
            this.nudYCidade.DecimalPlaces = 3;
            this.nudYCidade.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudYCidade.Location = new System.Drawing.Point(53, 63);
            this.nudYCidade.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudYCidade.Name = "nudYCidade";
            this.nudYCidade.Size = new System.Drawing.Size(100, 20);
            this.nudYCidade.TabIndex = 12;
            // 
            // nudXCidade
            // 
            this.nudXCidade.DecimalPlaces = 3;
            this.nudXCidade.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudXCidade.Location = new System.Drawing.Point(53, 34);
            this.nudXCidade.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXCidade.Name = "nudXCidade";
            this.nudXCidade.Size = new System.Drawing.Size(100, 20);
            this.nudXCidade.TabIndex = 11;
            // 
            // btnAdicionarCidade
            // 
            this.btnAdicionarCidade.Location = new System.Drawing.Point(184, 28);
            this.btnAdicionarCidade.Name = "btnAdicionarCidade";
            this.btnAdicionarCidade.Size = new System.Drawing.Size(99, 23);
            this.btnAdicionarCidade.TabIndex = 8;
            this.btnAdicionarCidade.Text = "Adicionar Cidade";
            this.btnAdicionarCidade.UseVisualStyleBackColor = true;
            this.btnAdicionarCidade.Click += new System.EventHandler(this.btnAdicionarCidade_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome:";
            // 
            // txtNomeCidade
            // 
            this.txtNomeCidade.Location = new System.Drawing.Point(53, 5);
            this.txtNomeCidade.MaxLength = 15;
            this.txtNomeCidade.Name = "txtNomeCidade";
            this.txtNomeCidade.Size = new System.Drawing.Size(100, 20);
            this.txtNomeCidade.TabIndex = 2;
            // 
            // pbMapaAdicionar
            // 
            this.pbMapaAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapaAdicionar.Image = global::_20133_20144_ED.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapaAdicionar.Location = new System.Drawing.Point(3, 94);
            this.pbMapaAdicionar.Name = "pbMapaAdicionar";
            this.pbMapaAdicionar.Size = new System.Drawing.Size(483, 300);
            this.pbMapaAdicionar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapaAdicionar.TabIndex = 1;
            this.pbMapaAdicionar.TabStop = false;
            this.pbMapaAdicionar.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnRemoverCidade);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtNomeCidade2);
            this.tabPage3.Controls.Add(this.pbMapaRemover);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(488, 489);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Remover cidades";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRemoverCidade
            // 
            this.btnRemoverCidade.Location = new System.Drawing.Point(181, 31);
            this.btnRemoverCidade.Name = "btnRemoverCidade";
            this.btnRemoverCidade.Size = new System.Drawing.Size(99, 23);
            this.btnRemoverCidade.TabIndex = 16;
            this.btnRemoverCidade.Text = "Remover Cidade";
            this.btnRemoverCidade.UseVisualStyleBackColor = true;
            this.btnRemoverCidade.Click += new System.EventHandler(this.btnRemoverCidade_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nome:";
            // 
            // txtNomeCidade2
            // 
            this.txtNomeCidade2.Location = new System.Drawing.Point(61, 31);
            this.txtNomeCidade2.MaxLength = 15;
            this.txtNomeCidade2.Name = "txtNomeCidade2";
            this.txtNomeCidade2.Size = new System.Drawing.Size(100, 20);
            this.txtNomeCidade2.TabIndex = 10;
            // 
            // pbMapaRemover
            // 
            this.pbMapaRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapaRemover.Image = global::_20133_20144_ED.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapaRemover.Location = new System.Drawing.Point(3, 94);
            this.pbMapaRemover.Name = "pbMapaRemover";
            this.pbMapaRemover.Size = new System.Drawing.Size(483, 300);
            this.pbMapaRemover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapaRemover.TabIndex = 9;
            this.pbMapaRemover.TabStop = false;
            this.pbMapaRemover.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapaRemover_Paint);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.nudPreco);
            this.tabPage4.Controls.Add(this.nudDistancia);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.pbMapaCaminhos);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.btnAdicionarCaminho);
            this.tabPage4.Controls.Add(this.txtOrigem);
            this.tabPage4.Controls.Add(this.txtDestino);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(488, 489);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Adicionar caminhos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // nudPreco
            // 
            this.nudPreco.Location = new System.Drawing.Point(64, 92);
            this.nudPreco.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudPreco.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPreco.Name = "nudPreco";
            this.nudPreco.Size = new System.Drawing.Size(100, 20);
            this.nudPreco.TabIndex = 17;
            this.nudPreco.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudDistancia
            // 
            this.nudDistancia.Location = new System.Drawing.Point(64, 64);
            this.nudDistancia.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDistancia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDistancia.Name = "nudDistancia";
            this.nudDistancia.Size = new System.Drawing.Size(100, 20);
            this.nudDistancia.TabIndex = 16;
            this.nudDistancia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Distância:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Preço:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Origem:";
            // 
            // pbMapaCaminhos
            // 
            this.pbMapaCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapaCaminhos.Image = global::_20133_20144_ED.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapaCaminhos.Location = new System.Drawing.Point(2, 123);
            this.pbMapaCaminhos.Name = "pbMapaCaminhos";
            this.pbMapaCaminhos.Size = new System.Drawing.Size(483, 300);
            this.pbMapaCaminhos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapaCaminhos.TabIndex = 6;
            this.pbMapaCaminhos.TabStop = false;
            this.pbMapaCaminhos.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapaCaminhos_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Destino:";
            // 
            // btnAdicionarCaminho
            // 
            this.btnAdicionarCaminho.Location = new System.Drawing.Point(206, 48);
            this.btnAdicionarCaminho.Name = "btnAdicionarCaminho";
            this.btnAdicionarCaminho.Size = new System.Drawing.Size(115, 23);
            this.btnAdicionarCaminho.TabIndex = 11;
            this.btnAdicionarCaminho.Text = "Adicionar Caminho";
            this.btnAdicionarCaminho.UseVisualStyleBackColor = true;
            this.btnAdicionarCaminho.Click += new System.EventHandler(this.btnAdicionarCaminho_Click);
            // 
            // txtOrigem
            // 
            this.txtOrigem.Location = new System.Drawing.Point(64, 12);
            this.txtOrigem.MaxLength = 15;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(100, 20);
            this.txtOrigem.TabIndex = 9;
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(64, 38);
            this.txtDestino.MaxLength = 15;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(100, 20);
            this.txtDestino.TabIndex = 10;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pnlArvore);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(488, 489);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Mostrar árvore";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pnlArvore
            // 
            this.pnlArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArvore.Location = new System.Drawing.Point(6, 6);
            this.pnlArvore.Name = "pnlArvore";
            this.pnlArvore.Size = new System.Drawing.Size(476, 477);
            this.pnlArvore.TabIndex = 1;
            this.pnlArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlArvore_Paint);
            // 
            // dlgAbrir2
            // 
            this.dlgAbrir2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 539);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYCidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaAdicionar)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaRemover)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaCaminhos)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblPara;
        private System.Windows.Forms.TextBox txtDe;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.OpenFileDialog dlgAbrir2;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel pnlArvore;
        private System.Windows.Forms.PictureBox pbMapaAdicionar;
        private System.Windows.Forms.TextBox txtNomeCidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdicionarCidade;
        private System.Windows.Forms.Button btnRemoverCidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomeCidade2;
        private System.Windows.Forms.PictureBox pbMapaRemover;
        private System.Windows.Forms.NumericUpDown nudXCidade;
        private System.Windows.Forms.NumericUpDown nudYCidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbMapaCaminhos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdicionarCaminho;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.NumericUpDown nudPreco;
        private System.Windows.Forms.NumericUpDown nudDistancia;
    }
}

