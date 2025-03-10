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
using DLWMS.WinApp.Helpers;
using Microsoft.EntityFrameworkCore;
using DLWMS.WinApp.IspitBrojIndeksa;

namespace DLWMS.WinApp._2367
{
    public partial class frmKakoHoces : Form
    {
        private readonly DLWMSContext _DLWMSContext = new();

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

        private void txtImeIliPrezime_KeyUp(object sender, KeyEventArgs e)
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
            if (cbSpol.SelectedIndex > -1 && cbSpol.SelectedValue != null)
            {
                query = query.Where(s => s.SpolId == (int)cbSpol.SelectedValue);
            }

            // If the user picked a Drzava, filter by DrzavaId
            if (cbDrzava.SelectedIndex > -1 && cbDrzava.SelectedValue != null)
            {
                int selectedDrzavaId = (int)cbDrzava.SelectedValue;
                query = query.Where(s => s.Grad.DrzavaId == selectedDrzavaId);
            }

            // If the user types a string in the Ime i prezime field
            string filterText = txtImeIliPrezime.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filterText))
            {
                query = query.Where(s => s.Ime.ToLower().Contains(filterText) || s.Prezime.ToLower().Contains(filterText));
            }

            // Execute the query and show the results
            var filteredList = query.ToList();

            // Set the form’s Text property to show the count:
            this.Text = $"Broj prikazanih studenata: {filteredList.Count}";

            // If we found no matches, display a custom message in the DataGridView
            if (filteredList.Count == 0)
            {
                //var spolText = cbSpol.SelectedIndex > -1 ? cbSpol.Text : "nepoznatog spola";
                //var drzavaText = cbDrzava.SelectedIndex > -1 ? cbDrzava.Text : "nepoznate drzave";

                var spolText = cbSpol.Text;
                var drzavaText = cbDrzava.Text;

                dataGridView1.DataSource = filteredList;

                MessageBox.Show(
                    $"U bazi nisu evidentirani studenti spola \"{spolText}\", " +
                    $"koji u imenu ili prezimenu posjeduju sadržaj \"{txtImeIliPrezime.Text}\" " +
                    $"i koji su državljani \"{drzavaText}\".",
                    "Prazna pretraga"
                );
            }
            else
            {
                // Otherwise, just show the filtered students
                dataGridView1.DataSource = filteredList;
            }

            //lblSpol.Text = cbSpol?.SelectedValue?.ToString();
            //label3.Text = cbDrzava?.SelectedValue?.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure it's a valid row and the user clicked the "Aktivan" column.
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Aktivan")
            {
                // End edit to ensure the checkbox state is updated in the row’s data.
                dataGridView1.EndEdit();

                // Retrieve the Student object bound to this row.
                var student = (Student)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // student.Aktivan is already updated by the checkbox; just save to DB.
                _DLWMSContext.SaveChanges();

                // Optionally, refresh the grid if needed:
                // dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // If your grid is bound to an EF list of Student:
            var studentRow = (Student)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            // Or, if you only stored an ID in the row, retrieve it first:
            // int selectedStudentId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

            // Eager load Grad + Drzava for the selected student
            var loadedStudent = _DLWMSContext.Studenti
                .Include(s => s.Grad)
                .ThenInclude(g => g.Drzava)
                .FirstOrDefault(s => s.Id == studentRow.Id);

            // Pass the loaded student to your detail form
            var studentDetailFrm = new frmStudentEditBrojIndeksa(loadedStudent, _DLWMSContext);
            studentDetailFrm.ShowDialog();
        }

    }
}
