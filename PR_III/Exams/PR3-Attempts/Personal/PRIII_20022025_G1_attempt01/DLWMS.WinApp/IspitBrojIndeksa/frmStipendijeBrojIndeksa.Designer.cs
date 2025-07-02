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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbGodina = new ComboBox();
            cmbStipendija = new ComboBox();
            txtIznos = new TextBox();
            dgvStipendijeGodine = new DataGridView();
            Godina = new DataGridViewTextBoxColumn();
            Stipendija = new DataGridViewTextBoxColumn();
            MjesecniIznos = new DataGridViewTextBoxColumn();
            UkupniIznos = new DataGridViewTextBoxColumn();
            Aktivna = new DataGridViewCheckBoxColumn();
            btnDodaj = new Button();
            btnPotvrda = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(217, 21);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(418, 21);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 0;
            label3.Text = "Mjesečni iznos (BAM)";
            // 
            // cmbGodina
            // 
            cmbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGodina.FormattingEnabled = true;
            cmbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cmbGodina.Location = new Point(12, 39);
            cmbGodina.Name = "cmbGodina";
            cmbGodina.Size = new Size(199, 23);
            cmbGodina.TabIndex = 1;
            // 
            // cmbStipendija
            // 
            cmbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStipendija.FormattingEnabled = true;
            cmbStipendija.Location = new Point(217, 39);
            cmbStipendija.Name = "cmbStipendija";
            cmbStipendija.Size = new Size(195, 23);
            cmbStipendija.TabIndex = 1;
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(418, 39);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(121, 23);
            txtIznos.TabIndex = 2;
            // 
            // dgvStipendijeGodine
            // 
            dgvStipendijeGodine.AllowUserToAddRows = false;
            dgvStipendijeGodine.AllowUserToDeleteRows = false;
            dgvStipendijeGodine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStipendijeGodine.Columns.AddRange(new DataGridViewColumn[] { Godina, Stipendija, MjesecniIznos, UkupniIznos, Aktivna });
            dgvStipendijeGodine.Location = new Point(12, 68);
            dgvStipendijeGodine.Name = "dgvStipendijeGodine";
            dgvStipendijeGodine.Size = new Size(776, 206);
            dgvStipendijeGodine.TabIndex = 3;
            dgvStipendijeGodine.CellDoubleClick += dgvStipendijeGodine_CellDoubleClick;
            dgvStipendijeGodine.CellFormatting += dgvStipendijeGodine_CellFormatting;
            // 
            // Godina
            // 
            Godina.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Godina.DataPropertyName = "Godina";
            Godina.HeaderText = "Godina";
            Godina.Name = "Godina";
            // 
            // Stipendija
            // 
            Stipendija.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stipendija.DataPropertyName = "Stipendija";
            Stipendija.HeaderText = "Stipendija";
            Stipendija.Name = "Stipendija";
            // 
            // MjesecniIznos
            // 
            MjesecniIznos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MjesecniIznos.DataPropertyName = "Iznos";
            MjesecniIznos.HeaderText = "Mjesečni iznos";
            MjesecniIznos.Name = "MjesecniIznos";
            // 
            // UkupniIznos
            // 
            UkupniIznos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UkupniIznos.HeaderText = "Ukupni iznos";
            UkupniIznos.Name = "UkupniIznos";
            // 
            // Aktivna
            // 
            Aktivna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Aktivna.DataPropertyName = "Aktivna";
            Aktivna.HeaderText = "Aktivna";
            Aktivna.Name = "Aktivna";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(545, 39);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(75, 23);
            btnDodaj.TabIndex = 4;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(713, 280);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(75, 23);
            btnPotvrda.TabIndex = 5;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            // 
            // frmStipendijeBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPotvrda);
            Controls.Add(btnDodaj);
            Controls.Add(dgvStipendijeGodine);
            Controls.Add(txtIznos);
            Controls.Add(cmbStipendija);
            Controls.Add(cmbGodina);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmStipendijeBrojIndeksa";
            Text = "frmStipendijeBrojIndeksa";
            Load += frmStipendijeBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbGodina;
        private ComboBox cmbStipendija;
        private TextBox txtIznos;
        private DataGridView dgvStipendijeGodine;
        private Button btnDodaj;
        private Button btnPotvrda;
        private DataGridViewTextBoxColumn Godina;
        private DataGridViewTextBoxColumn Stipendija;
        private DataGridViewTextBoxColumn MjesecniIznos;
        private DataGridViewTextBoxColumn UkupniIznos;
        private DataGridViewCheckBoxColumn Aktivna;
    }
}