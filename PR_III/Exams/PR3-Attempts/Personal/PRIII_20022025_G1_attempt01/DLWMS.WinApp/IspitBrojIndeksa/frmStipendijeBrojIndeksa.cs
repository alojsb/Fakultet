using DLWMS.Data.IspitBrojIndeksa;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
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
        DLWMSContext _db;

        public frmStipendijeBrojIndeksa(DLWMSContext context)
        {
            InitializeComponent();
            _db = context;
            dgvStipendijeGodine.AutoGenerateColumns = false;
            dgvStipendijeGodine.CellFormatting += dgvStipendijeGodine_CellFormatting;
        }

        private void frmStipendijeBrojIndeksa_Load(object sender, EventArgs e)
        {
            cmbStipendija.UcitajPodatke(_db.StipendijeBrojIndeksa.ToList());
            OsvjeziPodatke();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbGodina.SelectedIndex < 0 || cmbStipendija.SelectedIndex < 0 || int.Parse(txtIznos.Text) < 0)
            {
                MessageBox.Show("Podaci za unos nisu validni", "Upozorenje", MessageBoxButtons.OK);
                return;
            }

            var postojecaKombinacija = _db.StipendijeGodineBrojIndeksa
                .Where(sg => sg.StipendijaId == (int)cmbStipendija.SelectedValue && sg.Godina == int.Parse(cmbGodina.SelectedItem.ToString()))
                .ToList();

            if (postojecaKombinacija.Count != 0)
            {
                MessageBox.Show("Postojeća kombinacija stipendije i godine već postoji.", "Upozorenje", MessageBoxButtons.OK);
                return;
            }

            var novaStipendijaGodina = new StipendijaGodinaBrojIndeksa
            {
                StipendijaId = (int)cmbStipendija.SelectedValue,
                Godina = int.Parse(cmbGodina.SelectedItem.ToString()),
                Iznos = int.Parse(txtIznos.Text),
                Aktivna = true
            };

            _db.StipendijeGodineBrojIndeksa.Add(novaStipendijaGodina);
            _db.SaveChanges();
        }

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvStipendijeGodine.Rows[e.RowIndex].DataBoundItem as StipendijaGodinaBrojIndeksa;

                if (selectedRow != null) { 
                    
                    selectedRow.Aktivna = !selectedRow.Aktivna;
                }

                _db.SaveChanges();

                OsvjeziPodatke();
            }
        }

        private void OsvjeziPodatke()
        {
            dgvStipendijeGodine.DataSource = _db.StipendijeGodineBrojIndeksa.ToList();
        }

        private void dgvStipendijeGodine_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var stipendijaGodina = dgvStipendijeGodine.Rows[e.RowIndex].DataBoundItem as StipendijaGodinaBrojIndeksa;
            var kolona = dgvStipendijeGodine.Columns[e.ColumnIndex].Name;

            if (kolona == "UkupniIznos")
            {
                e.Value = IzracunUkupno(stipendijaGodina);
            }
        }

        private int IzracunUkupno(StipendijaGodinaBrojIndeksa sg)
        {
            if (sg.Godina == DateTime.Now.Year)
            {
                return sg.Iznos * DateTime.Now.Month;
            }
            else
            {
                return sg.Iznos * 12;
            }
        }
    }
}
