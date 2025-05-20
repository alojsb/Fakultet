namespace Kalkulator
{
    partial class frmCalculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPercent = new Button();
            btnCE = new Button();
            btnC = new Button();
            btnBackspace = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnDivision = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMultiplication = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnSubtraction = new Button();
            btnSignSwitch = new Button();
            btn0 = new Button();
            btnComma = new Button();
            btnAddition = new Button();
            btnEqual = new Button();
            txtDisplayBox = new TextBox();
            lblBuffer = new Label();
            SuspendLayout();
            // 
            // btnPercent
            // 
            btnPercent.Font = new Font("Segoe UI", 18F);
            btnPercent.Location = new Point(3, 59);
            btnPercent.Name = "btnPercent";
            btnPercent.Size = new Size(60, 54);
            btnPercent.TabIndex = 0;
            btnPercent.Text = "%";
            btnPercent.UseVisualStyleBackColor = true;
            // 
            // btnCE
            // 
            btnCE.Font = new Font("Segoe UI", 18F);
            btnCE.Location = new Point(69, 59);
            btnCE.Name = "btnCE";
            btnCE.Size = new Size(60, 54);
            btnCE.TabIndex = 1;
            btnCE.Text = "CE";
            btnCE.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            btnC.Font = new Font("Segoe UI", 18F);
            btnC.Location = new Point(135, 59);
            btnC.Name = "btnC";
            btnC.Size = new Size(60, 54);
            btnC.TabIndex = 2;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = true;
            // 
            // btnBackspace
            // 
            btnBackspace.Font = new Font("Segoe UI", 18F);
            btnBackspace.Location = new Point(201, 59);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(60, 54);
            btnBackspace.TabIndex = 3;
            btnBackspace.Text = "⌫";
            btnBackspace.UseVisualStyleBackColor = true;
            // 
            // btn7
            // 
            btn7.Font = new Font("Segoe UI", 18F);
            btn7.Location = new Point(3, 119);
            btn7.Name = "btn7";
            btn7.Size = new Size(60, 54);
            btn7.TabIndex = 4;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += NumberButton_Click;
            // 
            // btn8
            // 
            btn8.Font = new Font("Segoe UI", 18F);
            btn8.Location = new Point(69, 119);
            btn8.Name = "btn8";
            btn8.Size = new Size(60, 54);
            btn8.TabIndex = 5;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += NumberButton_Click;
            // 
            // btn9
            // 
            btn9.Font = new Font("Segoe UI", 18F);
            btn9.Location = new Point(135, 119);
            btn9.Name = "btn9";
            btn9.Size = new Size(60, 54);
            btn9.TabIndex = 6;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += NumberButton_Click;
            // 
            // btnDivision
            // 
            btnDivision.Font = new Font("Segoe UI", 18F);
            btnDivision.Location = new Point(201, 119);
            btnDivision.Name = "btnDivision";
            btnDivision.Size = new Size(60, 54);
            btnDivision.TabIndex = 7;
            btnDivision.Text = "÷";
            btnDivision.UseVisualStyleBackColor = true;
            btnDivision.Click += btnDivision_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI", 18F);
            btn4.Location = new Point(3, 179);
            btn4.Name = "btn4";
            btn4.Size = new Size(60, 54);
            btn4.TabIndex = 8;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += NumberButton_Click;
            // 
            // btn5
            // 
            btn5.Font = new Font("Segoe UI", 18F);
            btn5.Location = new Point(69, 179);
            btn5.Name = "btn5";
            btn5.Size = new Size(60, 54);
            btn5.TabIndex = 9;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += NumberButton_Click;
            // 
            // btn6
            // 
            btn6.Font = new Font("Segoe UI", 18F);
            btn6.Location = new Point(135, 179);
            btn6.Name = "btn6";
            btn6.Size = new Size(60, 54);
            btn6.TabIndex = 10;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += NumberButton_Click;
            // 
            // btnMultiplication
            // 
            btnMultiplication.Font = new Font("Segoe UI", 18F);
            btnMultiplication.Location = new Point(201, 179);
            btnMultiplication.Name = "btnMultiplication";
            btnMultiplication.Size = new Size(60, 54);
            btnMultiplication.TabIndex = 11;
            btnMultiplication.Text = "×";
            btnMultiplication.UseVisualStyleBackColor = true;
            btnMultiplication.Click += btnMultiplication_Click;
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 18F);
            btn1.Location = new Point(3, 239);
            btn1.Name = "btn1";
            btn1.Size = new Size(60, 54);
            btn1.TabIndex = 12;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += NumberButton_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 18F);
            btn2.Location = new Point(69, 239);
            btn2.Name = "btn2";
            btn2.Size = new Size(60, 54);
            btn2.TabIndex = 13;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += NumberButton_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI", 18F);
            btn3.Location = new Point(135, 239);
            btn3.Name = "btn3";
            btn3.Size = new Size(60, 54);
            btn3.TabIndex = 14;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += NumberButton_Click;
            // 
            // btnSubtraction
            // 
            btnSubtraction.Font = new Font("Segoe UI", 18F);
            btnSubtraction.Location = new Point(201, 239);
            btnSubtraction.Name = "btnSubtraction";
            btnSubtraction.Size = new Size(60, 54);
            btnSubtraction.TabIndex = 15;
            btnSubtraction.Text = "−";
            btnSubtraction.UseVisualStyleBackColor = true;
            btnSubtraction.Click += btnSubtraction_Click;
            // 
            // btnSignSwitch
            // 
            btnSignSwitch.Font = new Font("Segoe UI", 18F);
            btnSignSwitch.Location = new Point(3, 299);
            btnSignSwitch.Name = "btnSignSwitch";
            btnSignSwitch.Size = new Size(60, 54);
            btnSignSwitch.TabIndex = 16;
            btnSignSwitch.Text = "+∕−";
            btnSignSwitch.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            btn0.Font = new Font("Segoe UI", 18F);
            btn0.Location = new Point(69, 299);
            btn0.Name = "btn0";
            btn0.Size = new Size(60, 54);
            btn0.TabIndex = 17;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += NumberButton_Click;
            // 
            // btnComma
            // 
            btnComma.Font = new Font("Segoe UI", 18F);
            btnComma.Location = new Point(135, 299);
            btnComma.Name = "btnComma";
            btnComma.Size = new Size(60, 54);
            btnComma.TabIndex = 18;
            btnComma.Text = ",";
            btnComma.UseVisualStyleBackColor = true;
            btnComma.Click += NumberButton_Click;
            // 
            // btnAddition
            // 
            btnAddition.Font = new Font("Segoe UI", 18F);
            btnAddition.Location = new Point(201, 299);
            btnAddition.Name = "btnAddition";
            btnAddition.Size = new Size(60, 54);
            btnAddition.TabIndex = 19;
            btnAddition.Text = "+";
            btnAddition.UseVisualStyleBackColor = true;
            btnAddition.Click += btnAddition_Click;
            // 
            // btnEqual
            // 
            btnEqual.Font = new Font("Segoe UI", 18F);
            btnEqual.Location = new Point(3, 359);
            btnEqual.Name = "btnEqual";
            btnEqual.Size = new Size(126, 54);
            btnEqual.TabIndex = 20;
            btnEqual.Text = "=";
            btnEqual.UseVisualStyleBackColor = true;
            btnEqual.Click += btnEqual_Click;
            // 
            // txtDisplayBox
            // 
            txtDisplayBox.Font = new Font("Segoe UI", 24F);
            txtDisplayBox.Location = new Point(3, 0);
            txtDisplayBox.Name = "txtDisplayBox";
            txtDisplayBox.ReadOnly = true;
            txtDisplayBox.RightToLeft = RightToLeft.Yes;
            txtDisplayBox.Size = new Size(258, 50);
            txtDisplayBox.TabIndex = 21;
            txtDisplayBox.Text = "0";
            // 
            // lblBuffer
            // 
            lblBuffer.AutoSize = true;
            lblBuffer.Location = new Point(178, 384);
            lblBuffer.Name = "lblBuffer";
            lblBuffer.Size = new Size(38, 15);
            lblBuffer.TabIndex = 22;
            lblBuffer.Text = "label1";
            // 
            // frmCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 414);
            Controls.Add(lblBuffer);
            Controls.Add(txtDisplayBox);
            Controls.Add(btnEqual);
            Controls.Add(btnAddition);
            Controls.Add(btnComma);
            Controls.Add(btn0);
            Controls.Add(btnSignSwitch);
            Controls.Add(btnSubtraction);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(btnMultiplication);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btnDivision);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btnBackspace);
            Controls.Add(btnC);
            Controls.Add(btnCE);
            Controls.Add(btnPercent);
            Name = "frmCalculator";
            Text = "Kalkulator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPercent;
        private Button btnCE;
        private Button btnC;
        private Button btnBackspace;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnDivision;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnMultiplication;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btnSubtraction;
        private Button btnSignSwitch;
        private Button btn0;
        private Button btnComma;
        private Button btnAddition;
        private Button btnEqual;
        private TextBox txtDisplayBox;
        private Label lblBuffer;
    }
}
