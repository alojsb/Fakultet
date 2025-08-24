using DLWMS.Data;
using DLWMS.Data.IspitBrojIndeksa;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
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

namespace DLWMS.WinApp.IspitBrojIndeksa
{
    public partial class frmPretragaBrojIndeksa : Form
    {
        DLWMSContext _dbContext;

        public frmPretragaBrojIndeksa()
        {
            InitializeComponent();
            _dbContext = new DLWMSContext();

            dgvStudentiStipendije.AutoGenerateColumns = false;
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            UcitajStipendije();
            UcitajStudenteStipendije();
        }

        private void UcitajStipendije()
        {
            if (cmbGodina.SelectedItem == null)
            {
                return;
            }

            int odabranaGodina = int.Parse(cmbGodina.SelectedItem.ToString()!);

            var stipendije = _dbContext.StipendijeGodineBrojIndeksa
                .Where(sg => sg.Godina == odabranaGodina)
                .Select(sg => sg.Stipendija)
                .ToList();

            cmbStipendija.UcitajPodatke(stipendije);
        }

        private void UcitajStudenteStipendije()
        {
            if (cmbGodina.SelectedItem == null || cmbStipendija.SelectedItem == null)
                return;

            int odabranaGodina = int.Parse(cmbGodina.SelectedItem.ToString()!);
            var odabranaStipendija = cmbStipendija.SelectedItem as StipendijaBrojIndeksa;

            if (odabranaStipendija == null)
                return;

            var query = _dbContext.StudentiStipendijeBrojIndeksa
                .Include(ss => ss.StipendijaGodina)
                    .ThenInclude(sg => sg.Stipendija)
                .Include(ss => ss.Student)
                .Where(ss =>
                    ss.StipendijaGodina.Godina == odabranaGodina &&
                    ss.StipendijaGodina.Stipendija.Id == odabranaStipendija.Id)
                .ToList();

            dgvStudentiStipendije.DataSource = query;
        }

        private void dgvStudentiStipendije_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var StudentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;
            var kolona = dgvStudentiStipendije.Columns[e.ColumnIndex].Name;

            if (kolona == "Stipendija")
            {
                e.Value = StudentStipendija.StipendijaGodina.Stipendija.Naziv;
            }
            else if (kolona == "Godina")
            {
                e.Value = StudentStipendija.StipendijaGodina.Godina;
            }
            else if (kolona == "ImePrezime")
            {
                e.Value = $"({StudentStipendija.Student.BrojIndeksa}) {StudentStipendija.Student.Ime} {StudentStipendija.Student.Prezime}";
            }
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajStipendije();
            UcitajStudenteStipendije();
        }

        private void cmbStipendija_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajStudenteStipendije();
        }
    }
}
