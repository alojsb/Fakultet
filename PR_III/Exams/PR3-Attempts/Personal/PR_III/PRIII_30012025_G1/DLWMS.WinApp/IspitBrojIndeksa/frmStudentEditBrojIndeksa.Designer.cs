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
            pbProfilna = new PictureBox();
            btnUcitajSliku = new Button();
            lblImePrezime = new Label();
            lblBrojIndeksa = new Label();
            lblDrzava = new Label();
            lblGrad = new Label();
            cmbDrzava = new ComboBox();
            cmbGrad = new ComboBox();
            btnSacuvaj = new Button();
            ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbProfilna).BeginInit();
            SuspendLayout();
            // 
            // pbProfilna
            // 
            pbProfilna.Location = new Point(22, 24);
            pbProfilna.Name = "pbProfilna";
            pbProfilna.Size = new Size(245, 258);
            pbProfilna.SizeMode = PictureBoxSizeMode.Zoom;
            pbProfilna.TabIndex = 0;
            pbProfilna.TabStop = false;
            // 
            // btnUcitajSliku
            // 
            btnUcitajSliku.Location = new Point(22, 306);
            btnUcitajSliku.Name = "btnUcitajSliku";
            btnUcitajSliku.Size = new Size(245, 31);
            btnUcitajSliku.TabIndex = 1;
            btnUcitajSliku.Text = "Učitaj sliku";
            btnUcitajSliku.UseVisualStyleBackColor = true;
            btnUcitajSliku.Click += btnUcitajSliku_Click;
            // 
            // lblImePrezime
            // 
            lblImePrezime.AutoSize = true;
            lblImePrezime.Font = new Font("Segoe UI", 32F);
            lblImePrezime.Location = new Point(314, 24);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(137, 59);
            lblImePrezime.TabIndex = 2;
            lblImePrezime.Text = "label1";
            // 
            // lblBrojIndeksa
            // 
            lblBrojIndeksa.AutoSize = true;
            lblBrojIndeksa.Font = new Font("Segoe UI", 24F);
            lblBrojIndeksa.Location = new Point(314, 139);
            lblBrojIndeksa.Name = "lblBrojIndeksa";
            lblBrojIndeksa.Size = new Size(105, 45);
            lblBrojIndeksa.TabIndex = 3;
            lblBrojIndeksa.Text = "label2";
            // 
            // lblDrzava
            // 
            lblDrzava.AutoSize = true;
            lblDrzava.Location = new Point(314, 219);
            lblDrzava.Name = "lblDrzava";
            lblDrzava.Size = new Size(45, 15);
            lblDrzava.TabIndex = 4;
            lblDrzava.Text = "Država:";
            // 
            // lblGrad
            // 
            lblGrad.AutoSize = true;
            lblGrad.Location = new Point(314, 259);
            lblGrad.Name = "lblGrad";
            lblGrad.Size = new Size(35, 15);
            lblGrad.TabIndex = 5;
            lblGrad.Text = "Grad:";
            // 
            // cmbDrzava
            // 
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(404, 216);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(217, 23);
            cmbDrzava.TabIndex = 6;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbGrad
            // 
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(404, 256);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(217, 23);
            cmbGrad.TabIndex = 7;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(507, 303);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(114, 31);
            btnSacuvaj.TabIndex = 8;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // frmStudentEditBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 362);
            Controls.Add(btnSacuvaj);
            Controls.Add(cmbGrad);
            Controls.Add(cmbDrzava);
            Controls.Add(lblGrad);
            Controls.Add(lblDrzava);
            Controls.Add(lblBrojIndeksa);
            Controls.Add(lblImePrezime);
            Controls.Add(btnUcitajSliku);
            Controls.Add(pbProfilna);
            Name = "frmStudentEditBrojIndeksa";
            Text = "Podaci o studentu";
            Load += frmStudentEditBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)pbProfilna).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbProfilna;
        private Button btnUcitajSliku;
        private Label lblImePrezime;
        private Label lblBrojIndeksa;
        private Label lblDrzava;
        private Label lblGrad;
        private ComboBox cmbDrzava;
        private ComboBox cmbGrad;
        private Button btnSacuvaj;
        private OpenFileDialog ofd;
    }
}