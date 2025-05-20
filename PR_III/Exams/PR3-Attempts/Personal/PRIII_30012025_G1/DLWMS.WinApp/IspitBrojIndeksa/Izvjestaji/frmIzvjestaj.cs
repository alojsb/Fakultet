using DLWMS.Data;
using DLWMS.Data.IspitBrojIndeksa;
using DLWMS.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitBrojIndeksa.Izvjestaji
{
    public partial class frmIzvjestaj : Form
    {
        private Student student = new Student();
        private List<Razmjena> razmjene = new List<Razmjena>();

        public frmIzvjestaj(List<Razmjena> razmjene, Student student)
        {
            InitializeComponent();

            this.student = student;
            this.razmjene = razmjene;
        }

        private void frmIzvjestaj_Load(object sender, EventArgs e)
        {
            var parametri = new ReportParameterCollection();
            parametri.Add(new ReportParameter("pImePrezime", $"{student.Ime} {student.Prezime}"));
            parametri.Add(new ReportParameter("pBrojIndeksa", student.BrojIndeksa));

            var tblRazmjene = new dsRazmjene.RazmjeneIzvjestajDataTable();
            int totalEcts = 0; // To store sum of ECTS points

            for (int i = 0; i < razmjene.Count; i++)
            {
                var red = tblRazmjene.NewRazmjeneIzvjestajRow();
                red.Rb = (i + 1).ToString();
                red.Univerzitet = $"{razmjene[i].Univerzitet.Naziv} ({razmjene[i].Univerzitet.Drzava.Naziv})"; // Concatenated value
                red.Drzava = razmjene[i].Univerzitet.Drzava.Naziv;
                red.Pocetak = razmjene[i].PocetakRazmjene.ToShortDateString();
                red.Kraj = razmjene[i].KrajRazmjene.ToShortDateString();
                red.ECTS = razmjene[i].ECTS.ToString();
                red.Okoncano = razmjene[i].isOkoncana ? "DA" : "NE";

                // Sum ECTS if the exchange was completed
                if (razmjene[i].isOkoncana)
                    totalEcts += razmjene[i].ECTS;

                tblRazmjene.AddRazmjeneIzvjestajRow(red);
            }

            parametri.Add(new ReportParameter("pUkupnoECTS", totalEcts.ToString()));

            var dsRazmjene = new ReportDataSource();
            dsRazmjene.Name = "dsRazmjeneIzvjestaj";
            dsRazmjene.Value = tblRazmjene;

            reportViewer1.LocalReport.DataSources.Add(dsRazmjene);
            reportViewer1.LocalReport.SetParameters(parametri);
            reportViewer1.RefreshReport();
        }
    }
}
