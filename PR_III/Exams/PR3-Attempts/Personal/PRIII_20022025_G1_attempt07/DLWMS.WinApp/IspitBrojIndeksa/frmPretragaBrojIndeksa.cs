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

        private void OsvjeziStudenteStipendije()
        {
            var query = _db.StudentiStipendijeBrojIndeksa
                .Include(ss => ss.StipendijaGodina)
                    .ThenInclude(sg => sg.Stipendija)
                .Include(ss => ss.Student)
                .AsQueryable();

            if (cmbGodina.SelectedIndex >= 0)
            {
                query = query.Where(ss => ss.StipendijaGodina.Godina == int.Parse(cmbGodina.SelectedItem.ToString()!));
            }

            if (cmbStipendija.SelectedIndex >= 0)
            {
                query = query.Where(ss => ss.StipendijaGodina.StipendijaId == cmbStipendija.SelectedValue as int?);
            }

            var studentiStipendije = query.ToList();
            this.Text = $"Broj prikazanih studenata: {studentiStipendije.Count()}";

            dgvStudentiStipendije.DataSource = studentiStipendije;

            if (studentiStipendije.Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {cmbGodina.Text}. godini dodijeljena {cmbStipendija.Text} stipendija");
            }
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OsvjeziStipendije();
            OsvjeziStudenteStipendije();
        }

        private void OsvjeziStipendije()
        {
            var stipendijeZaGodinu = _db.StipendijeGodineBrojIndeksa
                .Include(sg => sg.Stipendija)
                .Where(sg => sg.Godina == int.Parse(cmbGodina.SelectedItem.ToString()!))
                .Select(sg => sg.Stipendija)
                .ToList();
            cmbStipendija.UcitajPodatke(stipendijeZaGodinu);
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
                e.Value = studentStipendija.Student.Prikaz;
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

        private object? IzracunUkupno(StudentStipendijaBrojIndeksa? ss)
        {
            if (ss.StipendijaGodina.Godina == DateTime.Now.Year)
            {
                return ss.StipendijaGodina.MjesecniIznos * DateTime.Now.Month;
            }
            return ss.StipendijaGodina.MjesecniIznos * 12;
        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudentiStipendije.Columns[e.ColumnIndex].Name == "Ukloni")
            {
                var studentStipendija = dgvStudentiStipendije.Rows[e.RowIndex].DataBoundItem as StudentStipendijaBrojIndeksa;

                var odgovor = MessageBox.Show("Da li ste sigurni za želite obrisati odabrani zapis?", "Upit", MessageBoxButtons.YesNo);

                if (odgovor == DialogResult.Yes)
                {
                    _db.StudentiStipendijeBrojIndeksa.Remove(studentStipendija);
                    _db.SaveChanges();
                    OsvjeziStudenteStipendije();
                }
            }
        }
    }
}
