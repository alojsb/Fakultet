namespace DLWMS.WinApp.IB220347
{
    partial class frmRazmjene
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            cmbDrzava = new ComboBox();
            label2 = new Label();
            cmbUni = new ComboBox();
            label3 = new Label();
            tbECTS = new TextBox();
            dtpPocetak = new DateTimePicker();
            label4 = new Label();
            dtpKraj = new DateTimePicker();
            label5 = new Label();
            btnSpasi = new Button();
            dgvRazmjene = new DataGridView();
            Univerzitet = new DataGridViewTextBoxColumn();
            Pocetak = new DataGridViewTextBoxColumn();
            Kraj = new DataGridViewTextBoxColumn();
            ECTS = new DataGridViewTextBoxColumn();
            Okoncana = new DataGridViewCheckBoxColumn();
            Obrisi = new DataGridViewButtonColumn();
            btnPrint = new Button();
            gbGenerator = new GroupBox();
            tbInfo = new TextBox();
            label9 = new Label();
            btnGenerisi = new Button();
            tbBrojEcts = new TextBox();
            label8 = new Label();
            tbBrojRazmjena = new TextBox();
            label7 = new Label();
            cmbUNiThread = new ComboBox();
            label6 = new Label();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).BeginInit();
            gbGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Drzava:";
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(12, 37);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(210, 28);
            cmbDrzava.TabIndex = 1;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(228, 9);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 0;
            label2.Text = "Univerzitet:";
            // 
            // cmbUni
            // 
            cmbUni.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUni.FormattingEnabled = true;
            cmbUni.Location = new Point(228, 37);
            cmbUni.Name = "cmbUni";
            cmbUni.Size = new Size(210, 28);
            cmbUni.TabIndex = 1;
            cmbUni.SelectionChangeCommitted += cmbUni_SelectionChangeCommitted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(444, 9);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "BrojECTS:";
            // 
            // tbECTS
            // 
            tbECTS.Location = new Point(444, 37);
            tbECTS.Name = "tbECTS";
            tbECTS.Size = new Size(69, 27);
            tbECTS.TabIndex = 3;
            // 
            // dtpPocetak
            // 
            dtpPocetak.Location = new Point(519, 38);
            dtpPocetak.Name = "dtpPocetak";
            dtpPocetak.Size = new Size(250, 27);
            dtpPocetak.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(519, 9);
            label4.Name = "label4";
            label4.Size = new Size(125, 20);
            label4.TabIndex = 5;
            label4.Text = "PocetakRazmjene";
            // 
            // dtpKraj
            // 
            dtpKraj.Location = new Point(775, 38);
            dtpKraj.Name = "dtpKraj";
            dtpKraj.Size = new Size(250, 27);
            dtpKraj.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(775, 9);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 5;
            label5.Text = "KrajRazmjene:";
            // 
            // btnSpasi
            // 
            btnSpasi.Location = new Point(1031, 38);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(121, 29);
            btnSpasi.TabIndex = 6;
            btnSpasi.Text = "Sacuvaj";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // dgvRazmjene
            // 
            dgvRazmjene.AllowUserToAddRows = false;
            dgvRazmjene.AllowUserToDeleteRows = false;
            dgvRazmjene.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRazmjene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRazmjene.Columns.AddRange(new DataGridViewColumn[] { Univerzitet, Pocetak, Kraj, ECTS, Okoncana, Obrisi });
            dgvRazmjene.Location = new Point(12, 73);
            dgvRazmjene.Name = "dgvRazmjene";
            dgvRazmjene.ReadOnly = true;
            dgvRazmjene.RowHeadersWidth = 51;
            dgvRazmjene.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRazmjene.Size = new Size(1140, 312);
            dgvRazmjene.TabIndex = 7;
            dgvRazmjene.CellContentClick += dgvRazmjene_CellContentClick;
            // 
            // Univerzitet
            // 
            Univerzitet.DataPropertyName = "Univerzitet";
            Univerzitet.HeaderText = "Univerzitet";
            Univerzitet.MinimumWidth = 6;
            Univerzitet.Name = "Univerzitet";
            Univerzitet.ReadOnly = true;
            // 
            // Pocetak
            // 
            Pocetak.DataPropertyName = "Pocetak";
            Pocetak.HeaderText = "Pocetak";
            Pocetak.MinimumWidth = 6;
            Pocetak.Name = "Pocetak";
            Pocetak.ReadOnly = true;
            // 
            // Kraj
            // 
            Kraj.DataPropertyName = "Kraj";
            Kraj.HeaderText = "Kraj";
            Kraj.MinimumWidth = 6;
            Kraj.Name = "Kraj";
            Kraj.ReadOnly = true;
            // 
            // ECTS
            // 
            ECTS.DataPropertyName = "ECTS";
            ECTS.HeaderText = "ECTS";
            ECTS.MinimumWidth = 6;
            ECTS.Name = "ECTS";
            ECTS.ReadOnly = true;
            // 
            // Okoncana
            // 
            Okoncana.DataPropertyName = "Okoncana";
            Okoncana.HeaderText = "Okoncana";
            Okoncana.MinimumWidth = 6;
            Okoncana.Name = "Okoncana";
            Okoncana.ReadOnly = true;
            Okoncana.Resizable = DataGridViewTriState.True;
            Okoncana.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Obrisi
            // 
            Obrisi.HeaderText = "";
            Obrisi.MinimumWidth = 6;
            Obrisi.Name = "Obrisi";
            Obrisi.ReadOnly = true;
            Obrisi.Text = "Obrisi";
            Obrisi.UseColumnTextForButtonValue = true;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1058, 391);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(94, 29);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "Printaj";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // gbGenerator
            // 
            gbGenerator.Controls.Add(tbInfo);
            gbGenerator.Controls.Add(label9);
            gbGenerator.Controls.Add(btnGenerisi);
            gbGenerator.Controls.Add(tbBrojEcts);
            gbGenerator.Controls.Add(label8);
            gbGenerator.Controls.Add(tbBrojRazmjena);
            gbGenerator.Controls.Add(label7);
            gbGenerator.Controls.Add(cmbUNiThread);
            gbGenerator.Controls.Add(label6);
            gbGenerator.Location = new Point(12, 427);
            gbGenerator.Name = "gbGenerator";
            gbGenerator.Size = new Size(1140, 260);
            gbGenerator.TabIndex = 9;
            gbGenerator.TabStop = false;
            gbGenerator.Text = "Generisi Razmjene:";
            // 
            // tbInfo
            // 
            tbInfo.Location = new Point(245, 62);
            tbInfo.Multiline = true;
            tbInfo.Name = "tbInfo";
            tbInfo.ScrollBars = ScrollBars.Vertical;
            tbInfo.Size = new Size(858, 192);
            tbInfo.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(245, 38);
            label9.Name = "label9";
            label9.Size = new Size(38, 20);
            label9.TabIndex = 5;
            label9.Text = "Info:";
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(8, 159);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(202, 29);
            btnGenerisi.TabIndex = 4;
            btnGenerisi.Text = "Generisi Razmjene =>";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // tbBrojEcts
            // 
            tbBrojEcts.Location = new Point(119, 115);
            tbBrojEcts.Name = "tbBrojEcts";
            tbBrojEcts.Size = new Size(91, 27);
            tbBrojEcts.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(118, 92);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 2;
            label8.Text = "Broj ECTS";
            // 
            // tbBrojRazmjena
            // 
            tbBrojRazmjena.Location = new Point(6, 115);
            tbBrojRazmjena.Name = "tbBrojRazmjena";
            tbBrojRazmjena.Size = new Size(98, 27);
            tbBrojRazmjena.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(0, 92);
            label7.Name = "label7";
            label7.Size = new Size(104, 20);
            label7.TabIndex = 2;
            label7.Text = "Broj razmjena:";
            // 
            // cmbUNiThread
            // 
            cmbUNiThread.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUNiThread.FormattingEnabled = true;
            cmbUNiThread.Location = new Point(6, 61);
            cmbUNiThread.Name = "cmbUNiThread";
            cmbUNiThread.Size = new Size(204, 28);
            cmbUNiThread.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 38);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 0;
            label6.Text = "Univerzitet:";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmRazmjene
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 699);
            Controls.Add(gbGenerator);
            Controls.Add(btnPrint);
            Controls.Add(dgvRazmjene);
            Controls.Add(btnSpasi);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpKraj);
            Controls.Add(dtpPocetak);
            Controls.Add(tbECTS);
            Controls.Add(label3);
            Controls.Add(cmbUni);
            Controls.Add(label2);
            Controls.Add(cmbDrzava);
            Controls.Add(label1);
            Name = "frmRazmjene";
            Text = "frmRazmjene";
            Load += frmRazmjene_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).EndInit();
            gbGenerator.ResumeLayout(false);
            gbGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbDrzava;
        private Label label2;
        private ComboBox cmbUni;
        private Label label3;
        private TextBox tbECTS;
        private DateTimePicker dtpPocetak;
        private Label label4;
        private DateTimePicker dtpKraj;
        private Label label5;
        private Button btnSpasi;
        private DataGridView dgvRazmjene;
        private DataGridViewTextBoxColumn Univerzitet;
        private DataGridViewTextBoxColumn Pocetak;
        private DataGridViewTextBoxColumn Kraj;
        private DataGridViewTextBoxColumn ECTS;
        private DataGridViewCheckBoxColumn Okoncana;
        private DataGridViewButtonColumn Obrisi;
        private Button btnPrint;
        private GroupBox gbGenerator;
        private Button btnGenerisi;
        private TextBox tbBrojEcts;
        private Label label8;
        private TextBox tbBrojRazmjena;
        private Label label7;
        private ComboBox cmbUNiThread;
        private Label label6;
        private TextBox tbInfo;
        private Label label9;
        private ErrorProvider err;
    }
}