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
            ImePrezime = new DataGridViewTextBoxColumn();
            Drzava = new DataGridViewTextBoxColumn();
            Grad = new DataGridViewTextBoxColumn();
            Spol = new DataGridViewTextBoxColumn();
            Aktivan = new DataGridViewCheckBoxColumn();
            Razmjene = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 20);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(368, 20);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "label2";
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(15, 43);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(171, 23);
            txtImePrezime.TabIndex = 2;
            txtImePrezime.KeyUp += txtImePrezime_KeyUp;
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(192, 43);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(170, 23);
            cmbDrzava.TabIndex = 3;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbSpol
            // 
            cmbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpol.FormattingEnabled = true;
            cmbSpol.Location = new Point(368, 43);
            cmbSpol.Name = "cmbSpol";
            cmbSpol.Size = new Size(158, 23);
            cmbSpol.TabIndex = 3;
            cmbSpol.SelectionChangeCommitted += cmbSpol_SelectionChangeCommitted;
            // 
            // dgvStudenti
            // 
            dgvStudenti.AllowUserToAddRows = false;
            dgvStudenti.AllowUserToDeleteRows = false;
            dgvStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudenti.Columns.AddRange(new DataGridViewColumn[] { ImePrezime, Drzava, Grad, Spol, Aktivan, Razmjene });
            dgvStudenti.Location = new Point(15, 72);
            dgvStudenti.Name = "dgvStudenti";
            dgvStudenti.Size = new Size(773, 366);
            dgvStudenti.TabIndex = 4;
            dgvStudenti.CellContentClick += dgvStudenti_CellContentClick;
            // 
            // ImePrezime
            // 
            ImePrezime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ImePrezime.DataPropertyName = "ImePrezime";
            ImePrezime.HeaderText = "(Indeks) Ime i prezime";
            ImePrezime.Name = "ImePrezime";
            // 
            // Drzava
            // 
            Drzava.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Drzava.DataPropertyName = "Drzava";
            Drzava.HeaderText = "Država";
            Drzava.Name = "Drzava";
            // 
            // Grad
            // 
            Grad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grad.DataPropertyName = "Grad";
            Grad.HeaderText = "Grad";
            Grad.Name = "Grad";
            // 
            // Spol
            // 
            Spol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Spol.DataPropertyName = "Spol";
            Spol.HeaderText = "Spol";
            Spol.Name = "Spol";
            // 
            // Aktivan
            // 
            Aktivan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Aktivan.DataPropertyName = "Aktivan";
            Aktivan.HeaderText = "Aktivan";
            Aktivan.Name = "Aktivan";
            // 
            // Razmjene
            // 
            Razmjene.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Razmjene.HeaderText = "";
            Razmjene.Name = "Razmjene";
            Razmjene.Text = "Razmjene";
            Razmjene.UseColumnTextForButtonValue = true;
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
        private DataGridViewTextBoxColumn ImePrezime;
        private DataGridViewTextBoxColumn Drzava;
        private DataGridViewTextBoxColumn Grad;
        private DataGridViewTextBoxColumn Spol;
        private DataGridViewCheckBoxColumn Aktivan;
        private DataGridViewButtonColumn Razmjene;
    }
}