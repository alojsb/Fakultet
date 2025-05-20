namespace DLWMS.WinApp._2367
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
            dataGridView1 = new DataGridView();
            columnImePrezime = new DataGridViewTextBoxColumn();
            columnDrzava = new DataGridViewTextBoxColumn();
            columnGrad = new DataGridViewTextBoxColumn();
            columnSpol = new DataGridViewTextBoxColumn();
            columnAktivan = new DataGridViewCheckBoxColumn();
            columnRazmjena = new DataGridViewButtonColumn();
            txtImeIliPrezime = new TextBox();
            lblImeIliPrezime = new Label();
            label2 = new Label();
            cbDrzava = new ComboBox();
            cbSpol = new ComboBox();
            lblSpol = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { columnImePrezime, columnDrzava, columnGrad, columnSpol, columnAktivan, columnRazmjena });
            dataGridView1.Location = new Point(12, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(680, 383);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // columnImePrezime
            // 
            columnImePrezime.FillWeight = 200.000046F;
            columnImePrezime.HeaderText = "(Indeks) Ime i Prezime";
            columnImePrezime.Name = "columnImePrezime";
            // 
            // columnDrzava
            // 
            columnDrzava.FillWeight = 101.974754F;
            columnDrzava.HeaderText = "Država";
            columnDrzava.Name = "columnDrzava";
            // 
            // columnGrad
            // 
            columnGrad.FillWeight = 99.63277F;
            columnGrad.HeaderText = "Grad";
            columnGrad.Name = "columnGrad";
            // 
            // columnSpol
            // 
            columnSpol.FillWeight = 49.0093269F;
            columnSpol.HeaderText = "Spol";
            columnSpol.Name = "columnSpol";
            // 
            // columnAktivan
            // 
            columnAktivan.FillWeight = 49.47144F;
            columnAktivan.HeaderText = "Aktivan";
            columnAktivan.Name = "columnAktivan";
            // 
            // columnRazmjena
            // 
            columnRazmjena.FillWeight = 99.91172F;
            columnRazmjena.HeaderText = "";
            columnRazmjena.Name = "columnRazmjena";
            columnRazmjena.Text = "Razmjene";
            columnRazmjena.UseColumnTextForButtonValue = true;
            // 
            // txtImeIliPrezime
            // 
            txtImeIliPrezime.Location = new Point(12, 26);
            txtImeIliPrezime.Name = "txtImeIliPrezime";
            txtImeIliPrezime.Size = new Size(187, 23);
            txtImeIliPrezime.TabIndex = 1;
            txtImeIliPrezime.KeyUp += txtImeIliPrezime_KeyUp;
            // 
            // lblImeIliPrezime
            // 
            lblImeIliPrezime.AutoSize = true;
            lblImeIliPrezime.Location = new Point(12, 8);
            lblImeIliPrezime.Name = "lblImeIliPrezime";
            lblImeIliPrezime.Size = new Size(84, 15);
            lblImeIliPrezime.TabIndex = 2;
            lblImeIliPrezime.Text = "Ime ili prezime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 8);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Drzava";
            // 
            // cbDrzava
            // 
            cbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDrzava.FormattingEnabled = true;
            cbDrzava.Location = new Point(207, 26);
            cbDrzava.Name = "cbDrzava";
            cbDrzava.Size = new Size(139, 23);
            cbDrzava.TabIndex = 5;
            cbDrzava.SelectionChangeCommitted += cbDrzava_SelectionChangeCommitted;
            // 
            // cbSpol
            // 
            cbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpol.FormattingEnabled = true;
            cbSpol.Location = new Point(352, 26);
            cbSpol.Name = "cbSpol";
            cbSpol.Size = new Size(143, 23);
            cbSpol.TabIndex = 6;
            cbSpol.SelectionChangeCommitted += cbSpol_SelectionChangeCommitted;
            // 
            // lblSpol
            // 
            lblSpol.AutoSize = true;
            lblSpol.Location = new Point(352, 7);
            lblSpol.Name = "lblSpol";
            lblSpol.Size = new Size(30, 15);
            lblSpol.TabIndex = 7;
            lblSpol.Text = "Spol";
            // 
            // frmPretragaBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 450);
            Controls.Add(lblSpol);
            Controls.Add(cbSpol);
            Controls.Add(cbDrzava);
            Controls.Add(label2);
            Controls.Add(lblImeIliPrezime);
            Controls.Add(txtImeIliPrezime);
            Controls.Add(dataGridView1);
            Name = "frmPretragaBrojIndeksa";
            Text = "Armin Dzafo";
            Load += frmPretragaBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtImeIliPrezime;
        private Label lblImeIliPrezime;
        private Label label2;
        private ComboBox cbDrzava;
        private ComboBox cbSpol;
        private Label lblSpol;
        private DataGridViewTextBoxColumn columnImePrezime;
        private DataGridViewTextBoxColumn columnDrzava;
        private DataGridViewTextBoxColumn columnGrad;
        private DataGridViewTextBoxColumn columnSpol;
        private DataGridViewCheckBoxColumn columnAktivan;
        private DataGridViewButtonColumn columnRazmjena;
    }
}