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
            cmbDrzava = new ComboBox();
            cmbUniverzitet = new ComboBox();
            txtECTS = new TextBox();
            dtpPocetak = new DateTimePicker();
            dtpKraj = new DateTimePicker();
            btnSacuvaj = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dgvRazmjene = new DataGridView();
            colUniverzitet = new DataGridViewTextBoxColumn();
            colPocetak = new DataGridViewTextBoxColumn();
            colKraj = new DataGridViewTextBoxColumn();
            colECTS = new DataGridViewTextBoxColumn();
            colOkoncana = new DataGridViewCheckBoxColumn();
            colObrisi = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).BeginInit();
            SuspendLayout();
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(12, 35);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(158, 23);
            cmbDrzava.TabIndex = 0;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbUniverzitet
            // 
            cmbUniverzitet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUniverzitet.FormattingEnabled = true;
            cmbUniverzitet.Location = new Point(176, 35);
            cmbUniverzitet.Name = "cmbUniverzitet";
            cmbUniverzitet.Size = new Size(158, 23);
            cmbUniverzitet.TabIndex = 1;
            // 
            // txtECTS
            // 
            txtECTS.Location = new Point(340, 35);
            txtECTS.Name = "txtECTS";
            txtECTS.Size = new Size(100, 23);
            txtECTS.TabIndex = 2;
            // 
            // dtpPocetak
            // 
            dtpPocetak.Location = new Point(446, 35);
            dtpPocetak.Name = "dtpPocetak";
            dtpPocetak.Size = new Size(200, 23);
            dtpPocetak.TabIndex = 3;
            // 
            // dtpKraj
            // 
            dtpKraj.Location = new Point(652, 35);
            dtpKraj.Name = "dtpKraj";
            dtpKraj.Size = new Size(200, 23);
            dtpKraj.TabIndex = 3;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(858, 34);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(78, 23);
            btnSacuvaj.TabIndex = 4;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Država:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 17);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 6;
            label2.Text = "Univerzitet:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(340, 17);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 7;
            label3.Text = "Broj kredita:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(446, 17);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 8;
            label4.Text = "Početak razmjene:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(652, 17);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 9;
            label5.Text = "Kraj razmjene:";
            // 
            // dgvRazmjene
            // 
            dgvRazmjene.AllowUserToAddRows = false;
            dgvRazmjene.AllowUserToDeleteRows = false;
            dgvRazmjene.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRazmjene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRazmjene.Columns.AddRange(new DataGridViewColumn[] { colUniverzitet, colPocetak, colKraj, colECTS, colOkoncana, colObrisi });
            dgvRazmjene.Location = new Point(12, 64);
            dgvRazmjene.Name = "dgvRazmjene";
            dgvRazmjene.ReadOnly = true;
            dgvRazmjene.Size = new Size(924, 190);
            dgvRazmjene.TabIndex = 10;
            dgvRazmjene.CellContentClick += dgvRazmjene_CellContentClick;
            dgvRazmjene.CellFormatting += dgvRazmjene_CellFormatting;
            // 
            // colUniverzitet
            // 
            colUniverzitet.HeaderText = "Univerzitet";
            colUniverzitet.Name = "colUniverzitet";
            colUniverzitet.ReadOnly = true;
            // 
            // colPocetak
            // 
            colPocetak.HeaderText = "Početak";
            colPocetak.Name = "colPocetak";
            colPocetak.ReadOnly = true;
            // 
            // colKraj
            // 
            colKraj.HeaderText = "Kraj";
            colKraj.Name = "colKraj";
            colKraj.ReadOnly = true;
            // 
            // colECTS
            // 
            colECTS.HeaderText = "ECTS";
            colECTS.Name = "colECTS";
            colECTS.ReadOnly = true;
            // 
            // colOkoncana
            // 
            colOkoncana.HeaderText = "Okončana";
            colOkoncana.Name = "colOkoncana";
            colOkoncana.ReadOnly = true;
            // 
            // colObrisi
            // 
            colObrisi.HeaderText = "";
            colObrisi.Name = "colObrisi";
            colObrisi.ReadOnly = true;
            colObrisi.Text = "Obriši";
            colObrisi.UseColumnTextForButtonValue = true;
            // 
            // frmRazmjeneBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 450);
            Controls.Add(dgvRazmjene);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSacuvaj);
            Controls.Add(dtpKraj);
            Controls.Add(dtpPocetak);
            Controls.Add(txtECTS);
            Controls.Add(cmbUniverzitet);
            Controls.Add(cmbDrzava);
            Name = "frmRazmjeneBrojIndeksa";
            Text = "frmRazmjeneBrojIndeksa";
            Load += frmRazmjeneBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDrzava;
        private ComboBox cmbUniverzitet;
        private TextBox txtECTS;
        private DateTimePicker dtpPocetak;
        private DateTimePicker dtpKraj;
        private Button btnSacuvaj;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dgvRazmjene;
        private DataGridViewTextBoxColumn colUniverzitet;
        private DataGridViewTextBoxColumn colPocetak;
        private DataGridViewTextBoxColumn colKraj;
        private DataGridViewTextBoxColumn colECTS;
        private DataGridViewCheckBoxColumn colOkoncana;
        private DataGridViewButtonColumn colObrisi;
    }
}