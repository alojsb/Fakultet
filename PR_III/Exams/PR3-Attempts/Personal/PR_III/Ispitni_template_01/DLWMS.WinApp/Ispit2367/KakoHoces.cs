using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLWMS.Data;
using DLWMS.WinApp;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Ispit2367;
using DLWMS.WinApp.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DLWMS.WinApp._2367
{
    public partial class frmKakoHoces : Form
    {
        private readonly DLWMSContext _DLWMSContext = SharedBrojIndeksa.DLWMSContext;

        public frmKakoHoces()
        {
            InitializeComponent();
        }

        private void frmKakoHoces_Load(object sender, EventArgs e)
        {
            UcitajSveStudente();
            UcitajSveSpolove();
            UcitajSveDrzave();
        }

        private void UcitajSveDrzave()
        {
            cbDrzava.UcitajPodatke(_DLWMSContext.Drzave.ToList());
            cbDrzava.SelectedIndex = -1;
        }

        private void UcitajSveSpolove()
        {
            var spolList = _DLWMSContext.Spol.ToList(); // This queries 'Spol' from the database

            cbSpol.UcitajPodatke(spolList);
            cbSpol.SelectedIndex = -1;
        }

        private void UcitajSveStudente()
        {
            var studenti = _DLWMSContext.Studenti.ToList();
            dataGridView1.DataSource = studenti;
        }

        private void cbSpol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void cbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void FilterStudents()
        {
            // Start with the base query (include navigation properties if needed).
            var query = _DLWMSContext.Studenti
                .Include(s => s.Grad)
                .Include(s => s.Spol)
                .AsQueryable();

            // If the user picked a Spol, filter by SpolId
            if (cbSpol.SelectedIndex > -1)
            {
                int selectedSpolId = (int)cbSpol.SelectedValue;
                query = query.Where(s => s.SpolId == selectedSpolId);
            }

            // If the user picked a Drzava, filter by DrzavaId
            if (cbDrzava.SelectedIndex > -1)
            {
                int selectedDrzavaId = (int)cbDrzava.SelectedValue;
                query = query.Where(s => s.Grad.DrzavaId == selectedDrzavaId);
            }

            // Finally, execute the query and show the results.
            dataGridView1.DataSource = query.ToList();
        }
    }
}
