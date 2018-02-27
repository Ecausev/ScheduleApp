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
    public partial class ScheduleEntryUc : UserControl
    {
        UserDb _userdb = new UserDb();
        OdradenoDb _odradenodb = new OdradenoDb();
        SatnicaDb _SatnicaDb = new SatnicaDb();

        public ScheduleEntryUc()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            Text = inputText.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string unosPattern = @"^[0-9]{1,2}$";
            Match m = Regex.Match(inputText.Text, unosPattern);
            if (m.Success)
            {
                int userValue;
                if (int.TryParse(inputText.Text, out userValue) && userValue < 15 && userValue > 3)
                {
                    var danUnos = dateTimePicker1.Value.DayOfWeek;
                    DateTime datum = dateTimePicker1.Value.Date;
                    int sat = userValue;
                    _SatnicaDb.defineSatnicaId(danUnos);
                    _odradenodb.Unos(datum, sat);
                    if (_odradenodb.Greska == true)
                    {
                        MessageBox.Show("Vec postoji zapis za taj datum.");
                    }
                    else
                    {
                        MessageBox.Show($"Za datum {datum.ToShortDateString()} Uspjesno je zapisano {sat} sati. ");
                    }
                }
                else
                {
                    MessageBox.Show("Uneseni broj sati je veći od 15 ili manji od 4!");
                }

            }
            else
            {
                MessageBox.Show("Unesi satnicu Brojcano!");
            }

            LoadSum();
        }

        private void SumaPlaca_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void LoadSum()
        {
            _odradenodb.showSum();
            SumaPlaca.Text = _odradenodb.ukupnaSatnica.ToString();
        }

        private void logout_Click(object sender, EventArgs e)
        {

        }
    }
}
