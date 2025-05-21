namespace DLWMS.WinApp.IB220347
{
    partial class frmStudentEdit
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
            pictureBox1 = new PictureBox();
            btnUcitajSliku = new Button();
            lblImePrezime = new Label();
            lblIndeks = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbDrzava = new ComboBox();
            cmbGrad = new ComboBox();
            btnSpasi = new Button();
            ofd = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(246, 271);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnUcitajSliku
            // 
            btnUcitajSliku.Location = new Point(12, 298);
            btnUcitajSliku.Name = "btnUcitajSliku";
            btnUcitajSliku.Size = new Size(246, 29);
            btnUcitajSliku.TabIndex = 1;
            btnUcitajSliku.Text = "Ucitaj sliku";
            btnUcitajSliku.UseVisualStyleBackColor = true;
            btnUcitajSliku.Click += btnUcitajSliku_Click;
            // 
            // lblImePrezime
            // 
            lblImePrezime.AutoSize = true;
            lblImePrezime.Font = new Font("Segoe UI", 21F);
            lblImePrezime.Location = new Point(304, 26);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(112, 47);
            lblImePrezime.TabIndex = 2;
            lblImePrezime.Text = "label1";
            // 
            // lblIndeks
            // 
            lblIndeks.AutoSize = true;
            lblIndeks.Font = new Font("Segoe UI", 15F);
            lblIndeks.Location = new Point(304, 105);
            lblIndeks.Name = "lblIndeks";
            lblIndeks.Size = new Size(81, 35);
            lblIndeks.TabIndex = 3;
            lblIndeks.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 220);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 4;
            label3.Text = "Drzzava:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(304, 263);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 5;
            label4.Text = "Grad:";
            // 
            // cmbDrzava
            // 
            cmbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrzava.FormattingEnabled = true;
            cmbDrzava.Location = new Point(385, 217);
            cmbDrzava.Name = "cmbDrzava";
            cmbDrzava.Size = new Size(223, 28);
            cmbDrzava.TabIndex = 6;
            cmbDrzava.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // cmbGrad
            // 
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(385, 260);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(223, 28);
            cmbGrad.TabIndex = 7;
            // 
            // btnSpasi
            // 
            btnSpasi.Location = new Point(514, 298);
            btnSpasi.Name = "btnSpasi";
            btnSpasi.Size = new Size(94, 29);
            btnSpasi.TabIndex = 8;
            btnSpasi.Text = "Spasi";
            btnSpasi.UseVisualStyleBackColor = true;
            btnSpasi.Click += btnSpasi_Click;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmStudentEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 361);
            Controls.Add(btnSpasi);
            Controls.Add(cmbGrad);
            Controls.Add(cmbDrzava);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblIndeks);
            Controls.Add(lblImePrezime);
            Controls.Add(btnUcitajSliku);
            Controls.Add(pictureBox1);
            Name = "frmStudentEdit";
            Text = "frmStudentEdit";
            Load += frmStudentEdit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnUcitajSliku;
        private Label lblImePrezime;
        private Label lblIndeks;
        private Label label3;
        private Label label4;
        private ComboBox cmbDrzava;
        private ComboBox cmbGrad;
        private Button btnSpasi;
        private OpenFileDialog ofd;
        private ErrorProvider err;
    }
}