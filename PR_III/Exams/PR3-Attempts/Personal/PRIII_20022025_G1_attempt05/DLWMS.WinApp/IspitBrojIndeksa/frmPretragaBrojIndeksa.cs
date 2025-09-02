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
        DLWMSContext _db = new DLWMSContext();

        public frmPretragaBrojIndeksa()
        {
            InitializeComponent();

            dgvStudentiStipendije.AutoGenerateColumns = false;
        }

        private void frmPretragaBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbGodina.SelectedIndex = 0;
            OsvjeziStipendije();
            OsvjeziStudenteStipendije();
        }

        private void OsvjeziStipendije()
        {
            if (cmbGodina.SelectedItem == null) return;

            var odabranaGodina = int.Parse(cmbGodina.SelectedItem.ToString()!);

            var stipendijePoGodini = _db.StipendijeGodineBrojIndeksa
                .Include(sg => sg.Stipendija)
                .Where(sg => sg.Godina == odabranaGodina)
                .Select(sg => sg.Stipendija)
                .ToList();

            cmbStipendija.UcitajPodatke(stipendijePoGodini);
        }

        private void OsvjeziStudenteStipendije()
        {
            var query = _db.StudentiStipendijeBrojIndeksa
                .Include(ss => ss.StipendijaGodina)
                .ThenInclude(sg => sg.Stipendija)
                .Include(sg => sg.Student)
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

            this.Text = $"Broj prokazanih studenata: {studentiStipendije.Count()}";

            dgvStudentiStipendije.DataSource = studentiStipendije;

            if (studentiStipendije.Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {cmbGodina.Text}. godini dodijeljena {cmbStipendija.Text} stipendija", "Obavijest", MessageBoxButtons.OK);
            }
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziStipendije();
            OsvjeziStudenteStipendije();
        }

        private void cmbStipendija_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziStudenteStipendije();
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
                e.Value = IzracunUkupno(studentStipendija);
            }
        }

        private object? IzracunUkupno(StudentStipendijaBrojIndeksa? studentStipendija)
        {
            if (studentStipendija.StipendijaGodina.Godina == DateTime.Now.Year)
            {
                return studentStipendija.StipendijaGodina.MjesecniIznos * DateTime.Now.Month;
            }

            return studentStipendija.StipendijaGodina.MjesecniIznos * 12;
        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudentiStipendije.Columns[e.ColumnIndex].Name == "Ukloni")
            {
                var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;

                var odgovor = MessageBox.Show("Da li ste sigurni da želite otkloniti podatke o odabranoj stipendiji?", "Upit", MessageBoxButtons.YesNo);

                if (odgovor == DialogResult.Yes)
                {
                    _db.StudentiStipendijeBrojIndeksa.Remove(studentStipendija);
                    _db.SaveChanges();
                    OsvjeziStudenteStipendije();
                }
            }
        }

        private void btnDodajStipendiju_Click(object sender, EventArgs e)
        {
            var novaForma = new frmStipendijaAddEditBrojIndeksa(_db);
            novaForma.ShowDialog();
            OsvjeziStudenteStipendije();
        }

        private void dgvStudentiStipendije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;
                var novaForma = new frmStipendijaAddEditBrojIndeksa(_db, studentStipendija);
                novaForma.ShowDialog();
                OsvjeziStudenteStipendije();
            }
        }
    }
}
