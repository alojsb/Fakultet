using System.Data;

namespace Kalkulator
{
    public enum Operations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    public partial class frmCalculator : Form
    {
        private double Buffer { get; set; } = double.NaN;
        private Stack<Operations> OpStack = new Stack<Operations>();

        public frmCalculator()
        {
            InitializeComponent();
            OpStack = new Stack<Operations>();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {

                if (btn.Text == ",")
                {
                    if (!txtDisplayBox.Text.Contains(","))
                    {
                        txtDisplayBox.Text += ",";
                    }
                }
                else
                {
                    txtDisplayBox.Text += btn.Text;
                }
            }
        }

        private void PrepOperation()
        {
            if (double.IsNaN(Buffer))
            {
                Buffer = double.Parse(txtDisplayBox.Text);
                lblBuffer.Text = txtDisplayBox.Text;
            }
            else if (OpStack.Count > 0)
            {
                var op = OpStack.Pop();
                Evaluate(op);
            }
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            PrepOperation();

            OpStack.Push(Operations.Addition);
            txtDisplayBox.Clear();
        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            PrepOperation();

            OpStack.Push(Operations.Subtraction);
            txtDisplayBox.Clear();
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            PrepOperation();

            OpStack.Push(Operations.Multiplication);
            txtDisplayBox.Clear();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            PrepOperation();

            OpStack.Push(Operations.Division);
            txtDisplayBox.Clear();
        }

        private void Evaluate(Operations op)
        {
            switch (op)
            {
                case Operations.Addition:
                    Buffer += double.Parse(txtDisplayBox.Text);
                    break;
                case Operations.Subtraction:
                    Buffer -= double.Parse(txtDisplayBox.Text);
                    break;
                case Operations.Multiplication:
                    Buffer *= double.Parse(txtDisplayBox.Text);
                    break;
                case Operations.Division:
                    Buffer /= double.Parse(txtDisplayBox.Text);
                    break;
                default:
                    break;
            }

            txtDisplayBox.Text = Buffer.ToString();
            lblBuffer.Text = Buffer.ToString();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplayBox.Text))
            {
                if (OpStack.Count != 0)
                {
                    var op = OpStack.Pop();
                    Evaluate(op);
                }
            }

            txtDisplayBox.Text = Buffer.ToString();
            lblBuffer.Text = Buffer.ToString();
            OpStack.Clear();
        }
    }
}
