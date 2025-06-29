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
            pbProfilnaSlika = new PictureBox();
            cmbDrzava = new ComboBox();
            cmbGrad = new ComboBox();
            lblImePrezime = new Label();
            lblBrojIndeksa = new Label();
            lblDrzava = new Label();
            lblGrad = new Label();
            btnUcitajSliku = new Button();
            btnSacuvaj = new Button();
            ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbProfilnaSlika).BeginInit();
            SuspendLayout();
            // 
            // pbProfilnaSlika
            // 
            pbProfilnaSlika.Location = new Point(12, 12);
            pbProfilnaSlika.Name = "pbProfilnaSlika";
            pbProfilnaSlika.Size = new Size(236, 287);
            pbProfilnaSlika.SizeMode = PictureBoxSizeMode.Zoom;
            pbProfilnaSlika.TabIndex = 0;
            pbProfilnaSlika.TabStop = false;
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(357, 226);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(260, 23);
            cmbDrzava.TabIndex = 1;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbGrad
            // 
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(357, 255);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(260, 23);
            cmbGrad.TabIndex = 2;
            // 
            // lblImePrezime
            // 
            lblImePrezime.AutoSize = true;
            lblImePrezime.Font = new Font("Segoe UI", 24F);
            lblImePrezime.Location = new Point(287, 32);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(105, 45);
            lblImePrezime.TabIndex = 3;
            lblImePrezime.Text = "label1";
            // 
            // lblBrojIndeksa
            // 
            lblBrojIndeksa.AutoSize = true;
            lblBrojIndeksa.Font = new Font("Segoe UI", 18F);
            lblBrojIndeksa.Location = new Point(287, 108);
            lblBrojIndeksa.Name = "lblBrojIndeksa";
            lblBrojIndeksa.Size = new Size(78, 32);
            lblBrojIndeksa.TabIndex = 4;
            lblBrojIndeksa.Text = "label2";
            // 
            // lblDrzava
            // 
            lblDrzava.AutoSize = true;
            lblDrzava.Location = new Point(287, 229);
            lblDrzava.Name = "lblDrzava";
            lblDrzava.Size = new Size(45, 15);
            lblDrzava.TabIndex = 5;
            lblDrzava.Text = "Država:";
            // 
            // lblGrad
            // 
            lblGrad.AutoSize = true;
            lblGrad.Location = new Point(287, 263);
            lblGrad.Name = "lblGrad";
            lblGrad.Size = new Size(35, 15);
            lblGrad.TabIndex = 6;
            lblGrad.Text = "Grad:";
            // 
            // btnUcitajSliku
            // 
            btnUcitajSliku.Location = new Point(12, 305);
            btnUcitajSliku.Name = "btnUcitajSliku";
            btnUcitajSliku.Size = new Size(236, 39);
            btnUcitajSliku.TabIndex = 7;
            btnUcitajSliku.Text = "Učitaj sliku";
            btnUcitajSliku.UseVisualStyleBackColor = true;
            btnUcitajSliku.Click += btnUcitajSliku_Click;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(542, 321);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(75, 23);
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
            ClientSize = new Size(665, 356);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnUcitajSliku);
            Controls.Add(lblGrad);
            Controls.Add(lblDrzava);
            Controls.Add(lblBrojIndeksa);
            Controls.Add(lblImePrezime);
            Controls.Add(cmbGrad);
            Controls.Add(cmbDrzava);
            Controls.Add(pbProfilnaSlika);
            Name = "frmStudentEditBrojIndeksa";
            Text = "frmStudentEditBrojIndeksa";
            Load += frmStudentEditBrojIndeksa_Load;
            ((System.ComponentModel.ISupportInitialize)pbProfilnaSlika).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbProfilnaSlika;
        private ComboBox cmbDrzava;
        private ComboBox cmbGrad;
        private Label lblImePrezime;
        private Label lblBrojIndeksa;
        private Label lblDrzava;
        private Label lblGrad;
        private Button btnUcitajSliku;
        private Button btnSacuvaj;
        private OpenFileDialog ofd;
    }
}