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
    public partial class RefuelWindow : Form
    {
        public RefuelWindow()
        {
            InitializeComponent();
            // Zablokowanie minimalizacji i maksymalizacji
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Zablokowanie zmiany rozmiaru okna
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        /// <summary>
        /// zapis danych do bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(PriceInput.Text) && !string.IsNullOrEmpty(OdometerInput.Text) && !string.IsNullOrEmpty(dateTimePicker1.Text) && !string.IsNullOrEmpty(QuantityInput.Text))
            {
                try
                {
                    Refuels refuels = new Refuels();
                    double avg = 0;
                    refuels.Odometer = OdometerInput.Text;
                    refuels.Price = double.Parse(PriceInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                    refuels.Quantity = double.Parse(QuantityInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                    refuels.RefuelDate = dateTimePicker1.Value;
                    refuels.Cost = double.Parse(costInput.Text, System.Globalization.CultureInfo.InvariantCulture);
                    avg = double.Parse(QuantityInput.Text, System.Globalization.CultureInfo.InvariantCulture) / double.Parse(refuels.Odometer, System.Globalization.CultureInfo.InvariantCulture) * 100;
                    DataModel dataModel = new DataModel();
                    using (dataModel)
                    {
                        dataModel.Refuels.Add(refuels);
                        dataModel.SaveChanges();
                    }

                    double AvgRound = Math.Round(avg, 2);
                    MessageBox.Show("Średnie spalanie: "+ AvgRound);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
          
            }
            else
            {
                MessageBox.Show("Nie wprowadzono poprawnie danych");
            }

        }
    }
}
