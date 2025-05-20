using DLWMS.Data;
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

namespace DLWMS.WinApp.IB220347
{
    public partial class frmPretraga : Form
    {
        DLWMSContext db = new DLWMSContext();
        List<Student> students = new List<Student>();
        List<Grad> gradovi = new List<Grad>();
        List<Drzava> drzave = new List<Drzava>();


        public frmPretraga()
        {
            InitializeComponent();
            cmbDrzava.DataSource = db.Drzave.ToList();
            cmbSpol.DataSource = db.Spolovi.ToList();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void cmbDrzava_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void cmbSpol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void tbImePrezime_TextChanged(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            UcitajStudente();
            var drz = cmbDrzava.SelectedValue as Drzava;
            if (students.Count > 0)
            {
                var Tabela = new DataTable();
                Tabela.Columns.Add("InImPr");
                Tabela.Columns.Add("Grad");
                Tabela.Columns.Add("Drzava");
                Tabela.Columns.Add("Status");
                Tabela.Columns.Add("Spol");
                for (int i = 0; i < students.Count; i++)
                {
                    var student = students[i];
                    var Red = Tabela.NewRow();
                    gradovi = db.Gradovi.Where(x => x.Id == student.GradId && x.DrzavaId == drz.Id).ToList();
                    drzave = db.Drzave.Where(x => x.Id == gradovi[0].DrzavaId).ToList();
                    Red["InImPr"] = $"({student.BrojIndeksa}) {student.Ime} {student.Prezime}";
                    Red["Grad"] = gradovi[0].Naziv.ToString();
                    Red["Drzava"] = drzave[0].Naziv.ToString();
                    Red["Status"] = student.Aktivan;
                    Red["Spol"] = student.Spol.Naziv;
                    Tabela.Rows.Add(Red);
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Tabela;
                this.Text = $"Broj studenata: {students.Count}";
            }
            else MessageBox.Show($"U bazi nisu evidentirani studenti spola {cmbSpol.SelectedItem}, koji u imenu i prezimenu posjeduju sadržaj {tbImePrezime.Text}, a koji su državljani {cmbDrzava.SelectedItem}.!");
        }

        private void UcitajStudente()
        {
            var drz = cmbDrzava.SelectedValue as Drzava;
            students = db.Studenti.Where(x => x.Spol == cmbSpol.SelectedItem && x.Grad.DrzavaId == drz.Id && (x.Ime.ToLower().Contains(tbImePrezime.Text.ToLower()) || x.Prezime.ToLower().Contains(tbImePrezime.Text.ToLower()))).ToList();
        }

        private void frmPretraga_Load(object sender, EventArgs e)
        {
            UcitajStudente();
            UcitajPodatke();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UcitajStudente();
                if (students[e.RowIndex].Aktivan == true)
                    students[e.RowIndex].Aktivan = false;
                else students[e.RowIndex].Aktivan = true;
                db.Studenti.Update(students[e.RowIndex]);
                db.SaveChanges();
                UcitajPodatke();
            }
            else if (e.ColumnIndex == 5)
            {
                var frm = new frmRazmjene(students[e.RowIndex]);
                frm.ShowDialog();
                UcitajPodatke();
            }
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Student student = students[e.RowIndex];
            var novafrm = new frmStudentEdit(student);
            novafrm.ShowDialog();  
        }
    }
}
