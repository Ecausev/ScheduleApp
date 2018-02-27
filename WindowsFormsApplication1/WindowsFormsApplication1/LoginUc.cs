using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;

namespace ScheduleApp
{
    public partial class LoginUc : UserControl
    {
        UserDb _userDb = new UserDb();

        public event EventHandler OnButtonClicked;
        
        public string UserName { get { return Username.Text; } }
        
        public string Password { get { return txtPassword.Text; } }

        public LoginUc()
        {
            InitializeComponent();
        }

        public void Username_TextChanged(object sender, EventArgs e)
        {
            Text = Username.Text;
        }

        public void Password_TextChanged(object sender, EventArgs e)
        {
            Text = txtPassword.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnButtonClicked != null)
                OnButtonClicked(sender, e);
        }

    }
}
