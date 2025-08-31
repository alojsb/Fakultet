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
            cmbGodina.SelectedIndex = 0;
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
            var query = _dbContext.StudentiStipendijeBrojIndeksa
                .Include(ss => ss.StipendijaGodina)
                    .ThenInclude(sg => sg.Stipendija)
                .Include(ss => ss.Student)
                .AsQueryable();

            if (cmbGodina.SelectedItem != null)
            {
                query = query.Where(ss => ss.StipendijaGodina.Godina == int.Parse(cmbGodina.SelectedItem.ToString()!));
            }

            if (cmbStipendija.SelectedValue != null)
            {
                query = query.Where(ss => ss.StipendijaGodina.StipendijaId == (int)cmbStipendija.SelectedValue);
            }

            var studentiStipendije = query.ToList();

            this.Text = $"Broj prokazanih studenata: {studentiStipendije.Count()}";

            dgvStudentiStipendije.DataSource = studentiStipendije;

            if (studentiStipendije.Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {cmbGodina.Text}. godini dodijeljena {cmbStipendija.Text} stipendija");
            }
        }

        private void dgvStudentiStipendije_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;
            var kolona = dgvStudentiStipendije.Columns[e.ColumnIndex].Name;

            if (kolona == "Stipendija")
            {
                e.Value = studentStipendija.StipendijaGodina.Stipendija.Naziv;
            }
            else if (kolona == "Godina")
            {
                e.Value = studentStipendija.StipendijaGodina.Godina;
            }
            else if (kolona == "ImePrezime")
            {
                e.Value = $"({studentStipendija.Student.BrojIndeksa}) {studentStipendija.Student.Ime} {studentStipendija.Student.Prezime}";
            }
            else if (kolona == "MjesecniIznos")
            {
                e.Value = studentStipendija.StipendijaGodina.MjesecniIznos;
            }
            else if (kolona == "Ukupno")
            {
                e.Value = IzracunUkupno(studentStipendija);
            }
        }

        private int IzracunUkupno(StudentStipendijaBrojIndeksa ss)
        {
            if (ss.StipendijaGodina.Godina == DateTime.Now.Year)
            {
                return ss.StipendijaGodina.MjesecniIznos * DateTime.Now.Month;
            }
            return ss.StipendijaGodina.MjesecniIznos * 12;
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

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudentiStipendije.Columns[e.ColumnIndex].Name == "Ukloni")
            {
                var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;

                var odg = MessageBox.Show("Da li ste sigurni?", "Upit", MessageBoxButtons.YesNo);

                if (odg == DialogResult.Yes)
                {
                    _dbContext.StudentiStipendijeBrojIndeksa.Remove(studentStipendija);
                    _dbContext.SaveChanges();
                    UcitajStudenteStipendije();
                }
            }
        }
    }
}
