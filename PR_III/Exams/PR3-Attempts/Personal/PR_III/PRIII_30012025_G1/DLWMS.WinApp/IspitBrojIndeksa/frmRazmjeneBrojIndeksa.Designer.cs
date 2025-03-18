namespace DLWMS.WinApp.IspitBrojIndeksa
{
    partial class frmRazmjeneBrojIndeksa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvRazmjene = new DataGridView();
            colUniverzitet = new DataGridViewTextBoxColumn();
            colPocetak = new DataGridViewTextBoxColumn();
            colKraj = new DataGridViewTextBoxColumn();
            colEcts = new DataGridViewTextBoxColumn();
            colOkoncana = new DataGridViewCheckBoxColumn();
            colObrisi = new DataGridViewButtonColumn();
            cmbDrzava = new ComboBox();
            cmbUniverzitet = new ComboBox();
            txtEcts = new TextBox();
            dtpPocetak = new DateTimePicker();
            dtpKraj = new DateTimePicker();
            btnSacuvaj = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnPotvrda = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).BeginInit();
            SuspendLayout();
            // 
            // dgvRazmjene
            // 
            dgvRazmjene.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRazmjene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRazmjene.Columns.AddRange(new DataGridViewColumn[] { colUniverzitet, colPocetak, colKraj, colEcts, colOkoncana, colObrisi });
            dgvRazmjene.Location = new Point(12, 64);
            dgvRazmjene.Name = "dgvRazmjene";
            dgvRazmjene.Size = new Size(915, 201);
            dgvRazmjene.TabIndex = 0;
            dgvRazmjene.CellContentClick += dgvRazmjene_CellContentClick;
            dgvRazmjene.CellFormatting += dgvRazmjene_CellFormatting;
            // 
            // colUniverzitet
            // 
            colUniverzitet.HeaderText = "Univerzitet";
            colUniverzitet.Name = "colUniverzitet";
            // 
            // colPocetak
            // 
            colPocetak.HeaderText = "Početak";
            colPocetak.Name = "colPocetak";
            // 
            // colKraj
            // 
            colKraj.HeaderText = "Kraj";
            colKraj.Name = "colKraj";
            // 
            // colEcts
            // 
            colEcts.HeaderText = "ECTS";
            colEcts.Name = "colEcts";
            // 
            // colOkoncana
            // 
            colOkoncana.HeaderText = "Okončana";
            colOkoncana.Name = "colOkoncana";
            // 
            // colObrisi
            // 
            colObrisi.HeaderText = "";
            colObrisi.Name = "colObrisi";
            colObrisi.Text = "Obriši";
            colObrisi.UseColumnTextForButtonValue = true;
            // 
            // cmbDrzava
            // 
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(12, 35);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(155, 23);
            cmbDrzava.TabIndex = 1;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbUniverzitet
            // 
            cmbUniverzitet.FormattingEnabled = true;
            cmbUniverzitet.Location = new Point(173, 35);
            cmbUniverzitet.Name = "cmbUniverzitet";
            cmbUniverzitet.Size = new Size(155, 23);
            cmbUniverzitet.TabIndex = 2;
            // 
            // txtEcts
            // 
            txtEcts.Location = new Point(334, 35);
            txtEcts.Name = "txtEcts";
            txtEcts.Size = new Size(100, 23);
            txtEcts.TabIndex = 3;
            // 
            // dtpPocetak
            // 
            dtpPocetak.Location = new Point(440, 35);
            dtpPocetak.Name = "dtpPocetak";
            dtpPocetak.Size = new Size(200, 23);
            dtpPocetak.TabIndex = 4;
            // 
            // dtpKraj
            // 
            dtpKraj.Location = new Point(646, 35);
            dtpKraj.Name = "dtpKraj";
            dtpKraj.Size = new Size(200, 23);
            dtpKraj.TabIndex = 5;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(852, 34);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(75, 23);
            btnSacuvaj.TabIndex = 6;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 12);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 7;
            label1.Text = "Država:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 12);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 8;
            label2.Text = "Univerzitet:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 12);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 9;
            label3.Text = "Broj kredita:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(440, 12);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 10;
            label4.Text = "Početak razmjene:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(646, 12);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 11;
            label5.Text = "Kraj razmjene:";
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(851, 271);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(75, 23);
            btnPotvrda.TabIndex = 12;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            btnPotvrda.Click += btnPotvrda_Click;
            // 
            // frmRazmjeneBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 450);
            Controls.Add(btnPotvrda);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSacuvaj);
            Controls.Add(dtpKraj);
            Controls.Add(dtpPocetak);
            Controls.Add(txtEcts);
            Controls.Add(cmbUniverzitet);
            Controls.Add(cmbDrzava);
            Controls.Add(dgvRazmjene);
            Name = "frmRazmjeneBrojIndeksa";
            Text = "frmRazmjeneBrojIndeksa";
            Load += frmRazmjeneBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRazmjene;
        private ComboBox cmbDrzava;
        private ComboBox cmbUniverzitet;
        private TextBox txtEcts;
        private DateTimePicker dtpPocetak;
        private DateTimePicker dtpKraj;
        private Button btnSacuvaj;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridViewTextBoxColumn colUniverzitet;
        private DataGridViewTextBoxColumn colPocetak;
        private DataGridViewTextBoxColumn colKraj;
        private DataGridViewTextBoxColumn colEcts;
        private DataGridViewCheckBoxColumn colOkoncana;
        private DataGridViewButtonColumn colObrisi;
        private Button btnPotvrda;
    }
}