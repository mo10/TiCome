using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiCome
{
    public partial class EditCookieForm : Form
    {
        private MainForm mainForm;
        private HelpForm helpForm;

        public EditCookieForm(MainForm parentForm)
        {
            InitializeComponent();
            helpForm = new HelpForm();
            if(parentForm != null && !parentForm.IsDisposed)
            {
                this.mainForm = parentForm;
                user_session.Text = this.mainForm.GetCookie();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(mainForm == null || mainForm.IsDisposed)
            {
                mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => this.Close();
            }
            mainForm.SetCookie(user_session.Text);
            mainForm.Show();
            this.Hide();
            helpForm?.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(helpForm == null || helpForm.IsDisposed)
            {
                helpForm = new HelpForm();
            }
            helpForm.Hide();
            helpForm.Show();
        }
    }
}
