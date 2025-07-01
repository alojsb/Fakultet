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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbDrzava = new ComboBox();
            cmbUniverzitet = new ComboBox();
            txtECTS = new TextBox();
            dtpPocetak = new DateTimePicker();
            dtpKraj = new DateTimePicker();
            dgvRazmjene = new DataGridView();
            Univerzitet = new DataGridViewTextBoxColumn();
            Pocetak = new DataGridViewTextBoxColumn();
            Kraj = new DataGridViewTextBoxColumn();
            ECTS = new DataGridViewTextBoxColumn();
            Okoncana = new DataGridViewCheckBoxColumn();
            Obrisi = new DataGridViewButtonColumn();
            btnSacuvaj = new Button();
            btnPotvrda = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Država:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 22);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 0;
            label2.Text = "Univerzitet:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 22);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 0;
            label3.Text = "Broj kredita:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(413, 22);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 0;
            label4.Text = "Početak razmjene:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(619, 22);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 0;
            label5.Text = "Kraj razmjene:";
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(12, 40);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(162, 23);
            cmbDrzava.TabIndex = 1;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbUniverzitet
            // 
            cmbUniverzitet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUniverzitet.FormattingEnabled = true;
            cmbUniverzitet.Location = new Point(180, 40);
            cmbUniverzitet.Name = "cmbUniverzitet";
            cmbUniverzitet.Size = new Size(165, 23);
            cmbUniverzitet.TabIndex = 1;
            // 
            // txtECTS
            // 
            txtECTS.Location = new Point(351, 40);
            txtECTS.Name = "txtECTS";
            txtECTS.Size = new Size(56, 23);
            txtECTS.TabIndex = 2;
            // 
            // dtpPocetak
            // 
            dtpPocetak.Location = new Point(413, 40);
            dtpPocetak.Name = "dtpPocetak";
            dtpPocetak.Size = new Size(200, 23);
            dtpPocetak.TabIndex = 3;
            // 
            // dtpKraj
            // 
            dtpKraj.Location = new Point(619, 40);
            dtpKraj.Name = "dtpKraj";
            dtpKraj.Size = new Size(200, 23);
            dtpKraj.TabIndex = 3;
            // 
            // dgvRazmjene
            // 
            dgvRazmjene.AllowUserToAddRows = false;
            dgvRazmjene.AllowUserToDeleteRows = false;
            dgvRazmjene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRazmjene.Columns.AddRange(new DataGridViewColumn[] { Univerzitet, Pocetak, Kraj, ECTS, Okoncana, Obrisi });
            dgvRazmjene.Location = new Point(12, 69);
            dgvRazmjene.Name = "dgvRazmjene";
            dgvRazmjene.ReadOnly = true;
            dgvRazmjene.Size = new Size(908, 195);
            dgvRazmjene.TabIndex = 4;
            dgvRazmjene.CellContentClick += dgvRazmjene_CellContentClick;
            dgvRazmjene.CellFormatting += dgvRazmjene_CellFormatting;
            // 
            // Univerzitet
            // 
            Univerzitet.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Univerzitet.DataPropertyName = "Univerzitet";
            Univerzitet.HeaderText = "Univerzitet";
            Univerzitet.Name = "Univerzitet";
            Univerzitet.ReadOnly = true;
            // 
            // Pocetak
            // 
            Pocetak.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Pocetak.DataPropertyName = "Pocetak";
            Pocetak.HeaderText = "Početak";
            Pocetak.Name = "Pocetak";
            Pocetak.ReadOnly = true;
            // 
            // Kraj
            // 
            Kraj.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Kraj.DataPropertyName = "Kraj";
            Kraj.HeaderText = "Kraj";
            Kraj.Name = "Kraj";
            Kraj.ReadOnly = true;
            // 
            // ECTS
            // 
            ECTS.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ECTS.DataPropertyName = "ECTS";
            ECTS.HeaderText = "ECTS";
            ECTS.Name = "ECTS";
            ECTS.ReadOnly = true;
            // 
            // Okoncana
            // 
            Okoncana.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Okoncana.DataPropertyName = "IsOkoncana";
            Okoncana.HeaderText = "Okončana";
            Okoncana.Name = "Okoncana";
            Okoncana.ReadOnly = true;
            Okoncana.Resizable = DataGridViewTriState.True;
            Okoncana.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Obrisi
            // 
            Obrisi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Obrisi.HeaderText = "";
            Obrisi.Name = "Obrisi";
            Obrisi.ReadOnly = true;
            Obrisi.Text = "Obriši";
            Obrisi.UseColumnTextForButtonValue = true;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(825, 39);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(95, 23);
            btnSacuvaj.TabIndex = 5;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(825, 270);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(95, 23);
            btnPotvrda.TabIndex = 6;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            // 
            // frmRazmjeneBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 450);
            Controls.Add(btnPotvrda);
            Controls.Add(btnSacuvaj);
            Controls.Add(dgvRazmjene);
            Controls.Add(dtpKraj);
            Controls.Add(dtpPocetak);
            Controls.Add(txtECTS);
            Controls.Add(cmbUniverzitet);
            Controls.Add(cmbDrzava);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmRazmjeneBrojIndeksa";
            Text = "frmRazmjeneBrojIndeksa";
            Load += frmRazmjeneBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbDrzava;
        private ComboBox cmbUniverzitet;
        private TextBox txtECTS;
        private DateTimePicker dtpPocetak;
        private DateTimePicker dtpKraj;
        private DataGridView dgvRazmjene;
        private Button btnSacuvaj;
        private Button btnPotvrda;
        private DataGridViewTextBoxColumn Univerzitet;
        private DataGridViewTextBoxColumn Pocetak;
        private DataGridViewTextBoxColumn Kraj;
        private DataGridViewTextBoxColumn ECTS;
        private DataGridViewCheckBoxColumn Okoncana;
        private DataGridViewButtonColumn Obrisi;
    }
}