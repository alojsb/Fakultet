namespace DLWMS.WinApp.IspitBrojIndeksa
{
    partial class frmStipendijaAddEditBrojIndeksa
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
            cmbStudent = new ComboBox();
            cmbGodina = new ComboBox();
            cmbStipendija = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            btnSacuvaj = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 36);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Student:";
            // 
            // cmbStudent
            // 
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(84, 33);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(204, 23);
            cmbStudent.TabIndex = 1;
            // 
            // cmbGodina
            // 
            cmbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGodina.FormattingEnabled = true;
            cmbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cmbGodina.Location = new Point(84, 62);
            cmbGodina.Name = "cmbGodina";
            cmbGodina.Size = new Size(204, 23);
            cmbGodina.TabIndex = 1;
            cmbGodina.SelectionChangeCommitted += cmbGodina_SelectionChangeCommitted;
            // 
            // cmbStipendija
            // 
            cmbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStipendija.FormattingEnabled = true;
            cmbStipendija.Location = new Point(84, 91);
            cmbStipendija.Name = "cmbStipendija";
            cmbStipendija.Size = new Size(204, 23);
            cmbStipendija.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 65);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 0;
            label2.Text = "Godina:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 94);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 0;
            label3.Text = "Stipendija:";
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(213, 120);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(75, 23);
            btnSacuvaj.TabIndex = 2;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // frmStipendijaAddEditBrojIndeksa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 165);
            Controls.Add(btnSacuvaj);
            Controls.Add(cmbStipendija);
            Controls.Add(cmbGodina);
            Controls.Add(cmbStudent);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmStipendijaAddEditBrojIndeksa";
            Text = "frmStipendijaAddEditBrojIndeksa";
            Load += frmStipendijaAddEditBrojIndeksa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbStudent;
        private ComboBox cmbGodina;
        private ComboBox cmbStipendija;
        private Label label2;
        private Label label3;
        private Button btnSacuvaj;
    }
}