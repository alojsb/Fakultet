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
            cmbGodina = new ComboBox();
            label2 = new Label();
            cmbStipendija = new ComboBox();
            btnDodajStipendiju = new Button();
            btnStipendijePoGodinama = new Button();
            dgvStudentiStipendije = new DataGridView();
            ImePrezime = new DataGridViewTextBoxColumn();
            Godina = new DataGridViewTextBoxColumn();
            Stipendija = new DataGridViewTextBoxColumn();
            MjesecniIznos = new DataGridViewTextBoxColumn();
            Ukupno = new DataGridViewTextBoxColumn();
            Ukloni = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendije).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // cmbGodina
            // 
            cmbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGodina.FormattingEnabled = true;
            cmbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cmbGodina.Location = new Point(12, 37);
            cmbGodina.Name = "cmbGodina";
            cmbGodina.Size = new Size(166, 23);
            cmbGodina.TabIndex = 1;
            cmbGodina.SelectionChangeCommitted += cmbGodina_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 19);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // cmbStipendija
            // 
            cmbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStipendija.FormattingEnabled = true;
            cmbStipendija.Location = new Point(184, 37);
            cmbStipendija.Name = "cmbStipendija";
            cmbStipendija.Size = new Size(166, 23);
            cmbStipendija.TabIndex = 1;
            cmbStipendija.SelectionChangeCommitted += cmbStipendija_SelectionChangeCommitted;
            // 
            // btnDodajStipendiju
            // 
            btnDodajStipendiju.Location = new Point(531, 36);
            btnDodajStipendiju.Name = "btnDodajStipendiju";
            btnDodajStipendiju.Size = new Size(108, 23);
            btnDodajStipendiju.TabIndex = 2;
            btnDodajStipendiju.Text = "Dodaj stipendiju";
            btnDodajStipendiju.UseVisualStyleBackColor = true;
            btnDodajStipendiju.Click += btnDodajStipendiju_Click;
            // 
            // btnStipendijePoGodinama
            // 
            btnStipendijePoGodinama.Location = new Point(645, 36);
            btnStipendijePoGodinama.Name = "btnStipendijePoGodinama";
            btnStipendijePoGodinama.Size = new Size(143, 23);
            btnStipendijePoGodinama.TabIndex = 2;
            btnStipendijePoGodinama.Text = "Stipendije po godinama";
            btnStipendijePoGodinama.UseVisualStyleBackColor = true;
            // 
            // dgvStudentiStipendije
            // 
            dgvStudentiStipendije.AllowUserToAddRows = false;
            dgvStudentiStipendije.AllowUserToDeleteRows = false;
            dgvStudentiStipendije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiStipendije.Columns.AddRange(new DataGridViewColumn[] { ImePrezime, Godina, Stipendija, MjesecniIznos, Ukupno, Ukloni });
            dgvStudentiStipendije.Location = new Point(12, 66);
            dgvStudentiStipendije.Name = "dgvStudentiStipendije";
            dgvStudentiStipendije.ReadOnly = true;
            dgvStudentiStipendije.Size = new Size(776, 372);
            dgvStudentiStipendije.TabIndex = 3;
            dgvStudentiStipendije.CellContentClick += dgvStudentiStipendije_CellContentClick;
            dgvStudentiStipendije.CellDoubleClick += dgvStudentiStipendije_CellDoubleClick;
            dgvStudentiStipendije.CellFormatting += dgvStudentiStipendije_CellFormatting;
            // 
            // ImePrezime
            // 
            ImePrezime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ImePrezime.HeaderText = "(Indeks) Ime i prezime";
            ImePrezime.Name = "ImePrezime";
            ImePrezime.ReadOnly = true;
            // 
            // Godina
            // 
            Godina.HeaderText = "Godina";
            Godina.Name = "Godina";
            Godina.ReadOnly = true;
            // 
            // Stipendija
            // 
            Stipendija.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stipendija.HeaderText = "Stipendija";
            Stipendija.Name = "Stipendija";
            Stipendija.ReadOnly = true;
            // 
            // MjesecniIznos
            // 
            MjesecniIznos.HeaderText = "Mjesecni iznos";
            MjesecniIznos.Name = "MjesecniIznos";
            MjesecniIznos.ReadOnly = true;
            // 
            // Ukupno
            // 
            Ukupno.HeaderText = "Ukupno";
            Ukupno.Name = "Ukupno";
            Ukupno.ReadOnly = true;
            // 
            // Ukloni
            // 
            Ukloni.HeaderText = "";
            Ukloni.Name = "Ukloni";
            Ukloni.ReadOnly = true;
            Ukloni.Text = "Ukloni";
            Ukloni.UseColumnTextForButtonValue = true;
            // 
            // frmPretragaBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStudentiStipendije);
            Controls.Add(btnStipendijePoGodinama);
            Controls.Add(btnDodajStipendiju);
            Controls.Add(cmbStipendija);
            Controls.Add(cmbGodina);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaBrojIndeksa";
            Text = "frmPretragaBrojIndeksa";
            Load += frmPretragaBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbGodina;
        private Label label2;
        private ComboBox cmbStipendija;
        private Button btnDodajStipendiju;
        private Button btnStipendijePoGodinama;
        private DataGridView dgvStudentiStipendije;
        private DataGridViewTextBoxColumn ImePrezime;
        private DataGridViewTextBoxColumn Godina;
        private DataGridViewTextBoxColumn Stipendija;
        private DataGridViewTextBoxColumn MjesecniIznos;
        private DataGridViewTextBoxColumn Ukupno;
        private DataGridViewButtonColumn Ukloni;
    }
}