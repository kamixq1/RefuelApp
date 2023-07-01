using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefuelApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Load += Main_Load;
            // Zablokowanie minimalizacji i maksymalizacji
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Zablokowanie zmiany rozmiaru okna
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        /// <summary>
        /// załadowanie danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            DataModel dataModel = new DataModel();
            using (dataModel)
            {
                var results = dataModel.Refuels.ToList();
                dataGridView1.DataSource = results;
                dataGridView1.Columns["Id"].Visible = false;

            }

        }

        private void AddRefuel_Click(object sender, EventArgs e)
        {
            RefuelWindow refuel = new RefuelWindow();
            refuel.Show();
        }
        /// <summary>
        /// odświeżenie datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            Main_Load(sender, e);
        }
        /// <summary>
        /// usuwanie wiersza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow) // Sprawdzanie, czy wiersz nie jest nowym wierszem
                        {
                            DataModel dataModel = new DataModel();
                            using (dataModel)
                            {
                                int refuelId = Convert.ToInt32(row.Cells["Id"].Value); // Pobranie wartości ID z wybranej kolumny 
                                var refuel = dataModel.Refuels.FirstOrDefault(x => x.Id == refuelId); // Pobranie obiektu refuel na podstawie ID

                                if (refuel != null)
                                {
                                    dataModel.Refuels.Remove(refuel);
                                    dataModel.SaveChanges();
                                    MessageBox.Show("Poprawnie usunięto");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnych wierszy");
            }
 
        }
    }
}
