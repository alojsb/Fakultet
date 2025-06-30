namespace DLWMS.WinApp.IspitBrojIndeksa
{
    partial class frmStudentEditBrojIndeksa
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
            pbSlika = new PictureBox();
            btnUcitajSliku = new Button();
            btnSacuvaj = new Button();
            lblImePrezime = new Label();
            lblBrojIndeksa = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbDrzava = new ComboBox();
            cmbGrad = new ComboBox();
            ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbSlika).BeginInit();
            SuspendLayout();
            // 
            // pbSlika
            // 
            pbSlika.Location = new Point(12, 12);
            pbSlika.Name = "pbSlika";
            pbSlika.Size = new Size(251, 294);
            pbSlika.SizeMode = PictureBoxSizeMode.Zoom;
            pbSlika.TabIndex = 0;
            pbSlika.TabStop = false;
            // 
            // btnUcitajSliku
            // 
            btnUcitajSliku.Location = new Point(12, 312);
            btnUcitajSliku.Name = "btnUcitajSliku";
            btnUcitajSliku.Size = new Size(251, 44);
            btnUcitajSliku.TabIndex = 1;
            btnUcitajSliku.Text = "Učitaj sliku";
            btnUcitajSliku.UseVisualStyleBackColor = true;
            btnUcitajSliku.Click += btnUcitajSliku_Click;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(419, 312);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(159, 44);
            btnSacuvaj.TabIndex = 1;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // lblImePrezime
            // 
            lblImePrezime.AutoSize = true;
            lblImePrezime.Font = new Font("Segoe UI", 24F);
            lblImePrezime.Location = new Point(319, 41);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(105, 45);
            lblImePrezime.TabIndex = 2;
            lblImePrezime.Text = "label1";
            // 
            // lblBrojIndeksa
            // 
            lblBrojIndeksa.AutoSize = true;
            lblBrojIndeksa.Font = new Font("Segoe UI", 18F);
            lblBrojIndeksa.Location = new Point(319, 125);
            lblBrojIndeksa.Name = "lblBrojIndeksa";
            lblBrojIndeksa.Size = new Size(78, 32);
            lblBrojIndeksa.TabIndex = 2;
            lblBrojIndeksa.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 222);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "Država:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(319, 250);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 2;
            label4.Text = "Grad:";
            // 
            // cmbDrzava
            // 
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(370, 219);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(208, 23);
            cmbDrzava.TabIndex = 3;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbGrad
            // 
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(370, 247);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(208, 23);
            cmbGrad.TabIndex = 3;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // frmStudentEditBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 368);
            Controls.Add(cmbGrad);
            Controls.Add(cmbDrzava);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblBrojIndeksa);
            Controls.Add(lblImePrezime);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnUcitajSliku);
            Controls.Add(pbSlika);
            Name = "frmStudentEditBrojIndeksa";
            Text = "frmStudentEditBrojIndeksa";
            Load += frmStudentEditBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)pbSlika).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSlika;
        private Button btnUcitajSliku;
        private Button btnSacuvaj;
        private Label lblImePrezime;
        private Label lblBrojIndeksa;
        private Label label3;
        private Label label4;
        private ComboBox cmbDrzava;
        private ComboBox cmbGrad;
        private OpenFileDialog ofd;
    }
}