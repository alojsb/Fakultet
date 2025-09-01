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
            OsvjeziStipendije();
            OsvjeziStudentiStipendije();
        }

        private void OsvjeziStudentiStipendije()
        {
            var query = _dbContext.StudentiStipendijeBrojIndeksa
                .Include(ss => ss.StipendijaGodina)
                    .ThenInclude(sg => sg.Stipendija)
                .Include(ss => ss.Student)
                .AsQueryable();

            if (cmbGodina.SelectedItem != null)
            {
                query = query.Where(sg => sg.StipendijaGodina.Godina == int.Parse(cmbGodina.SelectedItem.ToString()!));
            }

            if (cmbStipendija.SelectedValue != null)
            {
                query = query.Where(sg => sg.StipendijaGodina.StipendijaId == (int)cmbStipendija.SelectedValue);
            }

            var studentiStipendije = query.ToList();

            this.Text = $"Broj prikazanih studenata-stipendija: {studentiStipendije.Count()}";

            dgvStudentiStipendije.DataSource = studentiStipendije;

            if (studentiStipendije.Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {cmbGodina.Text}. godini dodijeljena {cmbStipendija.Text} stipendija.");
            }
        }

        private void OsvjeziStipendije()
        {
            var odabranaGodina = int.Parse(cmbGodina.SelectedItem.ToString()!);

            var stipendijeOdabraneGodine = _dbContext.StipendijeGodineBrojIndeksa
                .Where(sg => sg.Godina == odabranaGodina)
                .Select(sg => sg.Stipendija)
                .ToList();

            cmbStipendija.UcitajPodatke(stipendijeOdabraneGodine);
        }

        private void dgvStudentiStipendije_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;
            var kolona = dgvStudentiStipendije.Columns[e.ColumnIndex].Name;

            if (kolona == "ImePrezime")
            {
                e.Value = $"({studentStipendija.Student.BrojIndeksa}) {studentStipendija.Student.Ime} {studentStipendija.Student.Prezime}";
            }
            else if (kolona == "Godina")
            {
                e.Value = studentStipendija.StipendijaGodina.Godina;
            }
            else if (kolona == "Stipendija")
            {
                e.Value = studentStipendija.StipendijaGodina.Stipendija.Naziv;
            }
            else if (kolona == "MjesecniIznos")
            {
                e.Value = studentStipendija.StipendijaGodina.MjesecniIznos;
            }
            else if (kolona == "Ukupno")
            {
                e.Value = ProracunUkupno(studentStipendija);
            }
        }

        private int ProracunUkupno(StudentStipendijaBrojIndeksa ss)
        {
            if (ss.StipendijaGodina.Godina == DateTime.Now.Year)
            {
                return ss.StipendijaGodina.MjesecniIznos * DateTime.Now.Month;
            }
            return ss.StipendijaGodina.MjesecniIznos * 12;

        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziStipendije();
            OsvjeziStudentiStipendije();
        }

        private void cmbStipendija_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziStudentiStipendije();
        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvStudentiStipendije.Columns[e.ColumnIndex].Name == "Ukloni")
                {
                    var odgovor = MessageBox.Show("Da li ste sigurni da želite ukloniti dabrani zapis o dodijeljenoj stipendiji?", "Upit", MessageBoxButtons.YesNo);

                    if (odgovor == DialogResult.Yes)
                    {
                        var odabranaStudentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;

                        _dbContext.StudentiStipendijeBrojIndeksa.Remove(odabranaStudentStipendija);
                        _dbContext.SaveChanges();
                        OsvjeziStudentiStipendije();
                    }
                }
            }
        }

        private void btnDodajStipendiju_Click(object sender, EventArgs e)
        {
            var nova = new frmStipendijaAddEditBrojIndeksa(_dbContext);
            nova.ShowDialog();
            OsvjeziStudentiStipendije();
        }

        private void dgvStudentiStipendije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;

                var nova = new frmStipendijaAddEditBrojIndeksa(_dbContext, studentStipendija);
                nova.ShowDialog();
                OsvjeziStudentiStipendije();
            }
        }
    }
}
