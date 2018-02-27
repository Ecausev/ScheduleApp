using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Database;

namespace ScheduleApp
{
    public partial class RegisterUc : UserControl
    {
        UserDb _userDb = new UserDb();
        public RegisterUc()
        {
            InitializeComponent();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            Text = Username.Text;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            Text = Password.Text;
        }

        private void PasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            Text = PasswordConfirm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passwordPattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{4,12}$";
            Match m = Regex.Match(Password.Text, passwordPattern);
            if (m.Success)
            {
                if (Password.Text == PasswordConfirm.Text)
                {
                    var user = _userDb.getName(Username.Text);

                    if (user != null)
                    {
                        // Ispravne kredencije
                        _userDb.Register(Username.Text, 0);
                        _userDb.Hash(Password.Text);
                        MessageBox.Show("Uspješno ste kreirali racun!");
                        Username.Text = "";
                        Password.Text = "";
                        PasswordConfirm.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Korisničko ime već postoji");
                    }

                }
                else
                {
                    MessageBox.Show("Sifra i potvrda sifre nisu identicne!");
                }

            }
            else
            {
                MessageBox.Show("Neuspjesna sifra!");
            }
        }
    }
}
