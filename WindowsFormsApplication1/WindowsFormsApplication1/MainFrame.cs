using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;

namespace ScheduleApp
{
    public partial class MainFrame : Form
    {
        LoginUc login = new LoginUc();

        enum UcType
        {
            Login,
            Admin,
            Register,
            Satnica
        }
        Dictionary<UcType, Control> _windows = new Dictionary<UcType, Control>();
        public MainFrame()
        {
            InitializeComponent();
            

            login.btnSubmit.Click += BtnSubmit_Click;
            login.OnButtonClicked += Login_OnButtonClicked;

            InitUc(UcType.Login, login);
            InitUc(UcType.Admin, new AdminUc());
            InitUc(UcType.Register, new RegisterUc());
            InitUc(UcType.Satnica, new ScheduleEntryUc());

            ShowWindow(UcType.Login);
        }

        private void Login_OnButtonClicked(object sender, EventArgs e)
        {
            UserDb _userDb = new UserDb();
            string Password = login.Password;
            string username = login.UserName;
            var user = _userDb.Login(username, Password);
            if (user == null)
            {
                MessageBox.Show("Kredencije su neispravne!");
                
            }

            else
            {
                
                if (_userDb.UserRole == 1)
                {
                    
                    adminToolStripMenuItem.Visible = true;
                    unosSatniceToolStripMenuItem.Visible = true;

                }
                unosSatniceToolStripMenuItem.Visible = true;
                loginToolStripMenuItem.Visible = false;
                registerToolStripMenuItem.Visible = false;
                logout.Visible = true;
                ShowWindow(UcType.Satnica);

            }

        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        private void InitUc (UcType type, Control Uc)
        {



            Uc.Dock = DockStyle.Fill;

            MainPanel.Controls.Add(Uc);
            _windows.Add(type, Uc);
        }
        private void HideOtherForms()
        {
            foreach (Control c in MainPanel.Controls)
            {
                c.Hide();
            }
        }

        private void ShowWindow(UcType type)
        {
            HideOtherForms();
            _windows[type].Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow(UcType.Register);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow(UcType.Login);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow(UcType.Admin);
        }

        private void unosSatniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow(UcType.Satnica);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            adminToolStripMenuItem.Visible = false;
            unosSatniceToolStripMenuItem.Visible = false;
            loginToolStripMenuItem.Visible = true;
            registerToolStripMenuItem.Visible = true;
            logout.Visible = false;
            ShowWindow(UcType.Login);
        }
    }

}

