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
    public partial class frmStipendijeBrojIndeksa : Form
    {
        DLWMSContext db;

        public frmStipendijeBrojIndeksa(DLWMSContext context)
        {
            InitializeComponent();
            db = context;

            dgvStipendijeGodine.AutoGenerateColumns = false;
        }

        private void frmStipendijeBrojIndeksa_Load(object sender, EventArgs e)
        {
            this.Text = "Upravljanje stipendijama";

            cmbGodina.SelectedIndex = 0;
            UcitajStipendije();
            OsvjeziStipendijeGodine();
        }

        private void UcitajStipendije()
        {
            var stipendije = db.StipendijeBrojIndeksa.ToList();
            cmbStipendija.UcitajPodatke(stipendije);
        }

        private void OsvjeziStipendijeGodine()
        {
            dgvStipendijeGodine.DataSource = db.StipendijeGodineBrojIndeksa.ToList();
        }

        private void dgvStipendijeGodine_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var stipendijaGodina = dgvStipendijeGodine.Rows[e.RowIndex].DataBoundItem as StipendijaGodinaBrojIndeksa;
            var kolona = dgvStipendijeGodine.Columns[e.ColumnIndex].Name;

            if (kolona == "Godina")
            {
                e.Value = stipendijaGodina.Godina;
            }
            else if (kolona == "Stipendija")
            {
                e.Value = stipendijaGodina.Stipendija.Naziv;
            }
            else if (kolona == "MjesecniIznos")
            {
                e.Value = stipendijaGodina.MjesecniIznos;
            }
            else if (kolona == "Ukupno")
            {
                e.Value = IzracunUkupno(stipendijaGodina);
            }
        }

        private object? IzracunUkupno(StipendijaGodinaBrojIndeksa? sg)
        {
            if (sg.Godina == DateTime.Now.Year)
            {
                return sg.MjesecniIznos * DateTime.Now.Month;
            }
            return sg.MjesecniIznos * 12;
        }

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var stipendijaGodina = dgvStipendijeGodine.Rows[e.RowIndex].DataBoundItem as StipendijaGodinaBrojIndeksa;

                stipendijaGodina.Aktivna = !stipendijaGodina.Aktivna;
                db.SaveChanges();
                OsvjeziStipendijeGodine();

            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var godinaText = cmbGodina.SelectedItem.ToString();
            var stipendijaId = cmbStipendija.SelectedValue as int?;
            var mjesecniIznosText = txtMjesecniIznos.Text.Trim();

            if (string.IsNullOrWhiteSpace(godinaText) || stipendijaId == null || !int.TryParse(mjesecniIznosText, out int iznos) || iznos <= 0)
            {
                MessageBox.Show("Molimo popunite validne vrijednosti za polja Godina, Stipendija i Mjesečni iznos.");
                return;
            }

            var godina = int.Parse(godinaText);
            var mjesecniIznos = int.Parse(mjesecniIznosText);

            bool isDuplikat = db.StipendijeGodineBrojIndeksa
                .Any(sg => sg.StipendijaId == stipendijaId && sg.Godina == godina);

            if (isDuplikat)
            {
                MessageBox.Show("Kombinacija godine i stipendije već postoji.");
                return;
            }

            var novaStipendijaGodina = new StipendijaGodinaBrojIndeksa
            {
                StipendijaId = stipendijaId.Value,
                Godina = godina,
                MjesecniIznos = mjesecniIznos,
                Aktivna = true
            };
            db.StipendijeGodineBrojIndeksa.Add(novaStipendijaGodina);
            db.SaveChanges();
            OsvjeziStipendijeGodine();
        }

        private void cmbGodina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajStipendije();
        }
    }
}
