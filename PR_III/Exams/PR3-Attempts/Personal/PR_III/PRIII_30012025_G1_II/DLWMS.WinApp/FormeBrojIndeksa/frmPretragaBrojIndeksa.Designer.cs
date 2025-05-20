namespace DLWMS.WinApp.FormeBrojIndeksa
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
            txtImeIliPrezime = new TextBox();
            cmbDrzava = new ComboBox();
            cmbSpol = new ComboBox();
            lblImeIliPrezime = new Label();
            lblDrzava = new Label();
            lblSpol = new Label();
            dgvStudenti = new DataGridView();
            colIndeksImePrezime = new DataGridViewTextBoxColumn();
            colDrzava = new DataGridViewTextBoxColumn();
            colGrad = new DataGridViewTextBoxColumn();
            colSpol = new DataGridViewTextBoxColumn();
            colAktivan = new DataGridViewCheckBoxColumn();
            colRazmjeneBtn = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).BeginInit();
            SuspendLayout();
            // 
            // txtImeIliPrezime
            // 
            txtImeIliPrezime.Location = new Point(12, 32);
            txtImeIliPrezime.Name = "txtImeIliPrezime";
            txtImeIliPrezime.Size = new Size(185, 23);
            txtImeIliPrezime.TabIndex = 0;
            txtImeIliPrezime.KeyUp += txtImeIliPrezime_KeyUp;
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(203, 32);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(172, 23);
            cmbDrzava.TabIndex = 1;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbSpol
            // 
            cmbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpol.FormattingEnabled = true;
            cmbSpol.Location = new Point(381, 32);
            cmbSpol.Name = "cmbSpol";
            cmbSpol.Size = new Size(172, 23);
            cmbSpol.TabIndex = 2;
            cmbSpol.SelectionChangeCommitted += cmbSpol_SelectionChangeCommitted;
            // 
            // lblImeIliPrezime
            // 
            lblImeIliPrezime.AutoSize = true;
            lblImeIliPrezime.Location = new Point(12, 9);
            lblImeIliPrezime.Name = "lblImeIliPrezime";
            lblImeIliPrezime.Size = new Size(87, 15);
            lblImeIliPrezime.TabIndex = 3;
            lblImeIliPrezime.Text = "Ime ili prezime:";
            // 
            // lblDrzava
            // 
            lblDrzava.AutoSize = true;
            lblDrzava.Location = new Point(203, 9);
            lblDrzava.Name = "lblDrzava";
            lblDrzava.Size = new Size(45, 15);
            lblDrzava.TabIndex = 4;
            lblDrzava.Text = "Država:";
            // 
            // lblSpol
            // 
            lblSpol.AutoSize = true;
            lblSpol.Location = new Point(381, 9);
            lblSpol.Name = "lblSpol";
            lblSpol.Size = new Size(33, 15);
            lblSpol.TabIndex = 5;
            lblSpol.Text = "Spol:";
            // 
            // dgvStudenti
            // 
            dgvStudenti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudenti.Columns.AddRange(new DataGridViewColumn[] { colIndeksImePrezime, colDrzava, colGrad, colSpol, colAktivan, colRazmjeneBtn });
            dgvStudenti.Location = new Point(12, 61);
            dgvStudenti.Name = "dgvStudenti";
            dgvStudenti.Size = new Size(776, 377);
            dgvStudenti.TabIndex = 6;
            dgvStudenti.CellContentClick += dgvStudenti_CellContentClick;
            dgvStudenti.CellDoubleClick += dgvStudenti_CellDoubleClick;
            dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
            // 
            // colIndeksImePrezime
            // 
            colIndeksImePrezime.HeaderText = "(Indeks) Ime i prezime";
            colIndeksImePrezime.Name = "colIndeksImePrezime";
            colIndeksImePrezime.ReadOnly = true;
            // 
            // colDrzava
            // 
            colDrzava.HeaderText = "Država";
            colDrzava.Name = "colDrzava";
            // 
            // colGrad
            // 
            colGrad.HeaderText = "Grad";
            colGrad.Name = "colGrad";
            // 
            // colSpol
            // 
            colSpol.HeaderText = "Spol";
            colSpol.Name = "colSpol";
            // 
            // colAktivan
            // 
            colAktivan.HeaderText = "Aktivan";
            colAktivan.Name = "colAktivan";
            // 
            // colRazmjeneBtn
            // 
            colRazmjeneBtn.HeaderText = "";
            colRazmjeneBtn.Name = "colRazmjeneBtn";
            colRazmjeneBtn.Text = "Razmjene";
            colRazmjeneBtn.UseColumnTextForButtonValue = true;
            // 
            // frmPretragaBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStudenti);
            Controls.Add(lblSpol);
            Controls.Add(lblDrzava);
            Controls.Add(lblImeIliPrezime);
            Controls.Add(cmbSpol);
            Controls.Add(cmbDrzava);
            Controls.Add(txtImeIliPrezime);
            Name = "frmPretragaBrojIndeksa";
            Text = "frmPretragaBrojIndeksa";
            Load += frmPretragaBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtImeIliPrezime;
        private ComboBox cmbDrzava;
        private ComboBox cmbSpol;
        private Label lblImeIliPrezime;
        private Label lblDrzava;
        private Label lblSpol;
        private DataGridView dgvStudenti;
        private DataGridViewTextBoxColumn colIndeksImePrezime;
        private DataGridViewTextBoxColumn colDrzava;
        private DataGridViewTextBoxColumn colGrad;
        private DataGridViewTextBoxColumn colSpol;
        private DataGridViewCheckBoxColumn colAktivan;
        private DataGridViewButtonColumn colRazmjeneBtn;
    }
}