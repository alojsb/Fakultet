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
            lblIndeks = new Label();
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
            pbSlika.Size = new Size(242, 292);
            pbSlika.SizeMode = PictureBoxSizeMode.Zoom;
            pbSlika.TabIndex = 0;
            pbSlika.TabStop = false;
            // 
            // btnUcitajSliku
            // 
            btnUcitajSliku.Location = new Point(12, 310);
            btnUcitajSliku.Name = "btnUcitajSliku";
            btnUcitajSliku.Size = new Size(242, 40);
            btnUcitajSliku.TabIndex = 1;
            btnUcitajSliku.Text = "Učitaj sliku";
            btnUcitajSliku.UseVisualStyleBackColor = true;
            btnUcitajSliku.Click += btnUcitajSliku_Click;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(453, 310);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(120, 40);
            btnSacuvaj.TabIndex = 1;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // lblImePrezime
            // 
            lblImePrezime.AutoSize = true;
            lblImePrezime.Font = new Font("Segoe UI", 24F);
            lblImePrezime.Location = new Point(306, 43);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(105, 45);
            lblImePrezime.TabIndex = 2;
            lblImePrezime.Text = "label1";
            // 
            // lblIndeks
            // 
            lblIndeks.AutoSize = true;
            lblIndeks.Font = new Font("Segoe UI", 18F);
            lblIndeks.Location = new Point(306, 128);
            lblIndeks.Name = "lblIndeks";
            lblIndeks.Size = new Size(78, 32);
            lblIndeks.TabIndex = 2;
            lblIndeks.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(306, 203);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "Država:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(306, 234);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 2;
            label4.Text = "Grad:";
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(359, 200);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(214, 23);
            cmbDrzava.TabIndex = 3;
            cmbDrzava.SelectionChangeCommitted += cmbDrzava_SelectionChangeCommitted;
            // 
            // cmbGrad
            // 
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(359, 231);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(214, 23);
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
            ClientSize = new Size(603, 362);
            Controls.Add(cmbGrad);
            Controls.Add(cmbDrzava);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblIndeks);
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
        private Label lblIndeks;
        private Label label3;
        private Label label4;
        private ComboBox cmbDrzava;
        private ComboBox cmbGrad;
        private OpenFileDialog ofd;
    }
}