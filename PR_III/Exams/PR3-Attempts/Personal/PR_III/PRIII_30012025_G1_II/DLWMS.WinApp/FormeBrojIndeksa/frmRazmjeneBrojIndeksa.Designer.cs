namespace DLWMS.WinApp.FormeBrojIndeksa
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
            txtEcts = new TextBox();
            dtpPocetak = new DateTimePicker();
            dtpKraj = new DateTimePicker();
            btnSacuvaj = new Button();
            lblDrzava = new Label();
            lblUniverzitet = new Label();
            lblEcts = new Label();
            lblPocetak = new Label();
            lblKraj = new Label();
            dgvRazmjene = new DataGridView();
            colUniverzitet = new DataGridViewTextBoxColumn();
            colPocetak = new DataGridViewTextBoxColumn();
            colKraj = new DataGridViewTextBoxColumn();
            colEcts = new DataGridViewTextBoxColumn();
            colIsOkoncana = new DataGridViewCheckBoxColumn();
            colObrisi = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).BeginInit();
            SuspendLayout();
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(12, 48);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(187, 23);
            cmbDrzava.TabIndex = 0;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbUniverzitet
            // 
            cmbUniverzitet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUniverzitet.FormattingEnabled = true;
            cmbUniverzitet.Location = new Point(205, 48);
            cmbUniverzitet.Name = "cmbUniverzitet";
            cmbUniverzitet.Size = new Size(187, 23);
            cmbUniverzitet.TabIndex = 1;
            // 
            // txtEcts
            // 
            txtEcts.Location = new Point(398, 48);
            txtEcts.Name = "txtEcts";
            txtEcts.Size = new Size(100, 23);
            txtEcts.TabIndex = 2;
            // 
            // dtpPocetak
            // 
            dtpPocetak.Location = new Point(504, 48);
            dtpPocetak.Name = "dtpPocetak";
            dtpPocetak.Size = new Size(200, 23);
            dtpPocetak.TabIndex = 3;
            // 
            // dtpKraj
            // 
            dtpKraj.Location = new Point(710, 48);
            dtpKraj.Name = "dtpKraj";
            dtpKraj.Size = new Size(200, 23);
            dtpKraj.TabIndex = 4;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(916, 48);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(75, 23);
            btnSacuvaj.TabIndex = 5;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // lblDrzava
            // 
            lblDrzava.AutoSize = true;
            lblDrzava.Location = new Point(12, 21);
            lblDrzava.Name = "lblDrzava";
            lblDrzava.Size = new Size(45, 15);
            lblDrzava.TabIndex = 6;
            lblDrzava.Text = "Država:";
            // 
            // lblUniverzitet
            // 
            lblUniverzitet.AutoSize = true;
            lblUniverzitet.Location = new Point(205, 21);
            lblUniverzitet.Name = "lblUniverzitet";
            lblUniverzitet.Size = new Size(66, 15);
            lblUniverzitet.TabIndex = 7;
            lblUniverzitet.Text = "Univerzitet:";
            // 
            // lblEcts
            // 
            lblEcts.AutoSize = true;
            lblEcts.Location = new Point(398, 21);
            lblEcts.Name = "lblEcts";
            lblEcts.Size = new Size(70, 15);
            lblEcts.TabIndex = 8;
            lblEcts.Text = "Broj kredita:";
            // 
            // lblPocetak
            // 
            lblPocetak.AutoSize = true;
            lblPocetak.Location = new Point(504, 21);
            lblPocetak.Name = "lblPocetak";
            lblPocetak.Size = new Size(103, 15);
            lblPocetak.TabIndex = 9;
            lblPocetak.Text = "Početak razmjene:";
            // 
            // lblKraj
            // 
            lblKraj.AutoSize = true;
            lblKraj.Location = new Point(710, 21);
            lblKraj.Name = "lblKraj";
            lblKraj.Size = new Size(81, 15);
            lblKraj.TabIndex = 10;
            lblKraj.Text = "Kraj razmjene:";
            // 
            // dgvRazmjene
            // 
            dgvRazmjene.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRazmjene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRazmjene.Columns.AddRange(new DataGridViewColumn[] { colUniverzitet, colPocetak, colKraj, colEcts, colIsOkoncana, colObrisi });
            dgvRazmjene.Location = new Point(12, 77);
            dgvRazmjene.Name = "dgvRazmjene";
            dgvRazmjene.Size = new Size(979, 485);
            dgvRazmjene.TabIndex = 11;
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
            // colIsOkoncana
            // 
            colIsOkoncana.HeaderText = "Okončana";
            colIsOkoncana.Name = "colIsOkoncana";
            colIsOkoncana.ReadOnly = true;
            colIsOkoncana.Resizable = DataGridViewTriState.True;
            colIsOkoncana.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colObrisi
            // 
            colObrisi.HeaderText = "";
            colObrisi.Name = "colObrisi";
            colObrisi.Text = "Obriši";
            colObrisi.UseColumnTextForButtonValue = true;
            // 
            // frmRazmjeneBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 574);
            Controls.Add(dgvRazmjene);
            Controls.Add(lblKraj);
            Controls.Add(lblPocetak);
            Controls.Add(lblEcts);
            Controls.Add(lblUniverzitet);
            Controls.Add(lblDrzava);
            Controls.Add(btnSacuvaj);
            Controls.Add(dtpKraj);
            Controls.Add(dtpPocetak);
            Controls.Add(txtEcts);
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
        private TextBox txtEcts;
        private DateTimePicker dtpPocetak;
        private DateTimePicker dtpKraj;
        private Button btnSacuvaj;
        private Label lblDrzava;
        private Label lblUniverzitet;
        private Label lblEcts;
        private Label lblPocetak;
        private Label lblKraj;
        private DataGridView dgvRazmjene;
        private DataGridViewTextBoxColumn colUniverzitet;
        private DataGridViewTextBoxColumn colPocetak;
        private DataGridViewTextBoxColumn colKraj;
        private DataGridViewTextBoxColumn colEcts;
        private DataGridViewCheckBoxColumn colIsOkoncana;
        private DataGridViewButtonColumn colObrisi;
    }
}