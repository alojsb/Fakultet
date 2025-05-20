using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyGameStore.Data;

namespace TinyGameStore
{
    public partial class frmStore : Form
    {
        private User CurrentUser { get; set; }

        public frmStore()
        {
            InitializeComponent();
        }

        public frmStore(User user) : this()
        {
            CurrentUser = user;
        }

        private void frmStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmStore_Shown(object sender, EventArgs e)
        {
            lblUsername.Text = CurrentUser.Username;
        }
    }
}
