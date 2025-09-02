namespace DLWMS.WinApp.IspitBrojIndeksa
{
    partial class frmStipendijeBrojIndeksa
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
            cmbGodina = new ComboBox();
            cmbStipendija = new ComboBox();
            txtMjesecniIznos = new TextBox();
            btnDodaj = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvStipendijeGodine = new DataGridView();
            Godina = new DataGridViewTextBoxColumn();
            Stipendija = new DataGridViewTextBoxColumn();
            MjesecniIznos = new DataGridViewTextBoxColumn();
            Ukupno = new DataGridViewTextBoxColumn();
            Aktivna = new DataGridViewCheckBoxColumn();
            btnPotvrda = new Button();
            btnGenerisiStipendije = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).BeginInit();
            SuspendLayout();
            // 
            // cmbGodina
            // 
            cmbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGodina.FormattingEnabled = true;
            cmbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cmbGodina.Location = new Point(12, 29);
            cmbGodina.Name = "cmbGodina";
            cmbGodina.Size = new Size(158, 23);
            cmbGodina.TabIndex = 0;
            cmbGodina.SelectionChangeCommitted += cmbGodina_SelectionChangeCommitted;
            // 
            // cmbStipendija
            // 
            cmbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStipendija.FormattingEnabled = true;
            cmbStipendija.Location = new Point(176, 29);
            cmbStipendija.Name = "cmbStipendija";
            cmbStipendija.Size = new Size(158, 23);
            cmbStipendija.TabIndex = 0;
            // 
            // txtMjesecniIznos
            // 
            txtMjesecniIznos.Location = new Point(340, 29);
            txtMjesecniIznos.Name = "txtMjesecniIznos";
            txtMjesecniIznos.Size = new Size(129, 23);
            txtMjesecniIznos.TabIndex = 1;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(475, 29);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 2;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 3;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 9);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Stipendija:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(340, 9);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 3;
            label3.Text = "Mjesečni iznos (BAM):";
            // 
            // dgvStipendijeGodine
            // 
            dgvStipendijeGodine.AllowUserToAddRows = false;
            dgvStipendijeGodine.AllowUserToDeleteRows = false;
            dgvStipendijeGodine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStipendijeGodine.Columns.AddRange(new DataGridViewColumn[] { Godina, Stipendija, MjesecniIznos, Ukupno, Aktivna });
            dgvStipendijeGodine.Location = new Point(12, 58);
            dgvStipendijeGodine.Name = "dgvStipendijeGodine";
            dgvStipendijeGodine.Size = new Size(776, 255);
            dgvStipendijeGodine.TabIndex = 4;
            dgvStipendijeGodine.CellDoubleClick += dgvStipendijeGodine_CellDoubleClick;
            dgvStipendijeGodine.CellFormatting += dgvStipendijeGodine_CellFormatting;
            // 
            // Godina
            // 
            Godina.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Godina.HeaderText = "Godina";
            Godina.Name = "Godina";
            // 
            // Stipendija
            // 
            Stipendija.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stipendija.HeaderText = "Stipendija";
            Stipendija.Name = "Stipendija";
            // 
            // MjesecniIznos
            // 
            MjesecniIznos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MjesecniIznos.HeaderText = "Mjesečni iznos";
            MjesecniIznos.Name = "MjesecniIznos";
            // 
            // Ukupno
            // 
            Ukupno.HeaderText = "Ukupni iznos";
            Ukupno.Name = "Ukupno";
            // 
            // Aktivna
            // 
            Aktivna.DataPropertyName = "Aktivna";
            Aktivna.HeaderText = "Aktivna";
            Aktivna.Name = "Aktivna";
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(713, 319);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(75, 23);
            btnPotvrda.TabIndex = 5;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            // 
            // btnGenerisiStipendije
            // 
            btnGenerisiStipendije.Location = new Point(12, 319);
            btnGenerisiStipendije.Name = "btnGenerisiStipendije";
            btnGenerisiStipendije.Size = new Size(171, 23);
            btnGenerisiStipendije.TabIndex = 6;
            btnGenerisiStipendije.Text = "Generiši stipendije >>>>>>";
            btnGenerisiStipendije.UseVisualStyleBackColor = true;
            // 
            // frmStipendijeBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 594);
            Controls.Add(btnGenerisiStipendije);
            Controls.Add(btnPotvrda);
            Controls.Add(dgvStipendijeGodine);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDodaj);
            Controls.Add(txtMjesecniIznos);
            Controls.Add(cmbStipendija);
            Controls.Add(cmbGodina);
            Name = "frmStipendijeBrojIndeksa";
            Text = "frmStipendijeBrojIndeksa";
            Load += frmStipendijeBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbGodina;
        private ComboBox cmbStipendija;
        private TextBox txtMjesecniIznos;
        private Button btnDodaj;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvStipendijeGodine;
        private Button btnPotvrda;
        private Button btnGenerisiStipendije;
        private DataGridViewTextBoxColumn Godina;
        private DataGridViewTextBoxColumn Stipendija;
        private DataGridViewTextBoxColumn MjesecniIznos;
        private DataGridViewTextBoxColumn Ukupno;
        private DataGridViewCheckBoxColumn Aktivna;
    }
}