using TinyGameStore.Data;
using TinyGameStore.InMemory;

namespace TinyGameStore
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtUsername.Text) || !string.IsNullOrEmpty(txtPassword.Text))
            {
                var user = new User() { Username = txtUsername.Text, Password = txtPassword.Text };
                var result = InMemoryDb.Authenticate(user);
                if (result == null)
                {
                    MessageBox.Show(
                        "Failed to authenticate", 
                        "Tiny Game Store", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    var frm = new frmStore(user);
                    frm.Show();
                    this.Hide();
                }
                //else (alternative)
                //{
                //    this.Hide();
                //    var frm = new frmStore(user);
                //    frm.ShowDialog();
                //    this.Show();
                //}
            }
        }

        private void btnSignIn_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(sender, e);
            }
        }
    }
}
