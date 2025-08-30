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
            cmbGodina = new ComboBox();
            cmbStipendija = new ComboBox();
            label1 = new Label();
            label2 = new Label();
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
            // cmbGodina
            // 
            cmbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGodina.FormattingEnabled = true;
            cmbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cmbGodina.Location = new Point(12, 33);
            cmbGodina.Name = "cmbGodina";
            cmbGodina.Size = new Size(164, 23);
            cmbGodina.TabIndex = 0;
            cmbGodina.SelectionChangeCommitted += cmbGodina_SelectionChangeCommitted;
            // 
            // cmbStipendija
            // 
            cmbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStipendija.FormattingEnabled = true;
            cmbStipendija.Location = new Point(182, 33);
            cmbStipendija.Name = "cmbStipendija";
            cmbStipendija.Size = new Size(164, 23);
            cmbStipendija.TabIndex = 0;
            cmbStipendija.SelectionChangeCommitted += cmbStipendija_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 15);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "Stipendija:";
            // 
            // btnDodajStipendiju
            // 
            btnDodajStipendiju.Location = new Point(540, 32);
            btnDodajStipendiju.Name = "btnDodajStipendiju";
            btnDodajStipendiju.RightToLeft = RightToLeft.No;
            btnDodajStipendiju.Size = new Size(101, 23);
            btnDodajStipendiju.TabIndex = 2;
            btnDodajStipendiju.Text = "Dodaj stipendiju";
            btnDodajStipendiju.UseVisualStyleBackColor = true;
            // 
            // btnStipendijePoGodinama
            // 
            btnStipendijePoGodinama.Location = new Point(647, 32);
            btnStipendijePoGodinama.Name = "btnStipendijePoGodinama";
            btnStipendijePoGodinama.Size = new Size(141, 23);
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
            dgvStudentiStipendije.Location = new Point(12, 62);
            dgvStudentiStipendije.Name = "dgvStudentiStipendije";
            dgvStudentiStipendije.ReadOnly = true;
            dgvStudentiStipendije.Size = new Size(776, 376);
            dgvStudentiStipendije.TabIndex = 3;
            dgvStudentiStipendije.CellContentClick += dgvStudentiStipendije_CellContentClick;
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
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbStipendija);
            Controls.Add(cmbGodina);
            Name = "frmPretragaBrojIndeksa";
            Text = "frmPretragaBrojIndeksa";
            Load += frmPretragaBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbGodina;
        private ComboBox cmbStipendija;
        private Label label1;
        private Label label2;
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