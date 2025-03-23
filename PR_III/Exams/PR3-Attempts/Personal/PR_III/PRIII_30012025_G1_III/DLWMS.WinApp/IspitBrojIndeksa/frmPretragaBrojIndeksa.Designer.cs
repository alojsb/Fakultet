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
            colIndeksImePrezime = new DataGridViewTextBoxColumn();
            colDrzava = new DataGridViewTextBoxColumn();
            colGrad = new DataGridViewTextBoxColumn();
            colSpol = new DataGridViewTextBoxColumn();
            colAktivan = new DataGridViewCheckBoxColumn();
            colRazmjene = new DataGridViewButtonColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).BeginInit();
            SuspendLayout();
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(12, 44);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(187, 23);
            txtImePrezime.TabIndex = 0;
            txtImePrezime.KeyUp += txtImePrezime_KeyUp;
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(205, 44);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(167, 23);
            cmbDrzava.TabIndex = 1;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbSpol
            // 
            cmbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpol.FormattingEnabled = true;
            cmbSpol.Location = new Point(378, 44);
            cmbSpol.Name = "cmbSpol";
            cmbSpol.Size = new Size(167, 23);
            cmbSpol.TabIndex = 2;
            cmbSpol.SelectionChangeCommitted += cmbSpol_SelectionChangeCommitted;
            // 
            // dgvStudenti
            // 
            dgvStudenti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudenti.Columns.AddRange(new DataGridViewColumn[] { colIndeksImePrezime, colDrzava, colGrad, colSpol, colAktivan, colRazmjene });
            dgvStudenti.Location = new Point(12, 73);
            dgvStudenti.Name = "dgvStudenti";
            dgvStudenti.Size = new Size(776, 365);
            dgvStudenti.TabIndex = 3;
            dgvStudenti.CellContentClick += dgvStudenti_CellContentClick;
            //dgvStudenti.CellFormatting += dgvStudenti_CellFormatting;
            // 
            // colIndeksImePrezime
            // 
            colIndeksImePrezime.HeaderText = "(Indeks) Ime i prezime";
            colIndeksImePrezime.Name = "colIndeksImePrezime";
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
            // colRazmjene
            // 
            colRazmjene.HeaderText = "";
            colRazmjene.Name = "colRazmjene";
            colRazmjene.Text = "Razmjene";
            colRazmjene.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 4;
            label1.Text = "Ime ili prezime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 26);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 5;
            label2.Text = "Država:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(378, 26);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 6;
            label3.Text = "Spol:";
            // 
            // frmPretragaBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn colIndeksImePrezime;
        private DataGridViewTextBoxColumn colDrzava;
        private DataGridViewTextBoxColumn colGrad;
        private DataGridViewTextBoxColumn colSpol;
        private DataGridViewCheckBoxColumn colAktivan;
        private DataGridViewButtonColumn colRazmjene;
    }
}