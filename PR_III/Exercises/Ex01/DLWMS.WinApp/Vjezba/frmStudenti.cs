using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.Vjezba
{
    public partial class frmStudenti : Form
    {
        DLWMSContext _db = new DLWMSContext();

        public frmStudenti()
        {
            InitializeComponent();
            dgvStudenti.AutoGenerateColumns = false;
        }

        private void frmStudenti_Load(object sender, EventArgs e)
        {
            dgvStudenti.DataSource = _db.Studenti
                .Include(s => s.Grad)
                .Include(s => s.Spol)
                .ToList();
        }
    }
}
