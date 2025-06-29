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
            lblImePrezime = new Label();
            lblDrzava = new Label();
            lblSpol = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).BeginInit();
            SuspendLayout();
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(12, 39);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(189, 23);
            txtImePrezime.TabIndex = 0;
            txtImePrezime.KeyUp += txtImePrezime_KeyUp;
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(207, 39);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(181, 23);
            cmbDrzava.TabIndex = 1;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbSpol
            // 
            cmbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpol.FormattingEnabled = true;
            cmbSpol.Location = new Point(394, 39);
            cmbSpol.Name = "cmbSpol";
            cmbSpol.Size = new Size(168, 23);
            cmbSpol.TabIndex = 2;
            cmbSpol.SelectionChangeCommitted += cmbSpol_SelectionChangeCommitted;
            // 
            // dgvStudenti
            // 
            dgvStudenti.AllowUserToAddRows = false;
            dgvStudenti.AllowUserToDeleteRows = false;
            dgvStudenti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudenti.Columns.AddRange(new DataGridViewColumn[] { colImePrezime, colDrzava, colGrad, colSpol, colAktivan, colRazmjene });
            dgvStudenti.Location = new Point(12, 68);
            dgvStudenti.Name = "dgvStudenti";
            dgvStudenti.ReadOnly = true;
            dgvStudenti.Size = new Size(776, 370);
            dgvStudenti.TabIndex = 3;
            dgvStudenti.CellContentClick += dgvStudenti_CellContentClick;
            dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
            // 
            // colImePrezime
            // 
            colImePrezime.HeaderText = "(Indeks) Ime i prezime";
            colImePrezime.Name = "colImePrezime";
            colImePrezime.ReadOnly = true;
            // 
            // colDrzava
            // 
            colDrzava.HeaderText = "Država";
            colDrzava.Name = "colDrzava";
            colDrzava.ReadOnly = true;
            // 
            // colGrad
            // 
            colGrad.HeaderText = "Grad";
            colGrad.Name = "colGrad";
            colGrad.ReadOnly = true;
            // 
            // colSpol
            // 
            colSpol.HeaderText = "Spol";
            colSpol.Name = "colSpol";
            colSpol.ReadOnly = true;
            // 
            // colAktivan
            // 
            colAktivan.HeaderText = "Aktivan";
            colAktivan.Name = "colAktivan";
            colAktivan.ReadOnly = true;
            // 
            // colRazmjene
            // 
            colRazmjene.HeaderText = "";
            colRazmjene.Name = "colRazmjene";
            colRazmjene.ReadOnly = true;
            colRazmjene.Text = "Razmjene";
            colRazmjene.UseColumnTextForButtonValue = true;
            // 
            // lblImePrezime
            // 
            lblImePrezime.AutoSize = true;
            lblImePrezime.Location = new Point(12, 21);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(87, 15);
            lblImePrezime.TabIndex = 4;
            lblImePrezime.Text = "Ime ili prezime:";
            // 
            // lblDrzava
            // 
            lblDrzava.AutoSize = true;
            lblDrzava.Location = new Point(207, 21);
            lblDrzava.Name = "lblDrzava";
            lblDrzava.Size = new Size(45, 15);
            lblDrzava.TabIndex = 5;
            lblDrzava.Text = "Država:";
            // 
            // lblSpol
            // 
            lblSpol.AutoSize = true;
            lblSpol.Location = new Point(394, 21);
            lblSpol.Name = "lblSpol";
            lblSpol.Size = new Size(33, 15);
            lblSpol.TabIndex = 6;
            lblSpol.Text = "Spol:";
            // 
            // frmPretragaBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSpol);
            Controls.Add(lblDrzava);
            Controls.Add(lblImePrezime);
            Controls.Add(dgvStudenti);
            Controls.Add(cmbSpol);
            Controls.Add(cmbDrzava);
            Controls.Add(txtImePrezime);
            Name = "frmPretragaBrojIndeksa";
            Text = "frmPretragaBrojIndeksa";
            Load += frmPretragaBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtImePrezime;
        private ComboBox cmbDrzava;
        private ComboBox cmbSpol;
        private DataGridView dgvStudenti;
        private Label lblImePrezime;
        private Label lblDrzava;
        private Label lblSpol;
        private DataGridViewTextBoxColumn colImePrezime;
        private DataGridViewTextBoxColumn colDrzava;
        private DataGridViewTextBoxColumn colGrad;
        private DataGridViewTextBoxColumn colSpol;
        private DataGridViewCheckBoxColumn colAktivan;
        private DataGridViewButtonColumn colRazmjene;
    }
}