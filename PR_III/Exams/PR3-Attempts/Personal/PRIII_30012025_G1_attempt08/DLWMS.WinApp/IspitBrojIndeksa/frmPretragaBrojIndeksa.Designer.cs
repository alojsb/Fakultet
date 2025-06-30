namespace DLWMS.WinApp.IspitBrojIndeksa
{
    partial class frmPretragaBrojIndeksa
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
            txtImePrezime = new TextBox();
            cmbDrzava = new ComboBox();
            cmbSpol = new ComboBox();
            dgvStudenti = new DataGridView();
            colImePrezime = new DataGridViewTextBoxColumn();
            colDrzava = new DataGridViewTextBoxColumn();
            colGrad = new DataGridViewTextBoxColumn();
            colSpol = new DataGridViewTextBoxColumn();
            colAktivan = new DataGridViewCheckBoxColumn();
            colRazmjene = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 23);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime ili prezime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 23);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 0;
            label2.Text = "Država:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(441, 23);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 0;
            label3.Text = "Spol:";
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(9, 41);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(253, 23);
            txtImePrezime.TabIndex = 1;
            txtImePrezime.KeyUp += txtImePrezime_KeyUp;
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(268, 41);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(167, 23);
            cmbDrzava.TabIndex = 2;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbSpol
            // 
            cmbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpol.FormattingEnabled = true;
            cmbSpol.Location = new Point(441, 41);
            cmbSpol.Name = "cmbSpol";
            cmbSpol.Size = new Size(173, 23);
            cmbSpol.TabIndex = 2;
            cmbSpol.SelectionChangeCommitted += cmbSpol_SelectionChangeCommitted;
            // 
            // dgvStudenti
            // 
            dgvStudenti.AllowUserToAddRows = false;
            dgvStudenti.AllowUserToDeleteRows = false;
            dgvStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudenti.Columns.AddRange(new DataGridViewColumn[] { colImePrezime, colDrzava, colGrad, colSpol, colAktivan, colRazmjene });
            dgvStudenti.Location = new Point(9, 70);
            dgvStudenti.Name = "dgvStudenti";
            dgvStudenti.Size = new Size(779, 368);
            dgvStudenti.TabIndex = 3;
            dgvStudenti.CellContentClick += dgvStudenti_CellContentClick;
            dgvStudenti.CellDoubleClick += dgvStudenti_CellDoubleClick;
            dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
            // 
            // colImePrezime
            // 
            colImePrezime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colImePrezime.DataPropertyName = "ImePrezime";
            colImePrezime.HeaderText = "(Indeks) Ime i prezime";
            colImePrezime.Name = "colImePrezime";
            // 
            // colDrzava
            // 
            colDrzava.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDrzava.DataPropertyName = "Drzava";
            colDrzava.HeaderText = "Država";
            colDrzava.Name = "colDrzava";
            // 
            // colGrad
            // 
            colGrad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGrad.DataPropertyName = "Grad";
            colGrad.HeaderText = "Grad";
            colGrad.Name = "colGrad";
            // 
            // colSpol
            // 
            colSpol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSpol.DataPropertyName = "Spol";
            colSpol.HeaderText = "Spol";
            colSpol.Name = "colSpol";
            // 
            // colAktivan
            // 
            colAktivan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAktivan.DataPropertyName = "Aktivan";
            colAktivan.HeaderText = "Aktivan";
            colAktivan.Name = "colAktivan";
            // 
            // colRazmjene
            // 
            colRazmjene.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRazmjene.DataPropertyName = "Razmjene";
            colRazmjene.HeaderText = "";
            colRazmjene.Name = "colRazmjene";
            colRazmjene.Text = "Razmjene";
            colRazmjene.UseColumnTextForButtonValue = true;
            // 
            // frmPretragaBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStudenti);
            Controls.Add(cmbSpol);
            Controls.Add(cmbDrzava);
            Controls.Add(txtImePrezime);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaBrojIndeksa";
            Text = "frmPretragaBrojIndeksa";
            Load += frmPretragaBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtImePrezime;
        private ComboBox cmbDrzava;
        private ComboBox cmbSpol;
        private DataGridView dgvStudenti;
        private DataGridViewTextBoxColumn colImePrezime;
        private DataGridViewTextBoxColumn colDrzava;
        private DataGridViewTextBoxColumn colGrad;
        private DataGridViewTextBoxColumn colSpol;
        private DataGridViewCheckBoxColumn colAktivan;
        private DataGridViewButtonColumn colRazmjene;
    }
}