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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            // Zablokowanie minimalizacji i maksymalizacji
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Zablokowanie zmiany rozmiaru okna
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        /// <summary>
        /// zaloguj
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            DataModel dataModel = new DataModel();
            using (dataModel)
            {
                int loginInput = Int32.Parse(loginbox.Text);
                var login = dataModel.Logins.FirstOrDefault(x=>x.PersonId == loginInput && x.Passwords == passwordbox.Text);
                if (login != null)
                {

                    MessageBox.Show("Zalogowano poprawnie");
                    
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Nie poprawny login lub hasło");
                }
            }
        }
    }
}
